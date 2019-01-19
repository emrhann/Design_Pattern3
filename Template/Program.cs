using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Program
    {
        static void Yazdirma(TehditGunluk gunluk)
        {
            gunluk.GetTehdit();
            gunluk.CreateGunluk();            
        }
        static void Main(string[] args)
        {
            Yazdirma(new TextGunluk());
            Yazdirma(new XmlGunluk());

            Console.ReadKey();
        }
    }
    abstract class TehditGunluk
    {
        //Template metotlar
        public void CreateGunluk()
        {
            Console.WriteLine("Gunluk Oluşturuldu.");

            //Abstract olmayan bir metottan abstract metot cağırılabilir.
            Yazdir();
        }
        public void GetTehdit()
        {
            Console.WriteLine("Tehditler Getirildi.");
        }
        //Primitif metot
        public abstract void Yazdir();
    }
    //Concreate sınıflar. O işi kısmi değişiklerle yapmaya yarayacaklar.
    class TextGunluk : TehditGunluk
    {
        public override void Yazdir()
        {
            Console.WriteLine("Gunluk TEXT dosyasına yazdırıldı.");
        }
    }
    class XmlGunluk : TehditGunluk
    {
        public override void Yazdir()
        {
            Console.WriteLine("Gunluk XML dosyasına yazdırıldı.");
        }
    }
}
