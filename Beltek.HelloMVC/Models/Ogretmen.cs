namespace Beltek.HelloMVC.Models
{
    public class Ogretmen
    {
        public Ogretmen()
        {

        }
        public Ogretmen(string tc, string ad, string soyad, string alan)
        {
            this.Tckimlik = tc;
            this.Ad = ad;
            this.Soyad = soyad;
            this.Alan = alan;
        }

        public Ogretmen(string tc, string ad, string soyad)
        {
            this.Tckimlik = tc;
            this.Ad = ad;
            this.Soyad = soyad;
        }

        public string Tckimlik { get; set; }//Id Primary Key- Fluent Api 
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Alan { get; set; }

        public override string ToString()
        {
            return $"Ad:{this.Ad} Soyad:{this.Soyad} Id:{this.Tckimlik}";
        }
    }
}
