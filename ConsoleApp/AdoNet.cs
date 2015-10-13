using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPExamples
{
    public class AdoNet
    {
        public void Execute()
        {
            //Basic ADO data read
            using(SqlConnection connection = new SqlConnection("Server=NB-JPOWELL\\SQLEXPRESS;Database=AdventureWorks2014;user=sa;password=Wargame5!"))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand("SELECT * FROM [AdventureWorks2014].[Person].[Person]", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
	                {
		                while (reader.Read())
		                {
                            Console.WriteLine("{0} {1} {2}",
                            reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2));
		                }
                    }
                }
            }
        }
    }
}