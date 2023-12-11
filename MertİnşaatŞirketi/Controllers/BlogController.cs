using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MertProje.Models;
using MertProje.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;


namespace MertProje.Controllers;

public class BlogController : Controller
{
    // private readonly ILogger<AnasayfaController> _logger;

    // public AnasayfaController(ILogger<AnasayfaController> logger)
    // {
    //     _logger = logger;
    // }
    private readonly IWebHostEnvironment _webHostEnvironment;

    private readonly Context _context;
    public BlogController(Context context, IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        _context = context;
    }

   //son kaydı getirir veri tabanından
  public IActionResult Index()
{
    var latestModel = _context.blogs.OrderByDescending(b => b.BlogID)
                            .Take(6)
                            .ToList();

    return View("Index", latestModel);
}

    public IActionResult blogCreate()
    {
        return View();
    }
 
    [HttpPost]
    public IActionResult blogCreate(BlogModel model,IFormFile Blogİmage)
    {
  
        if (ModelState.IsValid)
        {
            if (Blogİmage != null && Blogİmage.Length > 0)
            {
                var dosyaAdi1 = Guid.NewGuid().ToString() + "_" + Blogİmage.FileName;//BNZERSİZ İSİM
                var yuklemeYolu1 = Path.Combine(_webHostEnvironment.WebRootPath, "img", dosyaAdi1);//İMG KLASÖRÜNE KAYIT
                using (var dosyaAkisi1 = new FileStream(yuklemeYolu1, FileMode.Create))
                {
                    Blogİmage.CopyTo(dosyaAkisi1);
                }
                model.Blogİmage = dosyaAdi1;
            }   

            _context.blogs.Add(model);
            _context.SaveChanges();

            return RedirectToAction("index", "Blog");
        }

        return View(model);
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
