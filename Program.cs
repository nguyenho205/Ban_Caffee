using Ban_Caffee.Models;
using Ban_Caffee.Services;
using Microsoft.EntityFrameworkCore; // 1. BẮT BUỘC THÊM DÒNG NÀY
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// --- PHẦN 1: CẤU HÌNH DATABASE (Fix lỗi Unable to resolve service) ---
var connectionString = "Server=Khang\\SQLEXPRESS;Database=StoreManageMent;User Id=sa;Password=04022005;TrustServerCertificate=True;";
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));

// --- PHẦN 2: CẤU HÌNH JSON (Code cũ của bạn) ---
// Đăng ký HttpClient
builder.Services.AddHttpClient<ICustomerAuthService, CustomerAuthService>(client =>
{
    client.BaseAddress = new Uri("https://your-api-domain.com");
});

// Xử lý đọc file JSON (Lưu ý: Cần chắc chắn file này tồn tại để không bị lỗi)
try 
{
    string webRootPath = builder.Environment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
    string jsonFilePath = Path.Combine(webRootPath, "json", "danhmuc.json");

    if (File.Exists(jsonFilePath))
    {
        string jsonText = File.ReadAllText(jsonFilePath);
        var danhMucList = JsonSerializer.Deserialize<List<DanhMuc>>(jsonText);

        if (danhMucList != null)
        {
            builder.Services.AddSingleton(danhMucList);
        }
    }
    else
    {
        // Nếu không tìm thấy file, đăng ký list rỗng để web không bị sập
        builder.Services.AddSingleton(new List<DanhMuc>());
    }
}
catch (Exception ex)
{
    // Log lỗi nếu cần thiết, đăng ký list rỗng để an toàn
    builder.Services.AddSingleton(new List<DanhMuc>());
}

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();