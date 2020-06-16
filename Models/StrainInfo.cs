using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CannabisChoice.Models
{
    public partial class StrainInfo
    {
        public StrainInfo()
        {
            Review = new HashSet<Review>();
        }

        [Key]
        [Column("StrainID")]
        public int StrainId { get; set; }
        [Column("SName")]
        [StringLength(50)]
        public string Sname { get; set; }
        [Column("THC")]
        public int? Thc { get; set; }
        [Column("CBD")]
        public int? Cbd { get; set; }
        [StringLength(10)]
        public string Terpenes { get; set; }
        [Column(TypeName = "image")]
        public byte[] Pic { get; set; }
        public string Effects { get; set; }

        [InverseProperty("Strain")]
        public virtual ICollection<Review> Review { get; set; }
    }
}
