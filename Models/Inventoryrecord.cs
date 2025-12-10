using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ban_Caffee.Models;

[Table("inventoryrecord", Schema = "management")]
public partial class Inventoryrecord
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string RecordsId { get; set; } = null!;

    public DateTime AdmissionDate { get; set; }

    public int InventoryId { get; set; }

    public int TypeId { get; set; }

    [ForeignKey("InventoryId")]
    [InverseProperty("Inventoryrecords")]
    public virtual Inventory Inventory { get; set; } = null!;

    [InverseProperty("Records")]
    public virtual ICollection<RecorDetail> RecorDetails { get; set; } = new List<RecorDetail>();

    [ForeignKey("TypeId")]
    [InverseProperty("Inventoryrecords")]
    public virtual Recordtype Type { get; set; } = null!;
}
