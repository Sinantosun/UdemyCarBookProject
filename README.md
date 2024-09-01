<h1>CarBook - Araç Kiralama Sitesi</h1>
<br>
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

🚀 AspNet Core 8.0 sürümüyle Api üzerinden Swagger ve Postman kullanarak testlerimi gerçekleştirdik. <br>

🛞 Mimari olarak Onion Architecture kullandık. Projede tek Solution altında 6 tane katman yer aldı.<br>

⚗️Design Pattern olarak CQRS - Mediator ve Repository tasarım desenlerine yer verdik.<br>

💊Veri tabanı olarak MSSQL kullandık.<br>

🔑Proje güvenliği için Json Web Token kullandık. Böylece yetkisiz rol erişimlerinin önüne geçmiş olduk.<br>

🎈 Bonus olarak projede SignalR, Fluent Validation, JWT Bearer yönetimi, Dashboard gibi konulara yer verdik.<br> 

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





