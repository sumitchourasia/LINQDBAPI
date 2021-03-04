using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LinqDBApi.DataBase
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Standard { get; set; }
        public double Fee { get; set; }

        //jsonobject remaining

        public PracticeDbContext Db { get; set; }
        public Student()
        {
        }

        public Student(PracticeDbContext db)
        {
            Db = db;
        }


        public async Task<List<Student>> getAsync()
        {
            MySqlCommand cmd = null;
            List<Student> studentList = new List<Student>();
            try
            {
                await Db.Connection.OpenAsync().ConfigureAwait(false);
                cmd = Db.Connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetStudentData";
                //cmd.Parameters.AddWithValue("currenttransactionid_V", capillaryPointResponse.CurrentTransactionId);
                using (var reader = await cmd.ExecuteReaderAsync().ConfigureAwait(false))
                {
                    while (await reader.ReadAsync().ConfigureAwait(false))
                    {
                        studentList.Add(new Student()
                        {
                            Id = reader.IsDBNull("Id") ? 0 : reader.GetInt32("Id"),
                            FirstName = reader.IsDBNull("firstName") ? String.Empty : reader.GetString("firstName"),
                            LastName = reader.IsDBNull("lastName") ? String.Empty : reader.GetString("lastName"),
                            Fee = reader.IsDBNull("fee") ? 0 : reader.GetDouble("fee"),
                            Standard = reader.IsDBNull("Standard") ? 0 : reader.GetInt32("Standard"),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                    cmd.Dispose();
                if (Db.Connection.State == ConnectionState.Open)
                    await Db.Connection.CloseAsync();
            }
            return studentList.Count > 0 ? studentList : null;
        }


    }
}
