using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace MertProje.Data;

public class Projeler
{
    [Key]
    public int  ProjelerimizID { get; set; }
    public string? ProjelerimizName { get; set; }
}