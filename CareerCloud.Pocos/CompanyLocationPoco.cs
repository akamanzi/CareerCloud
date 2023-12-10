using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Company_Locations")]
	public class CompanyLocationPoco: IPoco
	{
		public CompanyLocationPoco()
		{
		}
        [Key]
        public Guid Id { get; set; }
        [Key]
        public Guid Company { get; set; }
        [Column("Country_Code")]
        public String CountryCode { get; set; }
        [Column("State_Province_Code")]
        public String? Province { get; set; }
        [Column("Street_Address")]
        public String? Street { get; set; }
        [Column("City_Town")]
        public String? City { get; set; }
        [Column("Zip_Postal_Code")]
        public String? PostalCode { get; set; }
        [Column("Time_Stamp")]
        public Byte[] TimeStamp { get; set; }
    }
}

