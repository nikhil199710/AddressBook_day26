using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace AddressBookADO.net
{
    class AddressBookRepo
    {
        
        public static string connectionString = @"Server=NIKHIL-ACER\SQLEXPRESS; Initial Catalog =addressBookService; User ID =nikhil; Password=kumar";
        SqlConnection connection = new SqlConnection(connectionString);

        /// <summary>
        /// UC 1:
        /// The connection string which creates the connection between our code and the databse
        /// </summary>
        public void EnsureDataBaseConnection()
        {
            connection.Open();
            using (connection)
            {
                Console.WriteLine("Connection Established!");
            }
            connection.Close();
        }
        /// <summary>
        /// UC 2:
        /// Gets all the Entries from the database.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void GetAllEntries()
        {
            AddressBookModel model = new AddressBookModel();
            try
            {
                using (connection)
                {
                    string query = @"select * from address_book";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.FirstName = reader.GetString(0);
                            model.LastName = reader.GetString(1);
                            model.Address = reader.GetString(2);
                            model.City = reader.GetString(3);
                            model.State = reader.GetString(4);
                            model.Zip = reader.GetInt32(5);
                            model.PhoneNo = reader.GetInt64(6);
                            model.Email = reader.GetString(7);
                            model.AddressBookName = reader.GetString(8);
                            model.ContactType = reader.GetString(9);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", model.FirstName, model.LastName, model.Address, model.City, model.State, model.Zip, model.PhoneNo, model.Email, model.AddressBookName, model.ContactType);
                        }
                    }
                    else
                        Console.WriteLine("No data found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// UC 3:
        /// Adds the contact.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public bool AddContact(AddressBookModel model)
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.SpAddContactRecords", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fname", model.FirstName);
                    command.Parameters.AddWithValue("@sname", model.LastName);
                    command.Parameters.AddWithValue("@address", model.Address);
                    command.Parameters.AddWithValue("@city", model.City);
                    command.Parameters.AddWithValue("@state", model.State);
                    command.Parameters.AddWithValue("@zip", model.Zip);
                    command.Parameters.AddWithValue("@phoneNo", model.PhoneNo);
                    command.Parameters.AddWithValue("@email", model.Email);
                    command.Parameters.AddWithValue("@bookName", model.AddressBookName);
                    command.Parameters.AddWithValue("@type", model.ContactType);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    //connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// UC 4:
        /// Updates the contact details with name
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateContact(string firstname)
        {
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    string query = @"update dbo.address_book set Zip=281006 where FirstName=@parameter";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    command.Parameters.AddWithValue("@parameter", firstname);

                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// UC 5:
        /// Delete contact from table with given name
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteContact(string firstname)
        {
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    string query = @"delete from address_book where FirstName=@parameter";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    command.Parameters.AddWithValue("@parameter", firstname);

                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        Console.WriteLine("Delete Successful!");
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// UC 6:
        /// Retrieves data from table with given name
        /// </summary>
        public void GetPersonByCityOrState()
        {
            AddressBookModel model = new AddressBookModel();
            try
            {
                using (this.connection)
                {
                    string query = @"select * from address_book where City='chapra' or State='bihar'";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            model.FirstName = reader.GetString(0);
                            model.LastName = reader.GetString(1);
                            model.Address = reader.GetString(2);
                            model.City = reader.GetString(3);
                            model.State = reader.GetString(4);
                            model.Zip = reader.GetInt32(5);
                            model.PhoneNo = reader.GetInt64(6);
                            model.Email = reader.GetString(7);
                            model.AddressBookName = reader.GetString(8);
                            model.ContactType = reader.GetString(9);
                            Console.WriteLine("{0} {1}", model.FirstName, model.LastName);
                        }
                    }
                    else
                        Console.WriteLine("No data found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// UC 7:
        /// Gets size by city name
        /// </summary>
        /// <returns></returns>
        public void GetSizeByCity(string city)
        {
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    string query = @"select City,count(City) as CitySize from dbo.address_book where City=@parameter group by City";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    command.Parameters.AddWithValue("@parameter", city);
                    //var result = command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int CitySize = reader.GetInt32(1);
                            Console.WriteLine($"City:{city}\nCity Count:{CitySize}");
                            //connection.Close();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// UC 7:
        /// Gets size by state name
        /// </summary>
        /// <returns></returns>
        public void GetSizeByState(string state)
        {
            try
            {
                using (this.connection)
                {
                    connection.Open();
                    string query = @"select State,count(State) as StateSize from dbo.address_book where State=@parameter group by State";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    command.Parameters.AddWithValue("@parameter", state);
                    //var result = command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int StateSize = reader.GetInt32(1);
                            Console.WriteLine($"City:{state}\nCity Count:{StateSize}");
                            //connection.Close();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}