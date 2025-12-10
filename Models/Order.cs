using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ban_Caffee.Models;

[Table("orders")]
public partial class Order
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string OrderId { get; set; } = null!;

    [StringLength(50)]
    public string Status { get; set; } = null!;

    public DateTime RecivingDate { get; set; }

    public DateTime UpdateStatusDate { get; set; }

    public DateTime? CompleteDate { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? CustomerId { get; set; }

    public int? SysUserId { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Orders")]
    public virtual Customer? Customer { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("SysUserId")]
    [InverseProperty("Orders")]
    public virtual Sysuser? SysUser { get; set; }
}
