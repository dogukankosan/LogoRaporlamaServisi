
![indir (1)](https://github.com/user-attachments/assets/3d950bcd-8e45-4998-a106-f34cf835de75)

Logo Raporlama Servisi

**Logo ERP’ye bağlı çalışan otomatik raporlama ve bildirim servisi**  
Bu proje, SQL Server'dan belirli periyotlarla veri çekerek rapor oluşturur (Excel/PDF) ve çıktıları e‑posta veya WhatsApp üzerinden ilgili kişilere gönderir.

---

## 🚀 Öne Çıkan Özellikler

- 📊 SQL Server'dan dinamik rapor üretimi (Excel/PDF)
- 🕒 Quartz.NET zamanlayıcı desteği
- 📤 WhatsApp (Twilio) ve E‑posta ile otomatik gönderim
- 🧠 SQLite ile görev yönetimi ve loglama
- ⚙️ Servis arayüzü olmadan arka planda çalışma (Windows Service)

---

## 📂 Klasör Yapısı

LogoRaporlamaServisi/
├── Tasks/ # Görev planlayıcı sınıfları (Quartz)
├── Helpers/ # SQL, Mail, WhatsApp yardımcıları
├── Models/ # Görev ve rapor modelleri
├── Reports/ # Oluşturulan rapor çıktıları
├── Services/ # Mail, WhatsApp, PDF servisleri
├── app.config # Ayarlar (SQL, SMTP vs.)
└── README.md # Bu dosya

---

## 🔧 Kurulum

1. `app.config` içinden SQL Server, SMTP ve WhatsApp ayarlarını yap.
2. `SchedulerTasksReport` tablosuna görevlerini tanımla.
3. Servisi başlat:


> Alternatif: Debug sırasında servis `.exe` olarak değil, konsol gibi de çalıştırılabilir.

---

## 📦 Zamanlanmış Görev Formatı

SQLite veya SQL Server’daki görev tablosu aşağıdaki gibi yapılandırılır:

| ID | TaskName     | SQLQuery        | Type     | Period | LastRunDate |
|----|--------------|------------------|----------|--------|-------------|
| 1  | SiparişRaporu | `SELECT * ...` | WhatsApp | 1 Day  | 2025-06-10  |

---

## 📤 Gönderim Kanalları

- **WhatsApp**: Twilio üzerinden şablon mesaj ile gönderim yapılır  
- **E‑Posta**: SMTP bilgileri üzerinden gönderilir  
- Her gönderim `PDFSNotification` veya log tablosuna işlenir.

---

## 🧪 Geliştirici Notları

- Tüm işlemler `try-catch` blokları ile korunur.
- Loglama `Logging.LogAdd()` ile merkezi yapılır.
- `SQLCrud` sınıfı ile parametrik SQL işlemleri gerçekleştirilir.
- Görevler Excel veya PDF çıktısı ile gönderilir (boş sonuçlarda atlanır).

---

## 🛡️ Güvenlik ve Performans

- SHA256 ile şifrelenmiş bağlantı ayarları
- Loglama ile hata takibi ve analiz
- PDF/Excel oluşturulmadan önce satır kontrolü yapılır

---

## 📄 Lisans

MIT License

---

## 📬 İletişim

- 👨‍💻 Geliştirici: [@dogukankosan](https://github.com/dogukankosan)
- 💬 Her türlü katkı, hata bildirimi ve öneri için: [Issues](https://github.com/dogukankosan/LogoRaporlamaServisi/issues)

---
