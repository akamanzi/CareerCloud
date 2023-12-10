using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Security_Roles")]
	public class SecurityRolePoco: IPoco
	{
		public SecurityRolePoco()
		{
		}
        [Key]
        public Guid Id { get; set; }
        [Column("Role")]
        public String Role { get; set; }
        [Column("Is_Inactive")]
        public Boolean IsInactive { get; set; }
    }
}

