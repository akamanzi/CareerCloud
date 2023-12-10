using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using ADODataAccessLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
	public class SystemCountryCodeRepository: IDataRepository<SystemCountryCodePoco>
    {
        public SystemCountryCodeRepository()
		{
		}

        public void Add(params SystemCountryCodePoco[] items)
        {
           
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SystemCountryCodePoco item in items)
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into System_Country_Codes(Code, Name) " +
                        "Values (@Code, @Name)";
                    cmd.Parameters.AddWithValue("@Code", item.Code);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                
            };
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from System_Country_Codes", conn)).ExecuteReader();

                var l = new List<SystemCountryCodePoco>();
                while (r.Read())
                {
                    l.Add(new SystemCountryCodePoco()
                    {
                        Code = (String)r["Code"],
                        Name = (String)r["Name"],
                    });
                }
                return l;
            }
        }

        public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemCountryCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
           
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SystemCountryCodePoco item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from System_Country_Codes WHERE Code = @Code";
                    cmd.Parameters.AddWithValue("@Code", item.Code);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                
            };
        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {

                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SystemCountryCodePoco item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE System_Country_Codes SET Name = @Name WHERE Code=@Code";
                    cmd.Parameters.AddWithValue("@Code", item.Code);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                
            };
        }
    }
}

