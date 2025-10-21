using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Ban_Caffee.Models
{
    public class DanhMuc
    {
        [JsonPropertyName("maDm")]
    public string? MaDm { get; set; }

    [JsonPropertyName("tenDm")]
    public string? TenDm { get; set; }

    [JsonPropertyName("loaiDm")]
    public string? LoaiDm { get; set; }

        [JsonPropertyName("sanphams")]
        public List<object> Sanphams { get; set; } = new List<object>();
    }
}