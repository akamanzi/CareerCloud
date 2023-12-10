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
	public class SecurityLoginRepository: IDataRepository<SecurityLoginPoco>
    {
		public SecurityLoginRepository()
		{
		}

        public void Add(params SecurityLoginPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Security_Logins(Id, Login, Password, Created_Date, Password_Update_Date, " +
                        "Agreement_Accepted_Date, Is_Locked, Is_Inactive, Email_Address, Phone_Number, Full_Name, Force_Change_Password," +
                        "Prefferred_Language) " +
                        "Values (@Id, @Login, @Password, @Created_Date, @Password_Update_Date, @Agreement_Accepted_Date, @Is_Locked, " +
                        "@Is_Inactive, @Email_Address, @Phone_Number, @Full_Name, @Force_Change_Password, @Prefferred_Language)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
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

        public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Security_Logins", conn)).ExecuteReader();

                var l = new List<SecurityLoginPoco>();
                while (r.Read())
                {
                    l.Add(new SecurityLoginPoco()
                    {
                        Id = (Guid)r["Id"],
                        Login = (String)r["Login"],
                        Password = (String)r["Password"],
                        Created = (DateTime)r["Created_Date"],
                        PasswordUpdate = Convert.IsDBNull(r["Password_Update_Date"]) ? null : (DateTime?)r["Password_Update_Date"],
                        AgreementAccepted = Convert.IsDBNull(r["Agreement_Accepted_Date"]) ? null : (DateTime?)r["Agreement_Accepted_Date"],
                        IsLocked = (Boolean)r["Is_Locked"],
                        IsInactive = (Boolean)r["Is_Inactive"],
                        EmailAddress = (String)r["Email_Address"],
                        PhoneNumber = Convert.IsDBNull(r["Phone_Number"]) ? null : (String?)r["Phone_Number"],
                        FullName = Convert.IsDBNull(r["Full_Name"]) ? null : (String?)r["Full_Name"],
                        ForceChangePassword = (Boolean)r["Force_Change_Password"],
                        PrefferredLanguage = Convert.IsDBNull(r["Prefferred_Language"]) ? null : (String?)r["Prefferred_Language"],
                        TimeStamp = (Byte[])r["Time_Stamp"],
                    });
                }
                return l;
            }
        }

        public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params SecurityLoginPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Security_Logins WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {

                var cmd = new SqlCommand();
                cmd.Connection = conn;


                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Security_Logins SET Login = @Login, Password = @Password, " +
                        "Created_Date = @Created_Date, Password_Update_Date = @Password_Update_Date, Agreement_Accepted_Date = @Agreement_Accepted_Date," +
                        "Is_Locked = @Is_Locked, Is_Inactive = @Is_Inactive, Email_Address = @Email_Address," +
                        "Phone_Number = @Phone_Number, Full_Name = @Full_Name, Force_Change_Password = @Force_Change_Password," +
                        "Prefferred_Language = @Prefferred_Language WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
                    //cmd.Parameters.AddWithValue("@Time_Stamp", item.TimeStamp);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }
    }
}

