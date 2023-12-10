using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using ADODataAccessLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
	public class SecurityLoginsLogRepository: IDataRepository<SecurityLoginsLogPoco>
    {
		public SecurityLoginsLogRepository()
		{
		}

        public void Add(params SecurityLoginsLogPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Security_Logins_Log(Id, Login, Source_IP, Logon_Date, Is_Succesful) " +
                        "Values (@Id, @Login, @Source_IP, @Logon_Date, @Is_Succesful)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Is_Succesful", item.IsSuccesful);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Source_IP", item.SourceIP);
                    cmd.Parameters.AddWithValue("@Logon_Date", item.LogonDate);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Security_Logins_Log", conn)).ExecuteReader();

                var l = new List<SecurityLoginsLogPoco>();
                while (r.Read())
                {
                    l.Add(new SecurityLoginsLogPoco()
                    {
                        Id = (Guid)r["Id"],
                        Login = (Guid)r["Login"],
                        SourceIP = (String)r["Source_IP"],
                        LogonDate = (DateTime)r["Logon_Date"],
                        IsSuccesful = (Boolean)r["Is_Succesful"],
                    });
                }
                return l;
            }
        }

        public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginsLogPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Security_Logins_Log WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {

                var cmd = new SqlCommand();
                cmd.Connection = conn;


                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Security_Logins_Log SET Source_IP = @Source_IP, Logon_Date = @Logon_Date, Is_Succesful = @Is_Succesful WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Source_IP", item.SourceIP);
                    cmd.Parameters.AddWithValue("@Logon_Date", item.LogonDate);
                    cmd.Parameters.AddWithValue("@Is_Succesful", item.IsSuccesful);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }
    }
}

