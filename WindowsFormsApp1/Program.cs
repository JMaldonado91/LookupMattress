using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace WindowsFormsApp1
{
    public class Program
    {

        private const string CreateTableQuery = @"CREATE TABLE IF NOT EXISTS [mattress_lookup] (
                                               [mattress] VARCHAR NOT NULL PRIMARY KEY,
                                               [feel] VARCHAR NULL,
                                               [year] INTEGER NULL,
								               [profile] INTEGER NULL)";

        private const string DatabaseFile = "mattress.db";
        private const string DatabaseSource = "data source=" + DatabaseFile;

        private static void Initialize()
        {
            // Create the file which will be hosting my database
            if (!File.Exists(DatabaseFile))
            {
                SQLiteConnection.CreateFile(DatabaseFile);
            }

            // Connect to the database 
            using (var connection = new SQLiteConnection(DatabaseSource))
            {
                // Create a database command
                using (var command = new SQLiteCommand(connection))
                {
                    connection.Open();

                    // Create the table
                    command.CommandText = CreateTableQuery;
                    command.ExecuteNonQuery();

                    // Insert entry in database table

                    command.CommandText = "INSERT INTO mattress_lookup (mattress, feel, year, profile) VALUES ('Legacy','extra soft','2017','10')";
                    command.ExecuteNonQuery();

                    // Select and display database entry
                    command.CommandText = "Select * FROM mattress_lookup ";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["mattress"] + " , " + reader["feel"] + " , " + reader["year"] + " , " + reader["profile"]);
                        }
                    }
                    connection.Close(); // Close the connection to the database
                }
            }
        }
        private static void Main(string[] args)
            {
            Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            }
        }
    }











