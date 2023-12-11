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

public class ProjelerimizController : Controller
{
    
    private readonly IWebHostEnvironment _webHostEnvironment;

    private readonly Context _context;
    public ProjelerimizController(Context context, IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        _context = context;
    }

   //son kaydı getirir veri tabanından
    public IActionResult index()
    {
          var latestModel =_context.Projelers.ToList();
    
  
           return View("index", latestModel); 

    }

      public IActionResult ProjelerimizListesi()
    {
          var latestModel =_context.Projelers.ToList();
    
  
           return View("ProjelerimizListesi", latestModel); 
    }
    public IActionResult projelerimizCreate()
    {
        return View();
    }
 
    [HttpPost]
    public IActionResult projelerimizCreate(Projeler model)
    {
  
        if (ModelState.IsValid)
        {
          

            _context.Projelers.Add(model);
            _context.SaveChanges();

            return RedirectToAction("index", "Projelerimiz");
        }

        return View(model);
    }

 public async Task<IActionResult> ProjelerimizGüncelle(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var projelerimiz = await _context.Projelers.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (projelerimiz == null)
    {
      return NotFound();
    }
    return View(projelerimiz);
  }

  //güncellenmiş wiew
  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<IActionResult> ProjelerimizGüncelle(int id, Projeler model)
  {
    if (id != model.ProjelerimizID)
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
        if (!_context.Projelers.Any(m => m.ProjelerimizID == model.ProjelerimizID))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return RedirectToAction("ProjelerimizListesi");
    }
    return View(model);
  }

  [HttpGet]

  public async Task<IActionResult> ProjelerimizSil(int? id)
  {
    if (id == null)
    {
      return NotFound();
    }
    var proje = await _context.Projelers.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (proje == null)
    {
      return NotFound();
    }
    return View(proje);
  }

  [HttpPost]

  public async Task<IActionResult> ProjelerimizSil([FromForm] int id)
  {

    var proje = await _context.Projelers.FindAsync(id);
    // // ıd yerine farklı bir özellik için kullanabilirdim
    //  var musteri = await _context.iletisimBilgileris.FirstOrDefaultAsync(m=>m.IletisimID==id);
    if (proje == null)
    {
      return NotFound();
    }
    _context.Projelers.Remove(proje);
    await _context.SaveChangesAsync();
    return RedirectToAction("ProjelerimizListesi");
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
