using System.Data.Common;
using System.ComponentModel.DataAnnotations;
using MertProje.Controllers;
using Microsoft.EntityFrameworkCore;
using MertProje.Models;

namespace MertProje.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

    public DbSet<Admin> admins { get; set; }

    public DbSet<FirmaİletisimBilgileri> FirmailetisimBilgileris { get; set; }
    public DbSet<İletisimBilgileri> iletisimBilgileris { get; set; }
    public DbSet<Personel> Personels { get; set; }
    public DbSet<Projeler> Projelers { get; set; }
    public DbSet<AnasayfaModel> anasayfas { get; set; }
    public DbSet<BlogModel> blogs { get; set; }
    public DbSet<HakkımızdaModel> hakkımızdas { get; set; }

    public DbSet<ViewDataİletisimBilgileri> GetViewDataİletisims { get; set; }


}