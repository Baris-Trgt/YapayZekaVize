using System;

namespace YapayZekaVize
{
    class Program
    {
        static void Main(string[] args)
        {
          
            MLModel1.ModelInput sampleData = new MLModel1.ModelInput();

            args = new string[10]; //string olan ifadeleri dizi icerisine attim , float olani (float.Parse) ettim 

            sampleData.Data_as_of = args[0];//degerleri dizi seklinde datadan aldim. float olan degeri (float.Parse) ettim
            sampleData.Start_Date = args[1];
            sampleData.End_Date = args[2];
            sampleData.Sex = args[3];
            sampleData.Age_Years = args[4];

            //Bilgilendirme Ciktilari
            Console.WriteLine("COVID-19 dan Hayatini kaybedenleri Hesaplayan Program\n\n");
            Console.WriteLine("Lütfen Tahmin Yapmak için Modelde Belirtilen Parametreleri Giriniz !!!\n");
            Console.WriteLine("Örnek : ( Datanin Girildigi Tarih = ( Ay/Gun/Yil ) şeklinde  Deger Giriniz .");
            Console.WriteLine("Örnek : ( Baslangic Tarihini = ( Ay/Gun/Yil ) şeklinde  Deger Giriniz .");
            Console.WriteLine("Örnek : ( Bitis Tarihini = ( Ay/Gun/Yil ) şeklinde  Deger Giriniz .");
            Console.WriteLine("Örnek : ( Cinsiyet Turunu = ( Female / Male ) şeklinde  Deger Giriniz .");
            Console.WriteLine("Örnek : ( Yas Degerini  = (<1 Year , 10 Year , 25 Year...) şeklinde Deger Giriniz .");
            Console.WriteLine("Örnek : ( Toplam Olum Degerini = (15827,25691,...) şeklinde Deger Giriniz .\n\n");


            if (args.Length == 0)//Kontrol amacli bir kod olusturdum 
            {
                Console.WriteLine("Kod Hatalı . args = new string[] Degerini Kontrol Ediniz ."); //Sorun varsa bu ciktiyi verecektir
                return;
            }

            else
            {
                for (int i = 0; i < args.Length; i++) //Sinirsiz cikti vermesi icin for dongusu kullandim
                {

                    Console.Write("Datanin Girildigi Tarihi Giriniz : "); // istenilen degeri yazdirdim
                    sampleData.Data_as_of = Console.ReadLine(); // istenilen degeri kullanicidan girmesini istedim

                    Console.Write("Baslangic ​Tarihini Giriniz : "); // istenilen degeri yazdirdim
                    sampleData.Start_Date = Console.ReadLine(); // istenilen degeri kullanicidan girmesini istedim

                    Console.Write("Bitis Tarihini Giriniz : "); // istenilen degeri yazdirdim
                    sampleData.End_Date = Console.ReadLine(); // istenilen degeri kullanicidan girmesini istedim

                    Console.Write("Cinsiyet Turunu Giriniz : "); // istenilen degeri yazdirdim
                    sampleData.Sex = Console.ReadLine(); // istenilen degeri kullanicidan girmesini istedim

                    Console.Write("Yas Degerini Giriniz : "); // istenilen degeri yazdirdim
                    sampleData.Age_Years = Console.ReadLine(); // istenilen degeri kullanicidan girmesini istedim

                    Console.Write("Toplam Olum Degerini Giriniz : "); // bu deger float oldugundan string dizi icinde tanimlamadim . isteline degeri yazdirdim
                    sampleData.Total_deaths = float.Parse(Console.ReadLine()); // istenilen degeri kullanicidan girmesini istedim

                    Console.WriteLine("\n\nGirilen Sonuçların Çıktısı :\n\n");
                    // istenilen degerlerin toplu olarak ciktisi
                    Console.WriteLine(@"Data_as_of : " + sampleData.Data_as_of);
                    Console.WriteLine(@"Start_Date : " + sampleData.Start_Date);
                    Console.WriteLine(@"End_Date : " + sampleData.End_Date);
                    Console.WriteLine(@"Sex : " + sampleData.Sex);
                    Console.WriteLine(@"Age_Years : " + sampleData.Age_Years);
                    Console.WriteLine(@"Total_deaths : " + sampleData.Total_deaths);


                    var Tahmin_Et = MLModel1.Predict(sampleData);
                    Console.WriteLine($"\n\nTahmini COVID_19 Olumleri : {Tahmin_Et.Score}\n");//Tahmin Edilecek Degeri Yazdirdim.
                    Console.WriteLine("Yaptiginiz Tahmin İsleminin Sonu.\n\n");
                    Console.WriteLine("Devam Etmek İcin Lütfen ENTER TUSUNA BASINIZ ...\n");
                    Console.ReadLine();
                }
            }

        }
    }
}
