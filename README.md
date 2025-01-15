# Afiyetle Blog

## Amaç
Afiyetle Blog, kullanıcıların yemek tariflerini paylaşmalarına, düzenlemelerine ve tariflerine fotoğraf eklemelerine olanak tanıyan bir web uygulamasıdır. Kullanıcı dostu ve estetik bir arayüze sahip olan bu platform, kullanıcıların tariflerini kolayca yönetmelerini ve diğer kullanıcılarla etkileşimde bulunmalarını sağlar.
## Ekip Üyeleri
- **Sude Naz KOL**: [GitHub Kullanıcı Adı](https://github.com/SudeNazKol)
-132230031
- **İlayda YILDIZ**: [GitHub Kullanıcı Adı](https://github.com/ilaydayildizz)
-132230061
- **Fatmanur Sena BÜLBÜL**: [GitHub Kullanıcı Adı](https://github.com/bulbulsena)
-132230062

## Proje Açıklaması
Afiyetle Blog, kullanıcıların yemek tariflerini paylaşabildiği bir platformdur. Kullanıcılar tariflerini ekleyebilir, düzenleyebilir ve tariflerine fotoğraf ekleyebilirler. Uygulamada kullanıcı girişi zorunludur ve kullanım kolaylığı sağlayan şık bir arayüze sahiptir.

### Kullanılan Teknolojiler
- **Programlama Dili**: C#
- **Framework**: ASP.NET MVC
- **Veritabanı**: SQLExpress

## Kurulum ve Çalıştırma
Projenin yerel makinede çalıştırılması için aşağıdaki adımları takip ediniz:

```bash
# Depoyu klonlayın
git clone https://github.com/kullanici_adi/afiyet_blog.git

# Proje dizinine gidin
cd afiyet_blog

# Gerekli bağımlılıkları yükleyin
# Örneğin, Visual Studio kullanıyorsanız, projeyi açın ve gerekli NuGet paketlerini yükleyin
```

## Ekran Görüntüleri

### Giriş Ekranı
Kullanıcıların sisteme giriş yaptığı ekran:
![3](https://github.com/user-attachments/assets/50b8d733-6da3-48e2-bba9-2516f106cf42)
![4](https://github.com/user-attachments/assets/587fc329-f937-4308-9c04-d098349a45b7)
![5](https://github.com/user-attachments/assets/2f6c153c-5e6b-480e-aa00-d1e36a2238a3)
### Anasayfa
Kullanıcıların içeriklerimizi incelediği, yorum yapabildiği ekran:
![6](https://github.com/user-attachments/assets/db1ba922-3b65-4138-a1e7-95f37434277d)
![7](https://github.com/user-attachments/assets/0022ef4b-1702-431f-b6e0-19c542e0ca48)
![2](https://github.com/user-attachments/assets/60239e9e-a468-4e71-bde0-cb45c344e94d)
![9](https://github.com/user-attachments/assets/10e253ff-c252-4685-916c-fbaf5f8b2b02)

### Tariflerim Ekranı
Kullanıcıların tariflerini bulabilecekleri; ekleyip, düzenleyip, silebildikleri ekran:
![10](https://github.com/user-attachments/assets/de9725c0-7f34-4b34-b418-f1c84836fe1b)
![11](https://github.com/user-attachments/assets/50a32acf-2b80-49dd-ae3f-83640fda756b)
![12](https://github.com/user-attachments/assets/4b6f12ec-eb78-486a-bcda-81662bcbb06e)

### Tarif Ekleme Ekranı
Kullanıcıların tariflerini ekleyebildikleri ekran:
![2](https://github.com/user-attachments/assets/6dfe0eb7-a6db-450f-a936-4b10201772b9)

### İletişim Ekranı
Kullanıcıların iletişim formuna ulaştıkları ekran:
![1](https://github.com/user-attachments/assets/704c3282-7c06-4d06-a4a2-d9a8c9ab5a9e)

## Tanıtım Videosu
Projenin tanıtım videosunu izlemek için [[buraya tıklayın](https://youtu.be/gSP3RnQ9Bvo)](#).

## Veritabanı Yapısı
Uygulamada kullanılan veritabanı yapısı:

### Kullanici Tablosu
Kullanıcı bilgileri ve giriş bilgilerini saklar. Şifreler hashli olarak tutulmaktadır.
- **Id**: int, primary key, auto-increment
- **Email**: string (Required, EmailAddress)

### Tarif Tablosu
Kullanıcıların eklediği tarifleri saklar.
- **Id**: int, primary key, auto-increment
- **YemekAdi**: string
- **Kategori**: string
- **Malzemeler**: string
- **Talimatlar**: string
- **ResimPath**: string

### Yorum Tablosu
Tariflere yapılan yorumları saklar.
- **Id**: int, primary key, auto-increment
- **AdSoyad**: string
- **YorumMetni**: string
