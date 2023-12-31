using Microsoft.EntityFrameworkCore;

namespace Beltek.EntityApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var ogr = new Ogrenci();    // CRUD işlemleri yaptık.
            //ogr.Ad = "Osman";
            //ogr.Soyad = "Yılmaz";
            //ogr.Numara = "789";

            //try
            //{
            //    using (var ctx = new OkulDbContext())
            //    {
            //        ctx.Ogrenciler.Add(ogr);
            //        int sonuc = ctx.SaveChanges();
            //        Console.WriteLine(sonuc > 0 ? "Ekleme Başarılı!" : "Ekleme Başarısız.");
            //    }
                
            //}
            //catch (Exception) 
            //{

            //    throw;
            //}
            //finally 
            //{
            //    ctx.Dispose();
            //}
            

            

        }
    }

    class Ogrenci
    {
        public int Ogrenciid { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Numara { get; set; }
    }

    class OkulDbContext : DbContext
    {
        public DbSet<Ogrenci> Ogrenciler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=OkulDBEF;Integrated Security=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");
            modelBuilder.Entity<Ogrenci>().Property(o => o.Ad).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Soyad).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Ogrenci>().Property(o => o.Numara).HasColumnType("varchar").HasMaxLength(15).IsRequired();
        }//Fluent API
    }
}

//Entity Framework
//ORM Tool: Object Relational Mapping