# ShopList
This repository for Univera .Net Hiring Challenge Final Case 

-Katmanlı Mimari kullanarak oluşturdum. Generic Repository Pattern kullandım. Veritabanını ModelFirst yaklaşımıyla oluşturdum.
Soyutlama tekniklerine ve Solid prensiplerine uymaya özen göstererek projeyi geliştirdim. 

API'yi kullanabilmek için, DataAccess katmanındaki context sınıfındaki ConnectionString'i kendinize göre düzenlemelisiniz. Cache yönetimi için Redis kullandım. Proje başlatılmadan önce
bilgisayarınızdan Redis Server açılmalı. Token doğrulaması için JWT Bearer kullandım. 

API'yi kullanabilmek için, önce register olmalısınız. Üye yetkilendirme işlemini yetiştiremediğim için, her kayıt olan üye Admin rolüne sahip olacak şekilde ayarlanıyor. 
Register olduktan sonra size verilen Access Token ile authorize olabilirsiniz. Tokeni girerken başına bearer eklenmeli. 

İstenildiği gibi, User ve Admin rolleri var. Gerekli şekilde rol kontrolleri yapıldı. Ekstra olarak, Business katmanında bazı metotları SecuredOperation ile kontrol
altına aldım. Tüm fonksiyonlar çalışıyor. Validasyon tarafında Fluent Validation kullandım. Bazı modellerin validasyon kurallarını yetiştiremedim. Bazı metotlarda
null kontrolü gibi kontroller yok.

Kategori bazlı liste filtreleme ve herhangi bir liste içerisindeki ürünleri kategoriye göre filtreleme metotları mevcut.

Entegrasyon testini yetiştiremedim. 

Elimden geldiğince sağlam bir yapı oluşturmaya çalıştım. Business katmanındaki bazı sınıflar Core katmanı oluşturulup oraya aktarılabilir. Gerekli altyapı mevcut fakat 
başka bir projeden almış gibi olmasın diye ben bir core katmanı oluşturmadım. 

**** NOT: Cohorts sisteminde olan bir aksaklıktan dolayı sınavım değerlendirilmemiş. Bunun sonucunda, bir üst değerlendirmeye yani final case aşamasına 21Şubat'ta katılabildim.
Bir haftada elimden gelenin en iyisini, en kalitelisini yapmaya çalıştım. 

Sunum videom biraz uzun oldu, vakit ayırdığınız için teşekkür eder, iyi çalışmalar dilerim.
