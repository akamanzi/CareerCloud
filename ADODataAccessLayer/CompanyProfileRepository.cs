using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using ADODataAccessLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
	public class CompanyProfileRepository: IDataRepository<CompanyProfilePoco>
    {
		public CompanyProfileRepository()
		{
		}

        public void Add(params CompanyProfilePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Company_Profiles(Id, Registration_Date, Company_Website, Contact_Phone, " +
                        "Contact_Name, Company_Logo) " +
                        "Values (@Id, @Registration_Date, @Company_Website, @Contact_Phone, @Contact_Name, @Company_Logo)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Registration_Date", item.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website", item.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone", item.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name", item.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo", item.CompanyLogo);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Company_Profiles", conn)).ExecuteReader();

                var l = new List<CompanyProfilePoco>();
                while (r.Read())
                {
                    l.Add(new CompanyProfilePoco()
                    {
                        Id = (Guid)r["Id"],
                        RegistrationDate = (DateTime)r["Registration_Date"],
                        CompanyWebsite = Convert.IsDBNull(r["Company_Website"]) ? null : (String?)r["Company_Website"],
                        ContactPhone = (String)r["Contact_Phone"],
                        ContactName = Convert.IsDBNull(r["Contact_Name"]) ? null :  (String?)r["Contact_Name"],
                        CompanyLogo = Convert.IsDBNull(r["Company_Logo"]) ? null : (Byte[]?)r["Company_Logo"],
                        TimeStamp = Convert.IsDBNull(r["Time_Stamp"]) ? null : (Byte[]?)r["Time_Stamp"],
                    });;
                }
                return l;
            }
        }

        public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyProfilePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Company_Profiles WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {

                var cmd = new SqlCommand();
                cmd.Connection = conn;


                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Company_Profiles SET Registration_Date = @Registration_Date, " +
                        "Company_Website = @Company_Website, Contact_Phone = @Contact_Phone, Contact_Name = @Contact_Name," +
                        "Company_Logo = @Company_Logo WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Registration_Date", item.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website", item.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone", item.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name", item.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo", item.CompanyLogo);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }
    }
}

