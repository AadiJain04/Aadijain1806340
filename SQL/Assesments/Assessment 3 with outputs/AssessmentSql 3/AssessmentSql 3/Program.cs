using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=ICS-LT-41YLV44\\SQLEXPRESS;Database=Assessment;Trusted_Connection=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("InsertingPDetails", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductName", "Anarc Watch");
                command.Parameters.AddWithValue("@Price", 50000.00);

                SqlParameter productIdParam = new SqlParameter("@GeneratedProductId", SqlDbType.Int){};
                command.Parameters.Add(productIdParam);

               
                command.ExecuteNonQuery();

                int generatedProductId = (int)productIdParam.Value;

                Console.WriteLine($"Generated ProductId: {generatedProductId}");
                Console.ReadLine();
            }
        }
    }
}