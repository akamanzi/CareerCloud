using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using ADODataAccessLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
	public class ApplicantSkillRepository: IDataRepository<ApplicantSkillPoco>
    {
		public ApplicantSkillRepository()
		{
		}

        public void Add(params ApplicantSkillPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Applicant_Skills(Id, Applicant, Skill, Skill_Level, Start_Month," +
                        "Start_Year, End_Month, End_Year)" +
                        "Values (@Id, @Applicant, @Skill, @Skill_Level, @Start_Month, @Start_Year, @End_Month,@End_Year)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Skill", item.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
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

        public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Applicant_Skills", conn)).ExecuteReader();

                var l = new List<ApplicantSkillPoco>();
                while (r.Read())
                {
                    l.Add(new ApplicantSkillPoco()
                    {
                        Id = (Guid)r["Id"],
                        Applicant = (Guid)r["Applicant"],
                        Skill = (String)r["Skill"],
                        SkillLevel = (String)r["Skill_Level"],
                        StartMonth = (Byte)r["Start_Month"],
                        StartYear = (Int32)r["Start_Year"],
                        EndMonth = (Byte)r["End_Month"],
                        EndYear = (Int32)r["End_Year"],
                        TimeStamp = (Byte[])r["Time_Stamp"],


                    });
                }
                return l;
            }
        }

        public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantSkillPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantSkillPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Applicant_Skills WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {

                var cmd = new SqlCommand();
                cmd.Connection = conn;


                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Applicant_Skills SET Skill = @Skill, Skill_Level = @Skill_Level," +
                        "Start_Month = @Start_Month, Start_Year = @Start_Year, End_Month = @End_Month, End_Year = @End_Year";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Skill", item.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
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

