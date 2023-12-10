using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using ADODataAccessLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
	public class SecurityLoginsRoleRepository: IDataRepository<SecurityLoginsRolePoco>
    {
		public SecurityLoginsRoleRepository()
		{
		}

        public void Add(params SecurityLoginsRolePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Security_Logins_Roles(Id, Login, Role) " +
                        "Values (@Id, @Login, @Role)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Role", item.Role);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Security_Logins_Roles", conn)).ExecuteReader();

                var l = new List<SecurityLoginsRolePoco>();
                while (r.Read())
                {
                    l.Add(new SecurityLoginsRolePoco()
                    {
                        Id = (Guid)r["Id"],
                        Login = (Guid)r["Login"],
                        Role = (Guid)r["Role"],
                        TimeStamp = Convert.IsDBNull(r["Time_Stamp"]) ? null : (Byte[]?)r["Time_Stamp"],
                    });
                }
                return l;
            }
        }

        public IList<SecurityLoginsRolePoco> GetList(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsRolePoco GetSingle(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsRolePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsRolePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Security_Logins_Roles WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void Update(params SecurityLoginsRolePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {

                var cmd = new SqlCommand();
                cmd.Connection = conn;


                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Security_Logins_Roles SET Role = @Role WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Role", item.Role);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }
    }
}

