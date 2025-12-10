using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ban_Caffee.Models;

[Table("goods", Schema = "management")]
public partial class Good
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string GoodId { get; set; } = null!;

    [StringLength(100)]
    public string GoodName { get; set; } = null!;

    [StringLength(20)]
    public string UnitName { get; set; } = null!;

    [InverseProperty("Good")]
    public virtual ICollection<RecorDetail> RecorDetails { get; set; } = new List<RecorDetail>();

    [InverseProperty("Good")]
    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
