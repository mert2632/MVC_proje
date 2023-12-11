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

public class MusteriController : Controller
{
  //ınjeksin
  private readonly Context _context;
  public MusteriController(Context context)
  {
    _context = context;
  }


 //musteri listesi wiew
  public async Task<IActionResult> MusteriListesi()
  {
    var musteriler = await _context.iletisimBilgileris.ToListAsync();
    return View(musteriler);
  }
  //güncelle wiew
  [HttpGet]
  //bu metot müsteri listesindeki şeçtiğimiz ıdyle bir ıd si olup olmadığını değerlerinin boş olup 
  //olmadığı kontrolünü yapar ve şeçtiğimiz değerin context sınıfından güncelle wieine nesne olarak ALIR.
  public async Task<IActionResult> Güncelle(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var musteri = await _context.iletisimBilgileris.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (musteri == null)
    {
      return NotFound();
    }
    return View(musteri);
  }

  //güncellenmiş wiew
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> Güncelle(int id, İletisimBilgileri model)
  {
    if (id != model.IletisimID)
    {
      return NotFound();
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
        if (!_context.iletisimBilgileris.Any(m => m.IletisimID == model.IletisimID))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return RedirectToAction("MusteriListesi");
    }
    return View(model);
  }

  [HttpGet]

  public async Task<IActionResult> Sil(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var musteri = await _context.iletisimBilgileris.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (musteri == null)
    {
      return NotFound();
    }
    return View(musteri);
  }

  [HttpPost]

  public async Task<IActionResult> Sil([FromForm] int id)
  {

    var musteri = await _context.iletisimBilgileris.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (musteri == null)
    {
      return NotFound();
    }
    _context.iletisimBilgileris.Remove(musteri);
    await _context.SaveChangesAsync();
    return RedirectToAction("MusteriListesi");
  }



  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }

}
