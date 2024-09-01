<h1>CarBook - Araç Kiralama Sitesi</h1>

<hr>
Bu Projede, bir kullanıcının lokasyon ve diğer detaylara göre filtreleme yapıp, araç kiralayıp admin tarafında bu sürecin yönetilebildiği CarBook olarak adlandırdığımız bir proje geliştirdik.

<h1>Kullanılan Teknolojiler</h1>

<ul>
  <li>Asp Net Core 8.0</li>
  <li>Web API</li>
  <li>MSSQL</li>
  <li>Code First</li>
  <li>SignalR</li>
  <li>JWT</li>
  <li>Mailkit</li>
  <li>FluentValidation</li>
  <li>AutoMapper</li>
  <li>Bootstrap</li>
</ul>

<h1>Projenin Öne Çıkan Özellikleri</h1>

<ul>
  <li>Mssql üzerinde code first ile oluşturulmuş bir çok ilişkili tablo.</li>
  <li>Veri Kontrolleri</li>
  <li>Jwt ile veri güvenliği</li>
  <li>SignalR ile anlık veri takibi</li>
  <li>Araç Filtreleme</li>
  <li>Rezervasyon oluşturma</li>
  <li>Rezervasyon Sonucunda mail gönderme</li>
</ul>
<hr>
🚀 AspNet Core 8.0 sürümüyle Api üzerinden Swagger ve Postman kullanarak testlerimi gerçekleştirdik. <br> <br>
☆ Mimari olarak Onion Architecture kullandık. Projede tek Solution altında 6 tane katman yer aldı.<br> <br>
⚗️Design Pattern olarak CQRS - Mediator ve Repository tasarım desenlerine yer verdik.<br> <br>
💊Veri tabanı olarak MSSQL kullandık.<br> <br>
🔑Proje güvenliği için Json Web Token kullandık. Böylece yetkisiz rol erişimlerinin önüne geçmiş olduk.<br> <br>
🎈 Bonus olarak projede SignalR, Fluent Validation, JWT Bearer yönetimi, Dashboard gibi konulara yer verdik.<br> 

<hr>
<h3>Admin Dashboard Alanı</h3>

![dashboard](https://github.com/user-attachments/assets/673080b8-a85b-43e3-aa83-534bc014077e)

🚀 4 adet widget 3 adet grafik 2 adet hızlı bakış tablosuyla admin sayfasında dashbard ekranı tasarlandı. <br>
🚀 Widgetlerin tamamı api üzerinden entity özgü methodlar yazılarak api tarafı tüketildi.
<hr>

<h3>Araba Listesi/h3>
  
![carlist](https://github.com/user-attachments/assets/d779afb3-36c9-44d7-9de2-10d06ebfaf52)
  
🚀 araba ile ilgili veri tabanı operasyonları buradan yönetildi.
  
<hr>

<h3>Araba Ekleme Sayfası/h3>
  
![caradd](https://github.com/user-attachments/assets/b0149271-e277-45c0-a112-633fcff6428f)

🚀 Sol tarafta bulunan <b>"Yeni Araç Girişi"<b/> forumunda araç ile ilgili temel bilgileri aldık. <br>
🚀 Sağ üst tarafta bulunan  <b>"Aracın Özellikleri"</b> formunda eklenecek araba için araç özelliği seçiliyor.<br>
🚀 Sağ alttarafta ise ekenecek arabaya günlük haftalık aylık kirlama ücret bilgisi ekleniyor. <br>

🚀 Bütün veriler girildikten sonra kaydet butonu yardımıyla veriler tek sayfa üzerinden kayıt işlemi gerçekleştiriliyor.

<hr>


<h3>Blog Listesi/h3>

![blogs](https://github.com/user-attachments/assets/71505355-a25f-4b02-9483-0780a2ff278a)

🚀 Yazarların yazdığı blog listeleri burada listelenmektedir.
🚀 Admin seçtiği bloğu yayından kaldırabilir.
🚀 Bloğu tek sayfa üzerinden detaylarına ulaşabilir.
🚀 Yayınlanmış olan bloğun yorumlarına ulaşabilir.

<h3>Blog Yorum Listesi/h3>

![blogcomments](https://github.com/user-attachments/assets/8d73db33-00e9-4380-974a-476307b0df91)

<hr>

<h3>Ana Sayfa/h3>

![uicarlist](https://github.com/user-attachments/assets/cb6197d4-470c-4992-903d-ac85aadc22f6)

![cardetail01](https://github.com/user-attachments/assets/00e7208f-2aa4-4da5-a1b6-e9b344d021b6)

![cardetail02](https://github.com/user-attachments/assets/4c46d38c-6658-4f47-a5fd-bd333f07dcb9)

![cardetail03](https://github.com/user-attachments/assets/1ed11df3-88a2-4162-8e47-b5f864ef3baa)

![cardetail04](https://github.com/user-attachments/assets/1fa84c26-ec4e-4eb9-99ee-a904c1a1e4b3)

![cardetail05](https://github.com/user-attachments/assets/5c6581b7-acbb-407d-9e67-47337bdabe23)

<h3>Blog Listesi/h3>
  
![blogslist](https://github.com/user-attachments/assets/a6fb70a1-ec94-4aad-b655-924c66766a53)

![blogdetail02](https://github.com/user-attachments/assets/b90dd055-5de2-4e12-9228-2bfdee10997f)
![blogdetail01](https://github.com/user-attachments/assets/b625d8a3-df77-4f8d-9593-5cf457b852f8)
![blogdetail03](https://github.com/user-attachments/assets/3080d06e-53ee-43a2-8c7d-c0050b44e781)



