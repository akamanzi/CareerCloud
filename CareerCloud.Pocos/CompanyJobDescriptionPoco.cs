using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Jobs_Descriptions")]
	public class CompanyJobDescriptionPoco: IPoco
	{
		public CompanyJobDescriptionPoco()
		{
		}
        [Key]
        public Guid Id { get; set; }
        [Key]
        public Guid Job { get; set; }
        [Column("Job_Name")]
        public String? JobName { get; set; }
        [Column("Job_Descriptions")]
        public String? JobDescriptions { get; set; }
        [Column("Time_Stamp")]
        public Byte[]? TimeStamp { get; set; }
    }
}

