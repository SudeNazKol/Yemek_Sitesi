namespace YemekBlog.Models
{
    public class Tarif
    {
        public int Id { get; set; } // Primary Key
        public string YemekAdi { get; set; }= string.Empty; 
        public string Kategori { get; set; }= string.Empty;// Yemek Adı (textbox için)
        public string Malzemeler { get; set; }= string.Empty; // Malzemeler (textarea için)
        public string Talimatlar { get; set; } = string.Empty;// Talimatlar (textarea için)
       public string ResimPath { get; set; } = string.Empty;

    }
}