# Kütüphane Yönetim Sistemi
Basit bir kütüphane yönetim sistemi web uygulamasıdır.

## Açıklama
Bu proje, kitapların listelenmesi ve detaylarının görüntülemesini sağlar. Ayrıca uygulamaya kayıt olunulabilir.

## Özellikler
- Kitap listeleme ve kitap için özel detay sayfası.
- Kullanıcılar kayıt olup sisteme giriş yapabilir. Ayrıca isterlerse hesaplarını silebilirler.
- Admin yetkisine sahip kullanıcı, diğer kullanıcıları yönetebilir. Onlara rol tanımlayabilir.

## Kurulum

### Gereksinimler

1. **.NET SDK 8.0+**  
2. **SQL Server**  
3. **Redis**  

### Adımlar
#### 1. Depoyu Klonlayın
```bash
git clone https://github.com/muratc34/InveonBootcamp.git
cd InveonBootcamp
git checkout week-two
````
#### 2. Bağlantı Dizgilerini Güncelleyin
```json
{
  "ConnectionStrings": {
    "SqlServer": "Server=your_server;Database=Library;User Id=your_user;Password=your_password;",
    "Redis": "your_redis_host"
  }
}
````
#### 3. Migration İşlemleri
```bash
dotnet ef database update
````
#### 4. Uygulamayı Başlatın
```bash
dotnet run
````

## Endpointler
### Kimlik Doğrulama
- **Giriş Yap**: `/login`  
  Kullanıcı giriş sayfası.
- **Kayıt Ol**: `/register`  
  Yeni kullanıcı kayıt sayfası.
 
### Kitap İşlemleri
- **Kitaplar**: `/Book`
  Kitapların listelendiği sayfa.
- **Kitaplar**: `/Book/Detail/{id}`
  Kitaba ait detay sayfası.

### Rol İşlemleri
- **Rol Atama**: `/Role/AssignRole/{userId}`
  Admin'in, kullanıcıya rol atadığı sayfa.
- **Rol Oluşturma**: `/Role/Create`
  Admin'in, rol oluşturduğu sayfa.
- **Rol Güncelleme**: `/Role/Edit/{id}`
  Admin'in, rol güncellediği sayfa.
- **Roller**: `/Role`
  Adminin, rolleri listelediği sayfa.
- **Roller**: `/Role/Delete`
  Admin'in, rol silmek için kullandığı uç nokta (Burası bir sayfa değildir).

### Kullanıcı İşlemleri
- **Kullanıcı Detay**: `/User/Details/{id}`
  Kullanıcının kendi bilgilerini veya Admin'in bir kullanıcı bilgilerini görüntülediği sayfa.
- **Kullanıcı Güncelleme**: `/User/Edit/{id}`
  Kullanıcının kendi bilgilerini veya Admin'in bir kullanıcı bilgilerini güncellediği sayfa.
- **Kullanıcılar**: `/User`
  Adminin, kullanıcıları listelediği sayfa.
- **Kullanıcı Silme**: `/User/Delete`
  Kullanıcının kendi hesabını silmek için veya Admin'in bir hesabı silmek için kullandığı uç nokta (Burası bir sayfa değildir).

## Not
Projeye çalıştırıldığında 'admin' kullanıcısı veritabanına otomatik eklenir. Giriş yapmak için bu bilgileri kullanabilirsiniz:
```
username: admin
password: Test*123
```



