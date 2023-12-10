using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
    [Table("Company_Job_Educations")]
	public class CompanyJobEducationPoco: IPoco
	{
		public CompanyJobEducationPoco()
		{
		}
        [Key]
        public Guid Id { get; set; }
        [Key]
        public Guid Job { get; set; }
        [Column("Major")]
        public String Major { get; set; }
        [Column("Importance")]
        public Int16 Importance { get; set; }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }
    }
}

