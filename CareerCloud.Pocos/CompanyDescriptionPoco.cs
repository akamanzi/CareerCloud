using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CareerCloud.Pocos
{
	[Table("Company_Descriptions")]
	public class CompanyDescriptionPoco: IPoco
	{
		public CompanyDescriptionPoco()
		{
		}
		[Key]
        public Guid Id { get; set; }
		[Key]
		public Guid Company { get; set; }
		[Column("LanguageId")]
		public String LanguageId { get; set; }
		[Column("Company_Name")]
		public String CompanyName { get; set; }
		[Column("Company_Description")]
		public String CompanyDescription { get; set; }
		[Column("Time_Stamp")]
		public Byte[] TimeStamp { get; set; }
    }
}

