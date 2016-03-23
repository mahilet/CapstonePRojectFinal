using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JeffriesDataLibrary
{
    public class RepliesService : IReplysService
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

        public List<Reply> GetAll()
        {
            //throw new NotImplementedException();

            List<Reply> replys = new List<Reply>();

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetAllReplies";

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Reply reply = new Reply();
                        {
                            reply.ReplyId = (int)dr["ReplyId"];
                            reply.CommentId = (int)dr["CommentId"];
                            reply.Name = (string)dr["Name"];
                            reply.Text = (string)dr["Text"];
                            reply.DateReplied = (DateTime)dr["DateReplied"];

                        };
                        replys.Add(reply);
                    }

                    dr.Close();
                }
            }

            return replys;
        }

        public Reply Get(int replyId)
        {
            //throw new NotImplementedException();
            Reply reply = new Reply();

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetReplyById";

                    cmd.Parameters.Add(new SqlParameter("@ReplyId", replyId));

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        reply = new Reply()
                        {
                            ReplyId = (int)dr["ReplyId"],
                            CommentId = (int)dr["CommentId"],
                            Name = (string)dr["Name"],
                            Text = (string)dr["Text"],
                            DateReplied = (DateTime)dr["DateReplied"]
                        };
                    }

                    dr.Close();
                }
            }

            return reply;
        }

        public Reply Add(Reply item)
        {
            // throw new NotImplementedException();

            int id = -1;

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "InsertReply";

                    cmd.Parameters.Add(new SqlParameter("@CommentId", item.CommentId));
                    cmd.Parameters.Add(new SqlParameter("@Name", item.Name));
                    cmd.Parameters.Add(new SqlParameter("@Text", item.Text));
                    cmd.Parameters.Add(new SqlParameter("@DateReplied", item.DateReplied));
                    cmd.Parameters.Add("@NewReplyId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@NewReplyId"].Value;

                }
            }

            Reply reply = this.Get(id);

            return reply;

        }

        public void Remove(int replyId)
        {
            //throw new NotImplementedException();
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteReply";

                    cmd.Parameters.Add(new SqlParameter("@ReplyId", replyId));

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }



        }

        public bool Update(Reply item)
        {
            //throw new NotImplementedException();
            int rowsUpdated = -1;

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateReply";

                    cmd.Parameters.Add(new SqlParameter("@ReplyId", item.ReplyId));
                    cmd.Parameters.Add(new SqlParameter("@CommentId", item.CommentId));
                    cmd.Parameters.Add(new SqlParameter("@Name", item.Name));
                    cmd.Parameters.Add(new SqlParameter("@Text", item.Text));
                    cmd.Parameters.Add(new SqlParameter("@DateReplied", item.DateReplied));

                    conn.Open();

                    rowsUpdated = cmd.ExecuteNonQuery();
                }
            }

            bool test = (rowsUpdated > 0);

            return (rowsUpdated > 0);
        

    }
    }
}
