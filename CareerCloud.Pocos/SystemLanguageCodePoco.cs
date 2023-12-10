using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("System_Language_Codes")]
	public class SystemLanguageCodePoco
	{
		public SystemLanguageCodePoco()
		{
		}
        [Key]
        public String LanguageID { get; set; }
        [Column("Name")]
        public String Name { get; set; }
        [Column("Native_Name")]
        public String NativeName { get; set; }
    }
}

