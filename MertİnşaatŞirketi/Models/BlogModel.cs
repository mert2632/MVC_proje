using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace MertProje.Models;

public class BlogModel
{
    [Key]// birincil anahtar dediğiniz gibi yalnızca ıd olarak bırakabilirdim ism benzerliği ve ileride olabilcek karışıkları önlemek adına ben kullnamayı şeçiyorum..
    public int BlogID { get; set; }
    public string? Blogİmage { get; set; }
    public string? BlogBaşlık { get; set; }

    public string? BlogAçıklama { get; set; }

    public string? BlogTarih { get; set; }
}
