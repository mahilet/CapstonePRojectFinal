using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JeffriesDataLibrary
{
    public class StudentsService : IStudentsSerevice {

        private SqlConnection _conn;
     

        public SqlConnection conn
        {
            get
            {

                if (_conn == null)
                {
                    _conn = new SqlConnection(DbHelper.ConnectionString);
                }

                if (string.IsNullOrEmpty(_conn.ConnectionString))
                { _conn.ConnectionString = DbHelper.ConnectionString; }

                return _conn;
            }
        }  

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetAllStudents";
                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Student student = new Student()
                        {
                           StudentId = (int)dr["studentId"],
                            CourseId = (int)dr["courseId"],
                            LastName = (string)dr["lastName"],
                            FirstName = (string)dr["firstName"],
                            Campus = (byte)dr["campus"],
                            Email = (string)dr["Email"]
                        };
                        students.Add(student);
                    }
                    dr.Close();
                }

            }
            return students;
        }


        public Student Get(int studentId)
        {
            Student student = new Student();

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetStudentById";
                    cmd.Parameters.Add(new SqlParameter("@StudentId", studentId));
              

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                      student = new Student()
                        {
                            StudentId = (int)dr["studentId"],
                            CourseId = (int)dr["courseId"],
                            LastName = (string)dr["lastName"],
                            FirstName = (string)dr["firstName"],
                            Campus = (byte)dr["campus"],
                            Email=(String)dr["email"]
                        };
                       
                    }
                    dr.Close();
                }

            }
            return student;
        }

        public Student Add(Student item)
        {
            int id = -1;
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertStudent";
                    cmd.Parameters.Add(new SqlParameter("@CourseId", item.CourseId));
                    cmd.Parameters.Add(new SqlParameter("@LastName", item.LastName));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", item.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@Campus", item.Campus));
                    cmd.Parameters.Add(new SqlParameter("@Email", item.Email));
                    cmd.Parameters.Add("@NewStudentId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    id = (int)cmd.Parameters["@NewStudentId"].Value;

                }
            }

            Student student = this.Get(id);
            return student;
        }

        public void Remove(int StudentId)
        {
            using (conn)
            {
                using(SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteStudent";
                    cmd.Parameters.Add(new SqlParameter("@StudentId", StudentId));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool Update(Student item)
        {
            int rowsUpdated = -1;
            using (conn)
            {
                using(SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateStudent";
                    cmd.Parameters.Add(new SqlParameter("@StudentId", item.StudentId));
                    cmd.Parameters.Add(new SqlParameter("@CourseId", item.CourseId));
                    cmd.Parameters.Add(new SqlParameter("@LastName", item.LastName));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", item.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@Campus", item.Campus));
                    cmd.Parameters.Add(new SqlParameter("@Email", item.Email));
                    conn.Open();

                    rowsUpdated = cmd.ExecuteNonQuery();
                }

            }
            bool test = (rowsUpdated > 0);
            return (rowsUpdated > 0);
        }

    }
}