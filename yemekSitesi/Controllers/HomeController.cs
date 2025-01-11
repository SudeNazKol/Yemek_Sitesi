using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using YemekBlog.Models;
using yemekSitesi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace yemekSitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context; // Veritabanı bağlamı
        private readonly string _connectionString = "Server=(local)\\SQLEXPRESS02;database=tarif;User ID=ilayda;Password=maksut53;TrustServerCertificate=True";

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context; // Bağlamı constructor üzerinden alıyoruz
        }

        // Ana sayfayı görüntüleme
        public IActionResult Index()
        {
            return View();
        }

        // Anasayfa üzerinde yorumları gösterme
        [Route("/Anasayfa")]
        public IActionResult Anasayfa()
        {
            // Yorumları veritabanından çekiyoruz
            var yorumlar = new List<Yorum>();
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT AdSoyad, YorumMetni FROM Yorumlar ORDER BY Id DESC";
                var command = new SqlCommand(query, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yorumlar.Add(new Yorum
                        {
                            AdSoyad = reader.GetString(0),
                            YorumMetni = reader.GetString(1)
                        });
                    }
                }
            }
            return View(yorumlar); // Yorumları View'a gönderiyoruz
        }

        // Yorum ekleme işlemi
        [HttpPost]
        public IActionResult YorumEkle(string adSoyad, string yorum)
        {
            if (!string.IsNullOrWhiteSpace(adSoyad) && !string.IsNullOrWhiteSpace(yorum))
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Yorumlar (AdSoyad, YorumMetni) VALUES (@AdSoyad, @YorumMetni)";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@AdSoyad", adSoyad);
                    command.Parameters.AddWithValue("@YorumMetni", yorum);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Yorum ekleme işleminden sonra aynı sayfayı (anasayfa) tekrar gösteriyoruz
            var yorumlar = new List<Yorum>();
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT AdSoyad, YorumMetni FROM Yorumlar ORDER BY Id DESC";
                var command = new SqlCommand(query, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yorumlar.Add(new Yorum
                        {
                            AdSoyad = reader.GetString(0),
                            YorumMetni = reader.GetString(1)
                        });
                    }
                }
            }

            // Aynı sayfayı (anasayfa) güncellenmiş yorumlarla birlikte tekrar gösteriyoruz
            return View("Anasayfa", yorumlar);
        }

        // Tarifler sayfasını gösterme
        [Route("/tarifler")]
        public IActionResult Tarifler()
        {
            var tarifler = _context.Tarifler.ToList(); // Veritabanındaki tarifleri al
            return View(tarifler); // Tarifleri View'a gönder
        }

        // İletişim sayfasını gösterme
        [Route("/iletisim")]
        public IActionResult Iletisim()
        {
            return View();
        }

        // Yeni tarif ekleme sayfasını gösterme
        [Route("/TarifEkle")]
        [HttpGet]
        public IActionResult TarifEkle()
        {
            return View();
        }

        // Yeni tarif ekleme işlemi
        [Route("/TarifEkle")]
        [HttpPost]
        public async Task<IActionResult> TarifEkle(Tarif tarif, IFormFile tarifResim)
        {
            if (ModelState.IsValid)
            {
                // Görsel dosyasını kontrol et
                if (tarifResim != null && tarifResim.Length > 0)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                    var fileExtension = Path.GetExtension(tarifResim.FileName).ToLower();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("tarifResim", "Yalnızca .jpg, .jpeg ve .png formatlarında dosya yükleyebilirsiniz.");
                        return View(tarif);
                    }

                    // Benzersiz dosya adı oluştur
                    var fileName = Guid.NewGuid().ToString() + fileExtension;
                    var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                    if (!Directory.Exists(imagesPath))
                    {
                        Directory.CreateDirectory(imagesPath);
                    }

                    var filePath = Path.Combine(imagesPath, fileName);

                    // Görseli kaydediyoruz
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await tarifResim.CopyToAsync(stream);
                    }

                    // Tarife görsel yolunu ekliyoruz
                    tarif.ResimPath = Path.Combine("images", fileName);
                }

                // Tarifi veritabanına ekliyoruz
                _context.Tarifler.Add(tarif);
                await _context.SaveChangesAsync(); // Asenkron kaydetme işlemi

                // Başarıyla eklenirse Tarifler sayfasına yönlendiriyoruz
                return RedirectToAction("Tarifler");
            }

            return View(tarif); // Hata varsa formu yeniden gösteriyoruz
        }

        // Tarif silme işlemi
        [HttpPost]
        [Route("/Tarifler/Sil/{id}")]
        public IActionResult Sil(int id)
        {
            var tarif = _context.Tarifler.FirstOrDefault(t => t.Id == id);

            if (tarif != null)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", tarif.ResimPath ?? "");
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                _context.Tarifler.Remove(tarif);
                _context.SaveChanges();
            }

            return RedirectToAction("Tarifler"); // Silme işlemi sonrası tarifler sayfasına yönlendiriyoruz
        }

        // Tarif detay sayfasını gösterme
        [HttpGet]
        [Route("/Tarifler/Detay/{id}")]
        public IActionResult Detay(int id)
        {
            var tarif = _context.Tarifler.FirstOrDefault(t => t.Id == id);
            if (tarif == null)
            {
                return NotFound();
            }
            return View(tarif); // Detayları View'a gönderiyoruz
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
