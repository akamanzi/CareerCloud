using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using ADODataAccessLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository: IDataRepository<ApplicantEducationPoco>
        
	{
        
        public ApplicantEducationRepository()
		{
		}

        public void Add(params ApplicantEducationPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Applicant_Educations(Id, Applicant, Major, Certificate_Diploma, Start_Date," +
                        "Completion_Date, Completion_Percent)" +
                        "Values (@Id, @Applicant, @Major, @Certificate_Diploma, @Start_Date, @Completion_Date, @Completion_Percent)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", item.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", item.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", item.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", item.CompletionPercent);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            };
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Applicant_Educations", conn)).ExecuteReader();

                var l = new List<ApplicantEducationPoco>();
                while (r.Read())
                {
                    l.Add(new ApplicantEducationPoco()
                    {
                        Id = (Guid)r["Id"],
                        Applicant = (Guid)r["Applicant"],
                        Major = (String)r["Major"],
                        CertificateDiploma = (String)r["Certificate_Diploma"],
                        StartDate = Convert.IsDBNull(r["Start_Date"]) ? null : (DateTime?)r["Start_Date"],
                        CompletionDate = Convert.IsDBNull(r["Completion_Date"]) ? null : (DateTime?)r["Completion_Date"],
                        CompletionPercent = Convert.IsDBNull(r["Completion_Percent"]) ? null : (Byte?)r["Completion_Percent"],
                        TimeStamp = Convert.IsDBNull(r["Time_Stamp"]) ? null : (Byte[]?)r["Time_Stamp"]
                    });
                }
                return l;
            }
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Applicant_Educations WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {

                var cmd = new SqlCommand();
                cmd.Connection = conn;


                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Applicant_Educations SET Major = @Major, Certificate_Diploma = @Certificate_Diploma," +
                        "Start_Date = @Start_Date, Completion_Date = @Completion_Date, Completion_Percent = @Completion_Percent" +
                        " WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", item.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", item.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", item.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", item.CompletionPercent);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }
    }
}

