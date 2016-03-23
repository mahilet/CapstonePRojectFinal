using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace JeffriesDataLibrary
{
    public class ResourcesService : IResourcesService

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

        public List<Resource> GetAll()
        {
            //throw new NotImplementedException();
            List<Resource> resources = new List<Resource>();

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetAllResources";

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Resource resource = new Resource()
                        {
                            ResourceId = (int)dr["ResourceId"],
                            CourseId = (int)dr["CourseId"],
                            FileName = (string)dr["FileName"],
                            FileType = (string)dr["FileType"],
                            FileBinary = (byte[])dr["FileBinary"]
                        };
                        resources.Add(resource);
                    }

                    dr.Close();
                }
            }

            return resources;
        }
        public Resource Get(int resourceId)
        {
            // throw new NotImplementedException();
            Resource resource = new Resource();

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetResourceById";

                    cmd.Parameters.Add(new SqlParameter("@ResourceId", resourceId));

                    conn.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        resource = new Resource()
                        {
                            ResourceId = (int)dr["ResourceId"],
                            FileName = (string)dr["FileName"],
                            FileType = (string)dr["FileType"],
                            FileBinary = (byte[])dr["FileBinary"]
                        };
                    }

                    dr.Close();
                }
            }

            return resource;


        }
        public Resource Add(Resource item)
        {
            //throw new NotImplementedException();
            int id = -1;

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "InsertResource";
                    cmd.Parameters.Add(new SqlParameter("@CourseId", item.CourseId));
                    cmd.Parameters.Add(new SqlParameter("@FileName", item.FileName));
                    cmd.Parameters.Add(new SqlParameter("@FileType", item.FileType));
                    cmd.Parameters.Add(new SqlParameter("@FileBinary", item.FileBinary));
                    cmd.Parameters.Add("@NewResourceId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@NewResourceId"].Value;

                }
            }

            Resource resource = this.Get(id);

            return resource;

        }
        public void Remove(int resourceId)
        {
            //throw new NotImplementedException();

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteResource";

                    cmd.Parameters.Add(new SqlParameter("@ResourceId", resourceId));

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public bool Update(Resource item)
        {
            //throw new NotImplementedException();

            int rowsUpdated = -1;

            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(string.Empty, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateResource";

                    cmd.Parameters.Add(new SqlParameter("@CourseId", item.CourseId));
                    cmd.Parameters.Add(new SqlParameter("@FileName", item.FileName));
                    cmd.Parameters.Add(new SqlParameter("@FileType", item.FileType));
                    cmd.Parameters.Add(new SqlParameter("@FileBinary", item.FileBinary));

                    conn.Open();

                    rowsUpdated = cmd.ExecuteNonQuery();
                }
            }

            bool test = (rowsUpdated > 0);

            return (rowsUpdated > 0);
        }

    }
}

 

