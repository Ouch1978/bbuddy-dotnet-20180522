namespace GOOS_Sample.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Budget
    {
        public decimal Amount { get; set; }

        [Key]
        [StringLength(7)]
        public string YearMonth { get; set; }
    }
}
