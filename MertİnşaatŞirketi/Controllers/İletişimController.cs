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

public class İletişimController : Controller
{
    
    private readonly IWebHostEnvironment _webHostEnvironment;

    private readonly Context _context;
    public İletişimController(Context context, IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        _context = context;
    }

   //son kaydı getirir veri tabanından "firma adresini alan" get metot
    public IActionResult index()
    {   //AYNI SAYFADA 2 BÖLÜMDE RESİM GETİRİRKEN BİR BÖLÜMDE 2 model ALICAZ ve 1 modelde POST YAPICAZ VİEW DATA YOLUNA BASVURDUK
        ViewDataİletisimBilgileri viewDataİletisim=new ViewDataİletisimBilgileri();
         viewDataİletisim.FirmaAdres= _context.FirmailetisimBilgileris.OrderByDescending(x => x.AdresID).FirstOrDefault();
         return View(viewDataİletisim); 
                
    }
    //deneme






   [HttpPost]
   public async Task<IActionResult> index(ViewDataİletisimBilgileri model)
{
       
if (!ModelState.IsValid)
    {
        // Model doğrulaması başarısızsa, hata mesajları ile birlikte formu tekrar göster.
        return RedirectToAction("index","İletişim",model);;
    }
     if(model.MusteriİletisimBilgileri!=null)
     {
     _context.iletisimBilgileris.Add(model.MusteriİletisimBilgileri);
      await _context.SaveChangesAsync();

    // Veriyi işleme (örneğin, veritabanına kaydetme) kodları buraya gelecek.
    // model.AdSoyad, model.Email, vb. şeklinde modele erişebilirsiniz.

    // İşlemin başarıyla gerçekleştiğini belirten bir mesaj verebilirsiniz.


    TempData["SuccessMessage"] = "İletişim bilgileriniz başarıyla alındı! Tekrar mesaj göndermek için alanları doldurabilirsiniz.";
     }
    // Başka bir sayfaya yönlendirme örneği:
    return RedirectToAction("index","İletişim",model);
}

//footer 2 denemeler footuru getirme çalısmaları





 public IActionResult firmaAdresCreate()
    {
        return View();
    }

      //iletişim kısmında olan firma adres bilgilerini güncelledik
     [HttpPost]
    public IActionResult firmaAdresCreate(FirmaİletisimBilgileri model)
    {
  
        if (ModelState.IsValid)
        {
          
          if(model!=null)
          {
            _context.FirmailetisimBilgileris.Add(model);
            _context.SaveChanges();

            return RedirectToAction("index", "İletişim");
          }
        }

        return View(model);
    }

  
     //footer kısmında olan firma adres bilgilerini güncelledik
   
   
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
