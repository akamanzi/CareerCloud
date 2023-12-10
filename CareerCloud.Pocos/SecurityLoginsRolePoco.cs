using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
    [Table("Security_Logins_Roles")]
	public class SecurityLoginsRolePoco: IPoco
	{
		public SecurityLoginsRolePoco()
		{
		}
        [Key]
        public Guid Id { get; set; }
        [Key]
        public Guid Login { get; set; }
        [Key]
        public Guid Role { get; set; }
        [Column("Time_Stamp")]
        public Byte[]? TimeStamp { get; set; }
    }
}

