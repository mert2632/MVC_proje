using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using MertProje.Controllers;
using Microsoft.EntityFrameworkCore;
using MertProje.Models;
using MertProje.Data;

namespace MertProje.Data;

public class ViewDataİletisimBilgileri
{
  public int id {get; set;} 
  public  FirmaİletisimBilgileri? FirmaAdres {get; set;} 

    [Required(ErrorMessage = "Müşteri iletişim bilgileri boş bırakılamaz.")]
    public İletisimBilgileri? MusteriİletisimBilgileri { get; set; }
  

}