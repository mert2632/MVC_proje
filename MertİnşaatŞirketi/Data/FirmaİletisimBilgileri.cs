using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using MertProje.Controllers;
using Microsoft.EntityFrameworkCore;

namespace MertProje.Data;

public class FirmaİletisimBilgileri
{
  
    [Key]// birincil anahtar dediğiniz gibi yalnızca ıd olarak bırakabilirdim ism benzerliği ve ileride olabilcek karışıkları önlemek adına ben kullnamayı şeçiyorum..
    public int AdresID { get; set; }

    public string? FirmaAdres { get; set; }
    
    public string? FirmaTelefon { get; set; }

    public string? FirmaMail { get; set; }   
    public string? FirmaHarita { get; set; }      

}