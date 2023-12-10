using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using ADODataAccessLayer;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
	public class CompanyJobDescriptionRepository: IDataRepository<CompanyJobDescriptionPoco>
    {
		public CompanyJobDescriptionRepository()
		{
		}

        public void Add(params CompanyJobDescriptionPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Insert into Company_Jobs_Descriptions(Id, Job, Job_Name, Job_Descriptions)" +
                        "Values (@Id, @Job, @Job_Name, @Job_Descriptions)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@Job_Name", item.JobName);
                    cmd.Parameters.AddWithValue("@Job_Descriptions", item.JobDescriptions);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                conn.Open();
                SqlDataReader r = (new SqlCommand("Select * from Company_Jobs_Descriptions", conn)).ExecuteReader();

                var l = new List<CompanyJobDescriptionPoco>();
                while (r.Read())
                {
                    l.Add(new CompanyJobDescriptionPoco()
                    {
                        Id = (Guid)r["Id"],
                        Job = (Guid)r["Job"],
                        JobName = (String)r["Job_Name"],
                        JobDescriptions = (String)r["Job_Descriptions"],
                        TimeStamp = Convert.IsDBNull(r["Time_Stamp"]) ? null : (Byte[]?)r["Time_Stamp"],
                     });;
                }
                return l;
            }
        }

        public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            IQueryable<CompanyJobDescriptionPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Remove(params CompanyJobDescriptionPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {
                var cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Delete from Company_Jobs_Descriptions WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            using (var conn = new SqlConnection(DBConnection.DataConnection))
            {

                var cmd = new SqlCommand();
                cmd.Connection = conn;


                foreach (var item in items)
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "UPDATE Company_Jobs_Descriptions SET Job_Name = @Job_Name, Job_Descriptions = @Job_Descriptions";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Job_Descriptions", item.JobDescriptions);
                    cmd.Parameters.AddWithValue("@Job_Name", item.JobName);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            };
        }
    }
}

