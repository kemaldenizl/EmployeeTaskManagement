# Employee Task Management API

Çalışan (Employee) ve görev (TaskItem) yönetimi yapan, JWT tabanlı kimlik doğrulamaya sahip bir ASP.NET Core 9 Web API projesi. Veritabanı olarak SQLite, ORM olarak Entity Framework Core kullanır.

## Gereksinimler

- .NET SDK 9.0

## Kurulum

### 1. Projeyi klonlayın ve Bağımlılıkları Yükleyin

```
git clone <repository-url> && cd EmployeeTaskManagement
dotnet restore && dotnet build
```


### 2. `dotnet-ef` aracını kurun ve veritabanını aktif edin

Daha önce kurmadıysanız:

```
dotnet tool install --global dotnet-ef
cd EmployeeTaskManagement.API && dotnet ef database update --project ../EmployeeTaskManagement.DataAccess
```


### 3. Uygulamayı çalıştırın

API proje dizininden aşşağıdaki komut yazıldığında uygulama `http://localhost:5125` adresinde ayağa kalkar:

```
dotnet run
```


### 4. Swagger arayüzü

Uygulama `Development` ortamında çalışırken Swagger UI şu adreste açılır:

```
http://localhost:5125/swagger
```

Korumalı endpoint'leri denemek için sağ üstteki **Authorize** butonuna basıp **sadece token'ı** yapıştırın — `Bearer` öneki otomatik eklenir.

## Endpoint'ler

Base URL: `http://localhost:5125`


### Yanıt formatı

Tüm yanıtlar aynı sarmalayıcıyı kullanır. Veri döndüren endpoint'ler (`GETALL`, `GET`):

```
{
  "data": { },
  "success": true,
  "message": null
}
```

Veri döndürmeyen endpoint'ler (`POST`, `PUT`, `DELETE`):

```
{
  "success": true,
  "message": null
}
```

Hata durumunda `success: false` olur ve `message` alanı doğrulama hatalarını ` | ` ile birleştirilmiş şekilde taşır. Beklenmeyen bir hatada global exception handler `500` ile `{"success": false, "message": "An unexpected error occurred."}` döner. Bütün hatalar ve warningler console'a loglanır.

## Örnek istekler

Aşağıdaki akış sıfırdan başlayarak kayıt olup token alır, çalışan ve görev oluşturur.

### 1. Kullanıcı kaydı

```
curl -X POST http://localhost:5125/api/auth/register -H "Content-Type: application/json" -d '{"username":"admin","password":"Admin123!"}'
```

Yanıt:

```
{
  "data": { "id": 1, "username": "admin" },
  "success": true,
  "message": null
}
```

### 2. Giriş yapıp token alma

```
curl -X POST http://localhost:5125/api/auth/login -H "Content-Type: application/json" -d '{"username":"admin","password":"Admin123!"}'
```

Yanıt:

```
{
  "data": {
    "token": "testToken...",
    "expiration": "2026-10-08T16:30:00.000Z"
  },
  "success": true,
  "message": null
}
```

Hatalı bilgide `401` ve `"Username or password is incorrect."` döner.


### 3. Çalışan oluşturma (Örnek İstek)
header olarak tokenin girilmesi gerekir swaggerda denenirken yukardan girilebilir. Token olmazsa 401 döner.

```
curl -X POST http://localhost:5125/api/employees -H "Content-Type: application/json" -H "Authorization: Bearer $TOKEN" -d '{"firstName":"test","lastName":"test","email":"test@example.com","department":"Yazilim Gelistirme"}'
```

Yanıt:

```
{ "success": true, "message": null }
```