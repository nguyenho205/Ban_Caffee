using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ban_Caffee.Models;

[PrimaryKey("InventoryId", "GoodId")]
[Table("Stock", Schema = "management")]
public partial class Stock
{
    [Key]
    public int InventoryId { get; set; }

    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string GoodId { get; set; } = null!;

    [StringLength(100)]
    public string Status { get; set; } = null!;

    public int InStock { get; set; }

    [ForeignKey("GoodId")]
    [InverseProperty("Stocks")]
    public virtual Good Good { get; set; } = null!;

    [ForeignKey("InventoryId")]
    [InverseProperty("Stocks")]
    public virtual Inventory Inventory { get; set; } = null!;
}
