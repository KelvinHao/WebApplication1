using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("tblRole")]
    public partial class TblRole
    {
        public TblRole()
        {
            TblUser = new HashSet<TblUser>();
        }

        [Key]
        [Column("roleID")]
        public int RoleId { get; set; }
        [Required]
        [Column("roleName")]
        [StringLength(10)]
        public string RoleName { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<TblUser> TblUser { get; set; }
    }
}
