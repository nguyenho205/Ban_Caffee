using Ban_Caffee.Models;
using Ban_Caffee.Services;
using System.Text.Json;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<ICustomerAuthService, CustomerAuthService>(client =>
{
    client.BaseAddress = new Uri("https://your-api-domain.com");
});

// 1. Lấy đường dẫn đến thư mục wwwroot
string webRootPath = builder.Environment.WebRootPath;

// 2. Kết hợp với đường dẫn con "json" và tên file
string jsonFilePath = Path.Combine(webRootPath, "json", "danhmuc.json");

// Đoạn code mới trong Program.cs
string jsonText = File.ReadAllText(jsonFilePath);
var danhMucList = JsonSerializer.Deserialize<List<DanhMuc>>(jsonText);

// Thêm kiểm tra null tại đây!
if (danhMucList == null)
{
    // Hoặc là đăng ký một danh sách rỗng, hoặc là báo lỗi
    throw new InvalidOperationException("Không thể đọc và chuyển đổi tệp danhmuc.json.");
    // Hoặc: danhMucList = new List<DanhMuc>();
}

builder.Services.AddSingleton(danhMucList);

//Đăng ký List<DanhMuc> này làm dịch vụ Singleton
builder.Services.AddSingleton(danhMucList);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
