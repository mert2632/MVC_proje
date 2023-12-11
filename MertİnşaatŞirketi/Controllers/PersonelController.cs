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

public class PersonelController : Controller
{
      private readonly IWebHostEnvironment _webHostEnvironment;

    private readonly Context _context;
    public  PersonelController(Context context, IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        _context = context;
    }
  //ınjeksin
  
   
    public IActionResult PersonelEkle()
  {
    
    return View();
  }

  [HttpPost]
    public IActionResult PersonelEkle(Personel model, IFormFile Personelİmage)
    {
        if (ModelState.IsValid)
        {
            if (Personelİmage != null && Personelİmage.Length > 0)
            {
                var dosyaAdi1 = Guid.NewGuid().ToString() + "_" + Personelİmage.FileName;
                var yuklemeYolu1 = Path.Combine(_webHostEnvironment.WebRootPath, "img", dosyaAdi1);
                using (var dosyaAkisi1 = new FileStream(yuklemeYolu1, FileMode.Create))
                {
                    Personelİmage.CopyTo(dosyaAkisi1);
                }
                model.Personelİmage = dosyaAdi1;
            }

    
            _context.Personels.Add(model);
            _context.SaveChanges();

            return RedirectToAction("PersonelListesi", "Personel");
        }

        return View(model);
    }
     public IActionResult PersonelListesi()
  {
  
    var latestModel = _context.Personels.ToList();
    
  
           return View("PersonelListesi", latestModel); 
  }
 
  // burası tamamenADMİN güncelle sil İŞLEMLEİ İÇİN
  // burası tamamenADMİN güncelle sil İŞLEMLEİ İÇİN
  
  [HttpGet]
  public async Task<IActionResult> PersonelGüncelle(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var personel = await _context.Personels.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (personel == null)
    {
      return NotFound();
    }
    return View(personel);
  }




  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> PersonelGüncelle(int id, Personel model,IFormFile Personelİmage)
  {
    if (id != model.PersonelID)
    {
      return NotFound();
    }

    
    if (ModelState.IsValid)
    {
      try
      {
         if (Personelİmage != null && Personelİmage.Length > 0)
            {
                var dosyaAdi1 = Guid.NewGuid().ToString() + "_" + Personelİmage.FileName;
                var yuklemeYolu1 = Path.Combine(_webHostEnvironment.WebRootPath, "img", dosyaAdi1);
                using (var dosyaAkisi1 = new FileStream(yuklemeYolu1, FileMode.Create))
                {
                    Personelİmage.CopyTo(dosyaAkisi1);
                }
                model.Personelİmage = dosyaAdi1;
            }
        _context.Update(model);
        await _context.SaveChangesAsync();
      }
      catch (Exception)
      {
        if (!_context.Personels.Any(m => m.PersonelID == model.PersonelID))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return RedirectToAction("PersonelListesi");
    }
    return View(model);
  }

  [HttpGet]

  public async Task<IActionResult> PersonelSil(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var personel = await _context.Personels.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (personel == null)
    {
      return NotFound();
    }
    return View(personel);
  }


  [HttpPost]
  public async Task<IActionResult> PersonelSil([FromForm] int id)
  {

    var personel = await _context.Personels.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (personel == null)
    {
      return NotFound();
    }
    _context.Personels.Remove(personel);
    await _context.SaveChangesAsync();
    return RedirectToAction("PersonelListesi");
  }




  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }

}
