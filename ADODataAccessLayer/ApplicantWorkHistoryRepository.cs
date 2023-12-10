using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using ADODataAccessLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
	public class ApplicantWorkHistoryRepository: IDataRepository<ApplicantWorkHistoryPoco>
    {
		public ApplicantWorkHistoryRepository()
		{
		}

        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Applicant_Work_History(Id, Applicant, Company_Name, Country_Code, " +
                        "Location, Job_Title, Job_Description, Start_Month, Start_Year, End_Month, End_Year)" +
                        "Values (@Id, @Applicant, @Company_Name, @Country_Code, @Location, @Job_Title, @Job_Description," +
                        "@Start_Month, @Start_Year, @End_Month, @End_Year)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", item.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", item.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", item.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", item.EndYear);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Applicant_Work_History", conn)).ExecuteReader();

                var l = new List<ApplicantWorkHistoryPoco>();
                while (r.Read())
                {
                    l.Add(new ApplicantWorkHistoryPoco()
                    {
                        Id = (Guid)r["Id"],
                        Applicant = (Guid)r["Applicant"],
                        CompanyName = (String)r["Company_Name"],
                        CountryCode = (String)r["Country_Code"],
                        Location = (String)r["Location"],
                        JobTitle = (String)r["Job_Title"],
                        JobDescription = (String)r["Job_Description"],
                        StartMonth = (Int16)r["Start_Month"],
                        StartYear = (Int32)r["Start_Year"],
                        EndMonth = (Int16)r["End_Month"],
                        EndYear = (Int32)r["End_Year"],
                        TimeStamp = (Byte[])r["Time_Stamp"],

                    });
                }
                return l;
            }
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Applicant_Work_History WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {

                var cmd = new SqlCommand();
                cmd.Connection = conn;


                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Applicant_Work_History SET Company_Name = @Company_Name," +
                        "Location = @Location, Job_Title = @Job_Title, Job_Description = @Job_Description, Start_Month = @Start_Month," +
                        "Start_Year = @Start_Year, End_Month = @End_Month, End_Year = @End_Year";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                    //cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", item.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", item.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", item.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", item.EndYear);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }
    }
}

