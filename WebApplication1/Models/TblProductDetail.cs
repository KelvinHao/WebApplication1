using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("tblProductDetail")]
    public partial class TblProductDetail
    {
        [Key]
        [Column("prDetailID")]
        public int PrDetailId { get; set; }
        [Column("productID")]
        public int ProductId { get; set; }
        [Column("userID")]
        public int UserId { get; set; }
        [Column("dateBuy", TypeName = "date")]
        public DateTime DateBuy { get; set; }
        [Column("numBuy")]
        public int NumBuy { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(TblProduct.TblProductDetail))]
        public virtual TblProduct Product { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(TblUser.TblProductDetail))]
        public virtual TblUser User { get; set; }
    }
}
