using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JeffriesDataLibrary
{
    public class CoursesService : ICoursesService
    {
        private SqlConnection _conn;
        public SqlConnection conn
        {
            get
            {

                if (_conn == null)
                {
                    _conn = new SqlConnection(DbHelper.ConnectionString);
                }

                if (string.IsNullOrEmpty(_conn.ConnectionString)) { _conn.ConnectionString = DbHelper.ConnectionString; }

                return _conn;
            }
        }

        public List<Course> GetAll()
        {
            //throw new NotImplementedException();
            List<Course> courses = new List<Course>();

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetAllCourses";

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Course course = new Course()
                        {
                            CourseId = (int)dr["CourseId"],
                            Title = (string)dr["Title"],
                            Description = (string)dr["Description"]
                        };
                        courses.Add(course);
                    }

                    dr.Close();
                }
            }

            return courses;
        }

        public Course Get(int courseId)
        {

            //throw new NotImplementedException();

            Course course = new Course();

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetCourseById";

                    cmd.Parameters.Add(new SqlParameter("@CourseId", courseId));

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        course = new Course()
                        {
                            CourseId = (int)dr["CourseId"],
                            Title = (string)dr["Title"],
                            Description = (string)dr["Description"]
                        };
                    }

                    dr.Close();
                }
            }

            return course;

        }

        public Course Add(Course item)
        {
            //throw new NotImplementedException();
            int id = -1;

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "InsertCourse";
                    cmd.Parameters.Add(new SqlParameter("@Title", item.Title));
                    cmd.Parameters.Add(new SqlParameter("@Description", item.Description));
                    cmd.Parameters.Add("@NewCourseId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@NewCourseId"].Value;

                }
            }

            Course course = this.Get(id);

            return course;

        }

        public void Remove(int courseId)
        {
            // throw new NotImplementedException();
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteCourse";

                    cmd.Parameters.Add(new SqlParameter("@CourseId", courseId));

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public bool Update(Course item)
        {
            //throw new NotImplementedException();
            int rowsUpdated = -1;

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateCourse";

                    cmd.Parameters.Add(new SqlParameter("@CourseId", item.CourseId));
                    cmd.Parameters.Add(new SqlParameter("@Title", item.Title));
                    cmd.Parameters.Add(new SqlParameter("@Description", item.Description));

                    conn.Open();

                    rowsUpdated = cmd.ExecuteNonQuery();
                }
            }

            bool test = (rowsUpdated > 0);

            return (rowsUpdated > 0);
        }

    }

}



