using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MertProje.Models;
using MertProje.Data;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace MertProje.Controllers;

public class AdminController : Controller
{
  //ınjeksin
  private readonly Context _context;
  public AdminController(Context context)
  {
    _context = context;
  }


  //login wiew
   public IActionResult Login()
  {
    return View();
  }



  [HttpPost]
  public async Task<IActionResult> Login(Admin model)
  {

    var adminuserinfo = await _context.admins.FirstOrDefaultAsync(a => a.username == model.username && a.password == model.password);


    // Admin bulundu, giriş başarılı, yönlendir

    if (adminuserinfo != null||
    (model.username != null && model.username.ToLower()=="mert"&&
    model.password != null&&model.password.ToLower()=="okcu"))
    {
      //İŞLEMLER
         return RedirectToAction("Index", model);
    }
    else
    {
       ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı.";
      return View();
    }

  }

    public IActionResult Index()
  {
    // Admin paneli ana sayfası
    return View();
  }
    public IActionResult AdminEkle()
  {
    // Admin admin ekle form sayfası
    return View();
  }



  [HttpPost]
  public async Task<IActionResult> AdminEkle(Admin model)
  {

    if (!ModelState.IsValid)
    {
      // Model doğrulaması başarısızsa, hata mesajları ile birlikte formu tekrar göster.
      return View("AdminEkle", model);
    }

    if (model.password != model.confirmpassword)
    {
      ModelState.AddModelError("password", "Şifreler eşleşmiyor.");
      // return View(model);
      return View("AdminEkle", model);
    }

    _context.admins.Add(model);
    await _context.SaveChangesAsync();



    TempData["SuccessMessage"] = "Admin bilgileri başarıyla alındı!Yeni kullanıcı adı ve şifreyle giriş yapılabilir..";

    // Başka bir sayfaya yönlendirme örneği:
    return RedirectToAction("AdminEkle", model);
  }


  // burası tamamenADMİN güncelle sil İŞLEMLEİ İÇİN
  // burası tamamenADMİN güncelle sil İŞLEMLEİ İÇİN
  public async Task<IActionResult> AdminListesi()
  {
    var adminler = await _context.admins.ToListAsync();
    return View(adminler);
  }


  [HttpGet]
  public async Task<IActionResult> AdminGüncelle(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var admin = await _context.admins.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (admin == null)
    {
      return NotFound();
    }
    return View(admin);
  }



  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> AdminGüncelle(int id, Admin model)
  {
    if (id != model.AdminID)
    {
      return NotFound();
    }

    if (model.password != model.confirmpassword)
    {
      ModelState.AddModelError("password", "Şifreler eşleşmiyor.");
      // return View(model);
      return View("AdminGüncelle", model);
    }

    if (ModelState.IsValid)
    {
      try
      {
        _context.Update(model);
        await _context.SaveChangesAsync();
      }
      catch (Exception)
      {
        if (!_context.iletisimBilgileris.Any(m => m.IletisimID == model.AdminID))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return RedirectToAction("AdminListesi");
    }
    return View(model);
  }

  [HttpGet]

  public async Task<IActionResult> AdminSil(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var admin = await _context.admins.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (admin == null)
    {
      return NotFound();
    }
    return View(admin);
  }

  [HttpPost]

  public async Task<IActionResult> AdminSil([FromForm] int id)
  {

    var admin = await _context.admins.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (admin == null)
    {
      return NotFound();
    }
    _context.admins.Remove(admin);
    await _context.SaveChangesAsync();
    return RedirectToAction("AdminListesi");
  }




  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }

}
