using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using MertProje.Controllers;
using Microsoft.EntityFrameworkCore;

namespace MertProje.Data;
public class Admin
{
  
    [Key]// birincil anahtar dediğiniz gibi yalnızca ıd olarak bırakabilirdim ism benzerliği ve ileride olabilcek karışıkları önlemek adına ben kullnamayı şeçiyorum..
    public int AdminID { get; set; }

    [Required(ErrorMessage = "username alanı boş bırakılamaz.")]
    public string? username { get; set; }

    [Required(ErrorMessage = "şifre alanı boş bırakılamaz.")]
    public string? password { get; set; }   

     [Required(ErrorMessage = "şifre alanı boş bırakılamaz.")]
    public string? confirmpassword { get; set; }   

}