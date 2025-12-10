using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ban_Caffee.Models;

[Table("Customer", Schema = "customers")]
[Index("UserName", Name = "Unique_UserName", IsUnique = true)]
public partial class Customer
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string CustomerId { get; set; } = null!;

    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [StringLength(100)]
    public string Password { get; set; } = null!;

    [StringLength(50)]
    public string Status { get; set; } = null!;

    [InverseProperty("Customer")]
    public virtual CustomerDetail? CustomerDetail { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
