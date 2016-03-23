using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace JeffriesDataLibrary
{
    public class VBlogsService : IVBlogsService

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
        
        public List<VBlog> GetAll()
        {
           // throw new NotImplementedException();

            List<VBlog> vBlogs = new List<VBlog>();

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetAllVBlogs";

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        VBlog vBlog = new VBlog();
                        {

                        vBlog.VBlogId = (int)dr["VBlogId"];
                        vBlog.Title = (string)dr["Title"];
                        vBlog.Description = (string)dr["Description"];
                        vBlog.FileName = (string)dr["FileName"];
                        vBlog.FileType = (string)dr["FileType"];
                        vBlog.FileBinary = (byte[])dr["FileBinary"];
                        vBlog.DatePosted = (DateTime)dr["DatePosted"];
                        vBlog.IndexOrder = (int)dr["IndexOrder"];
                    };
                        vBlogs.Add(vBlog);
                    }

                    dr.Close();
                }
            }

            return vBlogs;
        }

        public VBlog Get(int vBlogId)
        {
            // throw new NotImplementedException();

            VBlog vBlog = new VBlog();

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetVBlogById"; 

                    cmd.Parameters.Add(new SqlParameter("@VBlogId", vBlogId)); 

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())

                    {
                        vBlog = new VBlog()
                        {
                            VBlogId = (int)dr["VBlogId"],
                            Title = (string)dr["Title"],
                            Description = (string)dr["Description"],
                            FileName = (string)dr["FileName"],
                            FileType = (string)dr["FileType"],
                            FileBinary = (byte[])dr["FileBinary"],
                            DatePosted = (DateTime)dr["DatePosted"],
                            IndexOrder=(int)dr["IndexOrder"]
                        };
                    }

                    dr.Close();
                }
            }

            return vBlog;


        }


        public VBlog Add(VBlog item)
        {
            // throw new NotImplementedException();

            int id = -1;

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "InsertVBlog";


                    cmd.Parameters.Add(new SqlParameter("@Title", item.Title));
                    cmd.Parameters.Add(new SqlParameter("@Description", item.Description));
                    cmd.Parameters.Add(new SqlParameter("@FileName", item.FileName));
                    cmd.Parameters.Add(new SqlParameter("@FileType", item.FileType));
                    cmd.Parameters.Add(new SqlParameter("@FileBinary", item.FileBinary));
                    cmd.Parameters.Add(new SqlParameter("@DatePosted", item.DatePosted));
                    cmd.Parameters.Add(new SqlParameter("@IndexOrder", item.IndexOrder));
                    cmd.Parameters.Add("@NewVBlogId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@NewVBlogId"].Value;

                }
            }

            VBlog vBlog = this.Get(id);

            return vBlog;

        }


       public void Remove(int vBlogId)
        {
         
            //throw new NotImplementedException();
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteVBlog";

                    cmd.Parameters.Add(new SqlParameter("@VBlogId", vBlogId));

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }


       public bool Update(VBlog item)
        {
            //throw new NotImplementedException();

            int rowsUpdated = -1;

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateVBlog";

                    cmd.Parameters.Add(new SqlParameter("@VBlogId", item.VBlogId));
                    cmd.Parameters.Add(new SqlParameter("@Title", item.Title));
                    cmd.Parameters.Add(new SqlParameter("@Description", item.Description));
                    cmd.Parameters.Add(new SqlParameter("@FileName", item.FileName));
                    cmd.Parameters.Add(new SqlParameter("@FileType", item.FileType));
                    cmd.Parameters.Add(new SqlParameter("@FileBinary", item.FileBinary));
                    cmd.Parameters.Add(new SqlParameter("@DatePosted", item.DatePosted));
                    cmd.Parameters.Add(new SqlParameter("@IndexOrder", item.IndexOrder));

                    conn.Open();

                    rowsUpdated = cmd.ExecuteNonQuery();
                }
            }

            bool test = (rowsUpdated > 0);

            return (rowsUpdated > 0);
        }


    }
}
