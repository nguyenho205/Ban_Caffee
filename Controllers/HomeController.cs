using Ban_Caffee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore; 

namespace Ban_Caffee.Controllers;

public class HomeController : Controller
{
    
    private readonly ILogger<HomeController> _logger;
    private readonly MyDbContext _context;

    public HomeController(ILogger<HomeController> logger, MyDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    MyDbContext db=new MyDbContext();
    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }
    public IActionResult Detail(string id)
{
    if (string.IsNullOrEmpty(id))
    {
        return NotFound(); // Trả về lỗi 404
    }

    var pd = _context.Products
        .Include(p => p.Subcategory) // Kèm theo thông tin loại (để hiển thị tên loại nếu cần)
        .FirstOrDefault(x => x.ProductId == id);

    if (pd == null)
    {
        return NotFound();
    }
    var relatedProducts = _context.Products
        .Where(x => x.SubcategoryId == pd.SubcategoryId && x.ProductId != id)
        .Take(4) 
        .ToList();
    ViewBag.SanphamLienQuan = relatedProducts;

    return View(pd);
}

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

	
