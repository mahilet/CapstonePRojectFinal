using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JeffriesDataLibrary
{
    public class CommentsService : ICommentsService
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


        public List<Comment> GetAll()
        {
            //throw new NotImplementedException();
            List<Comment> comments = new List<Comment>();
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetAllComments";

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Comment comment = new Comment();
                        //{
                        //    CommentId = (int)dr["CommentId"],
                        //    CourseId = (int)dr["CourseId "],
                        //    Text = (string)dr["Text"],
                        //    Name = (string)dr["Name"],
                        //    DatePosted = (DateTime)dr["DatePosted"]

                        //};

                        comment.CommentId = (int)dr["CommentId"];
                        comment.CourseId = (int)dr["CourseId"];
                        comment.Text = (string)dr["Text"];
                        comment.Name = (string)dr["Name"];
                        comment.DatePosted = (DateTime)dr["DatePosted"];




                        comments.Add(comment);
                    }

                    dr.Close();
                }
            }

            return comments;
        }


        public Comment Get(int CommentId)
        {
            //throw new NotImplementedException();
            Comment comment = new Comment();

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetCommentById";

                    cmd.Parameters.Add(new SqlParameter("@CommentId", CommentId));

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        comment = new Comment()
                        {
                            CommentId = (int)dr["commentId"],
                            CourseId = (int)dr["courseId"],
                            Text = (string)dr["text"],
                            Name = (string)dr["name"],
                            DatePosted = (DateTime)dr["datePosted"]
                        };
                    }

                    dr.Close();
                }
            }

            return comment;

        }

        public Comment Add(Comment item)
        {

            //throw new NotImplementedException();

            int id = -1;

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "InsertComment";

                    cmd.Parameters.Add(new SqlParameter("@CourseId", item.CourseId));
                    cmd.Parameters.Add(new SqlParameter("@Text", item.Text));
                    cmd.Parameters.Add(new SqlParameter("@Name", item.Name));
                    cmd.Parameters.Add(new SqlParameter("@DatePosted", item.DatePosted));
                    cmd.Parameters.Add("@NewCommentId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@NewCommentId"].Value;


                }
            }

            Comment comment = this.Get(id);

            return comment;

        }


        public void Remove(int commentId)
        {
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteComment";

                    cmd.Parameters.Add(new SqlParameter("@CommentId", commentId));

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }


        public bool Update(Comment item) { 
        int rowsUpdated = -1;

            using (conn) {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn)) {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateComment";

                    cmd.Parameters.Add(new SqlParameter("@CommentId", item.CommentId));
                    cmd.Parameters.Add(new SqlParameter("@CourseId", item.CourseId));
                    cmd.Parameters.Add(new SqlParameter("@Text", item.Text));
                    cmd.Parameters.Add(new SqlParameter("@Name", item.Name));
                    cmd.Parameters.Add(new SqlParameter("@DatePosted", item.DatePosted));

                    conn.Open();

                    rowsUpdated = cmd.ExecuteNonQuery();
                }
            }

            bool test = (rowsUpdated > 0);

            return (rowsUpdated > 0);
        }


    }

}


    


