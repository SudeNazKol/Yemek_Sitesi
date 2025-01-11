public class Yorum
{
    public int Id { get; set; } // Yorumun ID'si (veritabanında benzersiz olacak)
    public string AdSoyad { get; set; }= string.Empty; // Yorum yapan kişinin adı
    public string YorumMetni { get; set; }= string.Empty; // Yorum metni
}
