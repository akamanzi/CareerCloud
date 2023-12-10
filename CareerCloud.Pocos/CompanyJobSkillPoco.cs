using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Job_Skills")]
	public class CompanyJobSkillPoco: IPoco
	{
		public CompanyJobSkillPoco()
		{
		}
        [Key]
        public Guid Id { get; set; }
        [Key]
        public Guid Job { get; set; }
        [Column("Skill")]
        public String Skill { get; set; }
        [Column("Skill_Level")]
        public String SkillLevel { get; set; }
        [Column("Importance")]
        public Int32 Importance { get; set; }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }
    }
}

