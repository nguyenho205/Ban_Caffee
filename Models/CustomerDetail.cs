using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ban_Caffee.Models;

[Table("CustomerDetail", Schema = "customers")]
[Index("Email", Name = "UQ__Customer__A9D10534A3242BC3", IsUnique = true)]
[Index("PhoneNum", Name = "UQ__Customer__DF8F1A02E2FF0904", IsUnique = true)]
[Index("Email", Name = "Unique_Email", IsUnique = true)]
[Index("PhoneNum", Name = "Unique_PhoneNum", IsUnique = true)]
public partial class CustomerDetail
{
    [Key]
    [StringLength(10)]
    [Unicode(false)]
    public string CustomerId { get; set; } = null!;

    [StringLength(50)]
    public string? FullName { get; set; }

    [StringLength(11)]
    [Unicode(false)]
    public string? IdNumber { get; set; }

    [StringLength(5)]
    public string? Gender { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? PhoneNum { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(500)]
    public string Avatar { get; set; } = null!;

    [StringLength(100)]
    public string? Addr { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("CustomerDetail")]
    public virtual Customer Customer { get; set; } = null!;
}
