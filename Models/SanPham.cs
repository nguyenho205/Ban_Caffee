using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ban_Caffee.Models
{
    public class SanPham
    {
        public int Id { get; set; }
        public string? TenSP { get; set; }
        public string? MoTa { get; set; }
        public decimal Gia { get; set; }
        public string? HinhAnh { get; set; }

    }
}