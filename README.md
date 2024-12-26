# CarBook

CarBook, Arca Kiralama için geliştirilmiş bir araç kiralama ve blog uygulamasıdır. Bu proje, ASP.NET Core kullanılarak modern yazılım geliştirme prensipleri ve teknolojileri ile hazırlanmıştır.

## Proje Mimarisi
CarBook projesi, Onion Architecture (Soğan Mimarisi) kullanılarak yapılandırılmıştır. Bu mimari sayesinde modüler, kolay test edilebilir ve bağımsız bir yapı oluşturulmuştur. 

### Kullanılan Teknolojiler ve Yaklaşımlar

1. **Onion Architecture**: Proje, bağımlılıkların merkezden dışa doğru yönetildiği katmanlı bir yapıya sahiptir. Bu mimari, iş mantığını altyapıdan ve kullanıcı arayüzünden bağımsız hale getirir.

2. **Entity Framework Core**: Veritabanı yönetimi ve veri erişim işlemleri için kullanılmıştır.

3. **SignalR**: Gerçek zamanlı iletişim (real-time communication) özelliklerini sağlamak için kullanılmıştır. Örneğin, kullanıcı bildirimleri ve durum güncellemeleri bu teknolojiyle sağlanmaktadır.

4. **JWT (JSON Web Token)**: Kullanıcı kimlik doğrulama ve yetkilendirme işlemleri için güvenli bir yöntem olarak entegre edilmiştir.

5. **MediatR**: Komut ve sorgu tabanlı iletişim için kullanılmıştır. Bu yaklaşım, CQRS (Command Query Responsibility Segregation) desenini uygulamaya olanak sağlar.

6. **CQRS**: Komut ve sorgu işlemleri ayrılarak daha düzenli ve ölçeklenebilir bir yapı oluşturulmuştur.

---

## Proje Özellikleri

- Kullanıcıların araçları görüntüleyip kiralayabilmesini sağlar.
- Blog modülü sayesinde araç kiralama ile ilgili içerikler paylaşılabilir.
- Kullanıcı dostu bir arayüz ile araçlar hakkında detaylı bilgi verir.
- Gerçek zamanlı durum güncellemeleri ve bildirimler.
- Güvenli bir kimlik doğrulama ve yetkilendirme sistemi.
- Esnek ve genişletilebilir bir altyapı.

---

## Proje Yapısı

### Katmanlar

1. **Core (Çekirdek)**:
   - Uygulamanın iş kurallarını ve domain nesnelerini içerir.
   - CQRS komut ve sorgu modelleri burada tanımlanır.

2. **Application (Uygulama)**:
   - İş kurallarının uygulanması ve dış dünya ile etkileşim kuracak servislerin tanımlandığı katmandır.
   - SignalR hub'ları, MediatR handler'ları gibi bileşenleri içerir.

3. **Infrastructure (Altyapı)**:
   - Veritabanı bağlantıları ve harici servislerle entegrasyonların yönetildiği katmandır.
   - Entity Framework implementasyonu burada yer alır.

4. **Web (Web Arayüzü)**:
   - Kullanıcı arayüzünün bulunduğu katmandır.
   - ASP.NET Core MVC veya Razor Pages ile oluşturulmuş bileşenler içerir.

5. **Presentation (Sunum Katmanı)**:
   - API veya MVC yapıları kullanılarak kullanıcıya görsel veya JSON çıktılar sunar.
   - Blog modülü ve araç kiralama işlemlerine yönelik ekranları barındırır.

---

## Kurulum ve Çalıştırma

### Gereksinimler
- .NET 8 SDK veya üstü
- SQL Server
- Visual Studio 2022 veya Visual Studio Code

### Kurulum Adımları

1. **Proje Deposu**:
   ```bash
   git clone https://github.com/your-repository/CarBook.git
   cd CarBook
   ```

2. **Veritabanı Migrasyonları**:
   ```bash
   dotnet ef database update
   ```

3. **Projeyi Çalıştırma**:
   ```bash
   dotnet run
   ```

