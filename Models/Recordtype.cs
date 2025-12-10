using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ban_Caffee.Models;

[Table("recordtype", Schema = "management")]
public partial class Recordtype
{
    [Key]
    public int TypeId { get; set; }

    [StringLength(100)]
    public string TypeName { get; set; } = null!;

    [InverseProperty("Type")]
    public virtual ICollection<Inventoryrecord> Inventoryrecords { get; set; } = new List<Inventoryrecord>();
}
