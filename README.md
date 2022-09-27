# Adesso AdessoRideShare Restful API Projesi
***Proje Konusu*** : Örnek bir yolcu bulma uygulaması projesi.  Kullanıcı sisteme kayıt olur giriş yapar ve yolculuk ilanı verir, ilanları listeler, başka kullanıcıların verdiği ilanları listeler ve onlara teklif verebilir, kendi ilanına gelen teklifleri kabul edebilir.


## Projeyi Çalıştırmak

### Ön Gereksinimler
* Visual Studio 2020+
* PostgreSql
* .Net 6.0

### Çalıştırılması
Local klasöre projeyi klonlamak için :
```
 git clone https://github.com/Bedrhann/Adesso.Project
```
PosgreSql bağlantı yolunuzu aşagıdaki gibi kendi bilgisayarına göre giriniz.

 ![image](https://user-images.githubusercontent.com/99317183/191688309-1b5d2036-7ad4-4668-95e4-7b5859f7d3c9.png)


<br/>
-Projeyi derleyip çalıştırdığınızda gerekli veritabanı sisteminize kurulacak ve proje ayağa kalkacaktır.-
Örnek senaryo
**KULLANICI KAYDI**

![image](https://user-images.githubusercontent.com/99317183/192549367-ffe8aca6-b941-413b-837d-8e641c066696.png)

**İLAN EKLEME**
![image](https://user-images.githubusercontent.com/99317183/192550021-d2aa80e1-8d6f-4f82-b460-61862631f36e.png)

**İLANLARI LİSTELEME**

![image](https://user-images.githubusercontent.com/99317183/192562657-cdbad846-cec7-4543-a36b-1caec4c7f6e0.png)

**İLANLARI FİLTRE İLE LİSTELEME**

![image](https://user-images.githubusercontent.com/99317183/192562172-5d03497e-7f70-41bd-9bb7-edfa2278865a.png)

**İLANA TEKLİF VEREBİLMEK İÇİN İLANLAR BU ID İLE OLUŞMUŞ OLMALI "0c4c8b46-0cf7-4062-a4e2-38cc719d4a43" ,  PROJE TAMAMLANDIGINDA JWT TOKEN İÇİNDEKİ KULLANICI ID'Sİ CEKİLEREK ALICAKTI.***
![image](https://user-images.githubusercontent.com/99317183/192565468-189b1c90-189f-4292-89f2-20f40fc13bfd.png)

**İLANA TEKLİF VERME**

![image](https://user-images.githubusercontent.com/99317183/192562847-5800f2cd-8e00-46ac-b76a-b1306a44c928.png)

**TEKLİFİ KABUL ETME**
![image](https://user-images.githubusercontent.com/99317183/192564700-2c119c89-0a35-4fb9-ade4-bda307fd7d4a.png)

**Araçta yer olmadığında alınan hata**
![image](https://user-images.githubusercontent.com/99317183/192564906-e5800bb8-050d-4094-8932-954008447a82.png)


