using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using ADODataAccessLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
	public class ApplicantProfileRepository: IDataRepository<ApplicantProfilePoco>
	{
		public ApplicantProfileRepository()
		{
		}

        public void Add(params ApplicantProfilePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Applicant_Profiles(Id, Login, Current_Salary, Current_Rate, Currency," +
                        "Country_Code, State_Province_Code, Street_Address, City_Town, Zip_Postal_Code)" +
                        "Values (@Id, @Login, @Current_Salary, @Current_Rate, @Currency, @Country_Code, @State_Province_Code," +
                        "@Street_Address, @City_Town, @Zip_Postal_Code)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", item.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", item.Country);
                    cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", item.Street);
                    cmd.Parameters.AddWithValue("@City_Town", item.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            };
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Applicant_Profiles", conn)).ExecuteReader();

                var l = new List<ApplicantProfilePoco>();
                while (r.Read())
                {
                    l.Add(new ApplicantProfilePoco()
                    {
                        Id = (Guid)r["Id"],
                        Login = (Guid)r["Login"],
                        CurrentSalary = (Decimal?)r["Current_Salary"],
                        CurrentRate = (Decimal?)r["Current_Rate"],
                        Currency = Convert.IsDBNull(r["Currency"]) ? null : (String?)r["Currency"],
                        Country = Convert.IsDBNull(r["Country_Code"]) ? null : (String?)r["Country_Code"],
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

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Applicant_Profiles WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {

                var cmd = new SqlCommand();
                cmd.Connection = conn;


                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Applicant_Profiles SET Current_Salary = @Current_Salary, Current_Rate = @Current_Rate, " +
                        "Currency = @Currency, State_Province_Code = @State_Province_Code, Street_Address = @Street_Address," +
                        "City_Town = @City_Town, Zip_Postal_Code = @Zip_Postal_Code WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", item.Currency);
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
