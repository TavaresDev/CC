using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CannabisChoice.Models
{
    public partial class Review
    {
        [Key]
        [Column("ReviewID")]
        public int ReviewId { get; set; }
        [Column("StrainID")]
        public int StrainId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        public string ReviewText { get; set; }
        public byte ReviewRate { get; set; }

        [ForeignKey(nameof(StrainId))]
        [InverseProperty(nameof(StrainInfo.Review))]
        public virtual StrainInfo Strain { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(Users.Review))]
        public virtual Users User { get; set; }
    }
}
