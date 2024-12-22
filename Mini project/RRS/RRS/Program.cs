using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RRS
{
    class Program
    {
        static string connectionString = "Data Source=ICS-LT-41YLV44\\SQLEXPRESS;Initial Catalog=Railways;Integrated Security=True";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("====================================RAILWAY RESERVATION SYSTEM====================================");
                Console.WriteLine();
                Console.WriteLine("Welcome : ");
                Console.WriteLine();
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Exit");
                Console.WriteLine("-------------------------------");
                Console.Write("Enter your choice : ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        Admin();
                        break;
                    case 2:
                        User();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice,try again");
                        break;
                }
            }
        }

        static void Admin()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Admin Menu:");
                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. Modify Train");
                Console.WriteLine("3. Delete Train");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice : ");
                Console.WriteLine("-------------------------------");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    switch (choice)
                    {

                        // Adding the Trains
                        case 1:
                            Console.WriteLine("Enter Train Name, Source, Destination, Total Berths:");
                            string tName = Console.ReadLine();
                            string src = Console.ReadLine();
                            string dest = Console.ReadLine();
                            int berths = int.Parse(Console.ReadLine());
                            string trainClass = "AC";

                            SqlCommand addCmd = new SqlCommand("AddTrain", conn);
                            addCmd.CommandType = CommandType.StoredProcedure;
                            addCmd.Parameters.AddWithValue("@TrainName", tName);
                            addCmd.Parameters.AddWithValue("@Source", src);
                            addCmd.Parameters.AddWithValue("@Destination", dest);
                            addCmd.Parameters.AddWithValue("@TotalBerths", berths);
                            addCmd.Parameters.AddWithValue("@TrainClass", trainClass); 

                            addCmd.ExecuteNonQuery();
                            Console.WriteLine("Train added");
                            Console.WriteLine("-------------------------------");
                            break;

                            //Modifying the trains
                        case 2:
                            Console.WriteLine("Enter Train ID to Modify, New Train Name, Source, Destination:");
                            int modifyId = int.Parse(Console.ReadLine());
                            string newName = Console.ReadLine();
                            string newSource = Console.ReadLine();
                            string newDestination = Console.ReadLine();

                            SqlCommand modifyCmd = new SqlCommand("ModifyTrain", conn);
                            modifyCmd.CommandType = CommandType.StoredProcedure;
                            modifyCmd.Parameters.AddWithValue("@TrainID", modifyId);
                            modifyCmd.Parameters.AddWithValue("@TrainName", newName);
                            modifyCmd.Parameters.AddWithValue("@Source", newSource);
                            modifyCmd.Parameters.AddWithValue("@Destination", newDestination);

                            modifyCmd.ExecuteNonQuery();
                            Console.WriteLine("Train modified successfully");
                            Console.WriteLine("-------------------------------");
                            break;

                            //Deleting the trains
                        case 3:
                            Console.WriteLine("Enter Train ID to Delete:");
                            int deleteId = int.Parse(Console.ReadLine());

                            SqlCommand deleteCmd = new SqlCommand("DeleteTrain", conn);
                            deleteCmd.CommandType = CommandType.StoredProcedure;
                            deleteCmd.Parameters.AddWithValue("@TrainID", deleteId);

                            deleteCmd.ExecuteNonQuery();
                            Console.WriteLine("Train deleted");
                            Console.WriteLine("-------------------------------");
                            break;

                        case 4:
                            return;

                        default:
                            Console.WriteLine("Invalid choice, try again");
                            break;
                    }
                }
            }
        }


        static void User()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("User Menu:");
                Console.WriteLine("1. Book Ticket");
                Console.WriteLine("2. Cancel Ticket");
                Console.WriteLine("3. Show All Trains");
                Console.WriteLine("4. Show My Bookings/Cancellations");
                Console.WriteLine("5. Exit");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Enter your choice : ");
                int choice = int.Parse(Console.ReadLine());
                Console.Clear();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    switch (choice)
                    {

                        //Booking the tickets
                        case 1:
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("Enter Train ID, Seats to Book:");
                            int trainId = int.Parse(Console.ReadLine());
                            int seats = int.Parse(Console.ReadLine());

                            Console.WriteLine("Select Train Class (AC/Sleeper/General):");
                            string trainClass = Console.ReadLine();

                            string checkTrain = "SELECT AvailableBerths FROM Train WHERE TrainID = @TrainID";

                            using (SqlCommand checkCmd = new SqlCommand(checkTrain, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@TrainID", trainId);
                                var availableSeats = checkCmd.ExecuteScalar();
                                if (availableSeats != DBNull.Value && (int)availableSeats >= seats)
                                {
                                    SqlCommand bookCmd = new SqlCommand("BookTicket", conn);
                                    bookCmd.CommandType = CommandType.StoredProcedure;
                                    bookCmd.Parameters.AddWithValue("@TrainID", trainId);
                                    bookCmd.Parameters.AddWithValue("@SeatsBooked", seats);
                                    bookCmd.Parameters.AddWithValue("@TrainClass", trainClass);

                                    try
                                    {
                                        bookCmd.ExecuteNonQuery();
                                        Console.WriteLine("Ticket booked");

                                        SqlCommand updateSeatsCmd = new SqlCommand("UPDATE Train SET AvailableBerths = AvailableBerths - @SeatsBooked WHERE TrainID = @TrainID", conn);
                                        updateSeatsCmd.Parameters.AddWithValue("@SeatsBooked", seats);
                                        updateSeatsCmd.Parameters.AddWithValue("@TrainID", trainId);
                                        updateSeatsCmd.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Not enough available seats for this booking.");
                                }
                            }
                            break;

                        // Cancelling the tickets
                        case 2:
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("Enter Booking ID to Cancel:");
                            int bookingId = int.Parse(Console.ReadLine());

                            SqlCommand cancelCmd = new SqlCommand("CancelTicket", conn);
                            cancelCmd.CommandType = CommandType.StoredProcedure;
                            cancelCmd.Parameters.AddWithValue("@BookingID", bookingId);

                            try
                            {
                                cancelCmd.ExecuteNonQuery();
                                Console.WriteLine("Ticket cancelled successfully!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                            }
                            break;

                        // Showing all trains with all status
                        case 3:
                            Console.WriteLine("-------------------------------");
                            SqlCommand showCmd = new SqlCommand("ShowTrains", conn);
                            showCmd.CommandType = CommandType.StoredProcedure;

                            SqlDataReader reader = showCmd.ExecuteReader();
                            Console.WriteLine("TrainID | TrainName | Source | Destination | Total Berths | Available Berths | Status | Train Class");

                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["TrainID"]} | " +
                                                  $"{reader["TrainName"]} | " +
                                                  $"{reader["Source"]} | " +
                                                  $"{reader["Destination"]} | " +
                                                  $"{reader["TotalBerths"]} | " +
                                                  $"{reader["AvailableBerths"]} | " +
                                                  $"{(Convert.ToBoolean(reader["IsActive"]) ? "Active" : "Inactive")} | " +
                                                  $"{reader["TrainClass"]}");
                            }
                            reader.Close();
                            break;

                        // Showing the Bookings done by the user
                        case 4:
                            Console.WriteLine("-------------------------------");
                            Console.WriteLine("Enter Booking ID to view your bookings:");
                            Console.WriteLine("{* Your Train ID is your Booking ID}");
                            Console.WriteLine();
                            int myBookingID = int.Parse(Console.ReadLine());

                            string Bkhistory = @"
                                SELECT b.BookingID, t.TrainName, b.SeatsBooked, b.BookingDate, b.Status, b.TrainClass
                                FROM Booking b
                                INNER JOIN Train t ON b.TrainID = t.TrainID
                                WHERE b.BookingID = @BookingID";

                            SqlCommand BhistoryCmd = new SqlCommand(Bkhistory, conn);
                            BhistoryCmd.Parameters.AddWithValue("@BookingID", myBookingID);

                            SqlDataReader BkReader = BhistoryCmd.ExecuteReader();
                            Console.WriteLine("BookingID | TrainName | SeatsBooked | BookingDate | Status | Train Class");

                            while (BkReader.Read())
                            {
                                Console.WriteLine($"{BkReader["BookingID"]} | " +
                                                  $"{BkReader["TrainName"]} | " +
                                                  $"{BkReader["SeatsBooked"]} | " +
                                                  $"{BkReader["BookingDate"]} | " +
                                                  $"{BkReader["Status"]} | " +
                                                  $"{BkReader["TrainClass"]}");
                            }
                            BkReader.Close();
                            break;

                        case 5:
                            return;

                        default:
                            Console.WriteLine("Invalid choice, try again");
                            break;
                    }
                }
            }
        }
    }
}
