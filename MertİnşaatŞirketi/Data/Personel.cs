using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using MertProje.Controllers;
using Microsoft.EntityFrameworkCore;

namespace MertProje.Data;
public class Personel
{
  
    [Key]
    public int PersonelID { get; set; }
    
    public string? PersonelName { get; set; }

    public string? PersonelÜnvan { get; set; }   
      public string? Personelİmage { get; set; }

}