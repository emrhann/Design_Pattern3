using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_Policy
{
    class Program
    {

        static void Main(string[] args)
        {
            Strategy s1 = new Simetrik();
            Strategy s2 = new Asimetrik();
            Strategy s3 = new Karma();
            Sifreleme sifre = new Sifreleme(s3);
            sifre.sifrele();

            Console.ReadKey();
        }
    }
    // Soyut Strategy sınıfı
    abstract class Strategy
    {
        public abstract void Algoritma();
    }

    //Concreate Strategy sınıfları
    class Simetrik : Strategy
    {
        public override void Algoritma()
        {
            Console.WriteLine("Simetrik Şifreleme Algoritması");
        }
    }
    class Asimetrik : Strategy
    {
        public override void Algoritma()
        {
            Console.WriteLine("Asimetrik Şifreleme Algoritması");
        }
    }
    class Karma : Strategy
    {
        public override void Algoritma()
        {
            Console.WriteLine("Karma/Anahtarsız Şifreleme Algoritması");
        }
    }
    //Context Class
    class Sifreleme
    {
        private Strategy strategy;
        public Sifreleme()
        {

        }
        public Sifreleme(Strategy strategy)
        {
            this.strategy = strategy;
        }
        public void sifrele()
        {
            strategy.Algoritma();
            Console.WriteLine("Şifreleme");
        }
    }
}
