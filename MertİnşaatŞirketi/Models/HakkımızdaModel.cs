using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MertProje.Models;

public class HakkımızdaModel
{
    [Key]
    public int      HakkımızdaID { get; set; }
    public string? HakkımızdaBaşlık { get; set; }
    public string? Hakkımızdaİmage { get; set; }
    public string? HakkımızdaPersonelİmage1 { get; set; }
    public string? HakkımızdaPersonelİmage2 { get; set; }
    public string? HakkımızdaAçıklama { get; set; }

}