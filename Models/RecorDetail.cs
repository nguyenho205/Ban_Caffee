using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ban_Caffee.Models;

[PrimaryKey("GoodId", "RecordsId")]
[Table("RecorDetail", Schema = "management")]
public partial class RecorDetail
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string GoodId { get; set; } = null!;

    public int Quantity { get; set; }

    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string RecordsId { get; set; } = null!;

    [ForeignKey("GoodId")]
    [InverseProperty("RecorDetails")]
    public virtual Good Good { get; set; } = null!;

    [ForeignKey("RecordsId")]
    [InverseProperty("RecorDetails")]
    public virtual Inventoryrecord Records { get; set; } = null!;
}
