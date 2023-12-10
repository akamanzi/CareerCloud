using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using ADODataAccessLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
	public class CompanyLocationRepository: IDataRepository<CompanyLocationPoco>
    {
		public CompanyLocationRepository()
		{
		}

        public void Add(params CompanyLocationPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Company_Locations(Id, Company, Country_Code, State_Province_Code, " +
                        "Street_Address, City_Town, Zip_Postal_Code) " +
                        "Values (@Id, @Company, @Country_Code, @State_Province_Code, @Street_Address, @City_Town, @Zip_Postal_Code)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                    cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", item.Street);
                    cmd.Parameters.AddWithValue("@City_Town", item.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);
                    //cmd.Parameters.AddWithValue("@Time_Stamp", item.TimeStamp);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Company_Locations", conn)).ExecuteReader();

                var l = new List<CompanyLocationPoco>();
                while (r.Read())
                {
                    l.Add(new CompanyLocationPoco()
                    {
                        Id = (Guid)r["Id"],
                        Company = (Guid)r["Company"],
                        CountryCode = (String)r["Country_Code"],
                        Province = Convert.IsDBNull(r["State_Province_Code"]) ? null : (String?)r["State_Province_Code"],
                        Street = Convert.IsDBNull(r["Street_Address"]) ? null : (String?)r["Street_Address"],
                        City = Convert.IsDBNull(r["City_Town"]) ? null : (String?)r["City_Town"],
                        PostalCode = Convert.IsDBNull(r["Zip_Postal_Code"]) ? null : (String?)r["Zip_Postal_Code"],
                        TimeStamp = (Byte[])r["Time_Stamp"],  
                    });
                }
                return l;
            }
        }

        public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyLocationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyLocationPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Company_Locations WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void Update(params CompanyLocationPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {

                var cmd = new SqlCommand();
                cmd.Connection = conn;


                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Company_Locations SET Country_Code = @Country_Code, Company = @Company," +
                        "State_Province_Code = @State_Province_Code, Street_Address = @Street_Address, City_Town = @City_Town," +
                        "Zip_Postal_Code = @Zip_Postal_Code WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                    cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", item.Street);
                    cmd.Parameters.AddWithValue("@City_Town", item.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }
    }
}

