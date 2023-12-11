using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace MertProje.Models;

public class AnasayfaModel
{
    [Key]
    public int AnasayfaID { get; set; }
    public string? Anasayfaİmage1 { get; set; }
    public string? Anasayfaİmage2 { get; set; }

  
    public string? AnasayfaBaşlık1 { get; set; }
    public string? AnasayfaBaşlık2 { get; set; }

    public string? AnasayfaAçıklama1 { get; set; }
    public string? AnasayfaAçıklama2 { get; set; }

}
