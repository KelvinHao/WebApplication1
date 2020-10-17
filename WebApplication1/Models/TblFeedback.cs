using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("tblFeedback")]
    public partial class TblFeedback
    {
        [Key]
        [Column("feedbackID")]
        public int FeedbackId { get; set; }
        [Column("userID")]
        public int UserId { get; set; }
        [Column("productID")]
        public int ProductId { get; set; }
        [Column("rating")]
        public int Rating { get; set; }
        [Required]
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }
        [Column("feedbackDate", TypeName = "date")]
        public DateTime FeedbackDate { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(TblProduct.TblFeedback))]
        public virtual TblProduct Product { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(TblUser.TblFeedback))]
        public virtual TblUser User { get; set; }
    }
}
