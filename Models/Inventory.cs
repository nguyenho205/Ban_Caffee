using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ban_Caffee.Models;

[Table("inventory", Schema = "management")]
public partial class Inventory
{
    [Key]
    public int InventoryId { get; set; }

    [StringLength(100)]
    public string Status { get; set; } = null!;

    [StringLength(100)]
    public string Addr { get; set; } = null!;

    [Column("StoreID")]
    [StringLength(10)]
    [Unicode(false)]
    public string StoreId { get; set; } = null!;

    [InverseProperty("Inventory")]
    public virtual ICollection<Inventoryrecord> Inventoryrecords { get; set; } = new List<Inventoryrecord>();

    [InverseProperty("Inventory")]
    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    [ForeignKey("StoreId")]
    [InverseProperty("Inventories")]
    public virtual Store Store { get; set; } = null!;
}
