using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("tblBrand")]
    public partial class TblBrand
    {
        public TblBrand()
        {
            TblProduct = new HashSet<TblProduct>();
        }

        [Key]
        [Column("brandID")]
        public int BrandId { get; set; }
        [Required]
        [Column("brandName")]
        [StringLength(50)]
        public string BrandName { get; set; }

        [InverseProperty("Brand")]
        public virtual ICollection<TblProduct> TblProduct { get; set; }
    }
}
