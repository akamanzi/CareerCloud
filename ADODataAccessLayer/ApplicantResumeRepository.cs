using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using ADODataAccessLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
	public class ApplicantResumeRepository: IDataRepository<ApplicantResumePoco>
    {
		public ApplicantResumeRepository()
		{
		}

        public void Add(params ApplicantResumePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Applicant_Resumes(Id, Applicant, Resume, Last_Updated)" +
                        "Values (@Id, @Applicant, @Resume, @Last_Updated)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Resume", item.Resume);
                    cmd.Parameters.AddWithValue("@Last_Updated", item.LastUpdated);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            };
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Applicant_Resumes", conn)).ExecuteReader();

                var l = new List<ApplicantResumePoco>();
                while (r.Read())
                {
                    l.Add(new ApplicantResumePoco()
                    {
                        Id = (Guid)r["Id"],
                        Applicant = (Guid)r["Applicant"],
                        Resume = (String)r["Resume"],
                        LastUpdated = Convert.IsDBNull(r["Last_Updated"]) ? null : (DateTime?)r["Last_Updated"],

                    });
                }
                return l;
            }
        }

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantResumePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Applicant_Resumes WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {

                var cmd = new SqlCommand();
                cmd.Connection = conn;


                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Applicant_Resumes SET Resume = @Resume, Last_Updated = @Last_Updated " +
                        "WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Resume", item.Resume);
                    cmd.Parameters.AddWithValue("@Last_Updated", item.LastUpdated);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }
    }
}

