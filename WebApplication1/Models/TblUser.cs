using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("tblUser")]
    public partial class TblUser
    {
        public TblUser()
        {
            TblFeedback = new HashSet<TblFeedback>();
            TblProductDetail = new HashSet<TblProductDetail>();
        }

        [Key]
        [Column("userID")]
        public int UserId { get; set; }
        [Required]
        [Column("userName")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [Column("password")]
        [StringLength(64)]
        public string Password { get; set; }
        [Column("roleID")]
        public int RoleId { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("status")]
        public int Status { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty(nameof(TblRole.TblUser))]
        public virtual TblRole Role { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<TblFeedback> TblFeedback { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<TblProductDetail> TblProductDetail { get; set; }
    }
}
