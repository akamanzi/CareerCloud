using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
	[Table("Applicant_Job_Applications")]
	public class ApplicantJobApplicationPoco: IPoco
	{
		public ApplicantJobApplicationPoco()
		{
		}
		[Key]
        public Guid Id { get; set; }
		[Key]
		public Guid Applicant { get; set; }
		[Key]
		public Guid Job { get; set; }
		[Column("Application_Date")]
		public DateTime ApplicationDate { get; set; }
		[Column("Time_Stamp")]
		public Byte[]? TimeStamp { get; set; }
    }

}

