using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("System_Country_Codes")]
	public class SystemCountryCodePoco
	{
		public SystemCountryCodePoco()
		{
		}
        [Key]
        public String Code { get; set; }
        [Column("Name")]
        public String Name { get; set; }
    }
}

