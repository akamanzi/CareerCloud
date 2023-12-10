using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
	[Table("Applicant_Resumes")]
	public class ApplicantResumePoco: IPoco
	{
		public ApplicantResumePoco()
		{
		}
		[Key]
        public Guid Id { get; set; }
		[Key]
		public Guid Applicant { get; set; }
		[Column("Resume")]
		public String Resume { get; set; }
		[Column("Last_Updated")]
		public DateTime? LastUpdated { get; set; }


    }

}

