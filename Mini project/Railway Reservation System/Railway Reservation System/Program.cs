using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_System
{
    class Program
    {
        // Connection string to SQL Server
        static string connectionString = "Data Source=ICS-LT-41YLV44\\SQLEXPRESS;Initial Catalog=Railway;Integrated Security=True;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("=====================  Railway Reservation System  =========================");
                Console.WriteLine();
                Console.WriteLine("Welcome to Railway Reservation System");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Exit");
                Console.WriteLine("----------------------------");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AdminMenu();
                        break;

                    case 2:
                        UserMenu();
                        break;

                    case 3:
                        Console.WriteLine("Exiting the application. Thank you!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Admin Menu
        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("------Admin Menu-------");
                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. Exit");
                Console.WriteLine("---------------------------");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddTrain();
                        break;

                    case 2:
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Function to add train to the system
        static void AddTrain()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Enter Train Number:");
            int trainNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Train Name:");
            string trainName = Console.ReadLine();

            Console.WriteLine("Enter Source:");
            string source = Console.ReadLine();

            Console.WriteLine("Enter Destination:");
            string destination = Console.ReadLine();

            Console.WriteLine("Enter First Class Seats:");
            int firstClassSeats = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Second Class Seats:");
            int secondClassSeats = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Sleeper Class Seats:");
            int sleeperClassSeats = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("AddTrain", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    cmd.Parameters.AddWithValue("@TrainName", trainName);
                    cmd.Parameters.AddWithValue("@Source", source);
                    cmd.Parameters.AddWithValue("@Destination", destination);
                    cmd.Parameters.AddWithValue("@FirstClassSeats", firstClassSeats);
                    cmd.Parameters.AddWithValue("@SecondClassSeats", secondClassSeats);
                    cmd.Parameters.AddWithValue("@SleeperClassSeats", sleeperClassSeats);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Train added successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // User Menu
        static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("---------User Menu----------");
                Console.WriteLine("1. Book Ticket");
                Console.WriteLine("2. Cancel Ticket");
                Console.WriteLine("3. Show All Trains");
                Console.WriteLine("4. Exit");
                Console.WriteLine("----------------------------");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        BookTicket();
                        break;

                    case 2:
                        CancelTicket();
                        break;

                    case 3:
                        ShowAllTrains();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Function to book a ticket
        static void BookTicket()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Enter Train Number:");
            int trainNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Class (FirstClass/SecondClass/SleeperClass):");
            string classType = Console.ReadLine();

            Console.WriteLine("Enter Number of Seats:");
            int seats = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Bookings (TrainNo, Class, SeatsBooked, Status) VALUES (@TrainNo, @Class, @Seats, 'Booked')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    cmd.Parameters.AddWithValue("@Class", classType);
                    cmd.Parameters.AddWithValue("@Seats", seats);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Ticket booked successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Function to cancel a ticket
        static void CancelTicket()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Enter Booking ID to cancel:");
            int bookingId = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("CancelBooking", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Ticket cancelled successfully. Refund initiated.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Function to show all trains
        static void ShowAllTrains()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Trains";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("TrainNo | TrainName | Source | Destination | FirstClassSeats | SecondClassSeats | SleeperClassSeats");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["TrainNo"]} | {reader["TrainName"]} | {reader["Source"]} | {reader["Destination"]} | {reader["FirstClassSeats"]} | {reader["SecondClassSeats"]} | {reader["SleeperClassSeats"]}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}

