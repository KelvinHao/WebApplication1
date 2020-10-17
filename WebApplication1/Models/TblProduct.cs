using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("tblProduct")]
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblFeedback = new HashSet<TblFeedback>();
            TblProductDetail = new HashSet<TblProductDetail>();
        }

        [Key]
        [Column("productID")]
        public int ProductId { get; set; }
        [Required]
        [Column("productName")]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Column("brandID")]
        public int BrandId { get; set; }
        [Column("unitPrice")]
        public int UnitPrice { get; set; }
        [Required]
        [Column("icon")]
        public byte[] Icon { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }

        [ForeignKey(nameof(BrandId))]
        [InverseProperty(nameof(TblBrand.TblProduct))]
        public virtual TblBrand Brand { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<TblFeedback> TblFeedback { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<TblProductDetail> TblProductDetail { get; set; }
    }
}
