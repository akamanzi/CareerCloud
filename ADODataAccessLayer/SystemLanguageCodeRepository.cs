using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using ADODataAccessLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
	public class SystemLanguageCodeRepository: IDataRepository<SystemLanguageCodePoco>
    {
		public SystemLanguageCodeRepository()
		{
		}

        public void Add(params SystemLanguageCodePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                
                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into System_Language_Codes(LanguageID,Name, Native_Name) " +
                        "Values (@LanguageID, @Name, @Native_Name)";
                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.Parameters.AddWithValue("@Native_Name", item.NativeName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                
            };
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from System_Language_Codes", conn)).ExecuteReader();

                var l = new List<SystemLanguageCodePoco>();
                while (r.Read())
                {
                    l.Add(new SystemLanguageCodePoco()
                    {
                        LanguageID = (String)r["LanguageID"],
                        Name = (String)r["Name"],
                        NativeName = (String)r["Native_Name"],
                    });
                }
                return l;
            }
        }

        public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                
                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from System_Language_Codes WHERE LanguageID = @LanguageID";
                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                
            };
        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                

                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE System_Language_Codes SET Name = @Name, Native_Name = @Native_Name WHERE LanguageID = @LanguageID";
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.Parameters.AddWithValue("@Native_Name", item.NativeName);
                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                
            };
        }
    }
}

