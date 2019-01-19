using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            ElektrikContext elektrik = new ElektrikContext();
            elektrik.Kullan();
            elektrik.Kullan();
            elektrik.Kes();
            elektrik.Bosalt();
            elektrik.Kullan();

            Console.ReadKey();
        }
    }
    //Context Sınıf
    class ElektrikContext
    {
        private IElektirikState state;
            public IElektirikState State
        {
            get { return state; }
            set { state = value; }
        }

        public ElektrikContext()
        {
            Console.WriteLine("Fatura Yaratıldı ve Henüz Çalısmıyor");
            state = new KesilmisState();
        }
        public void Kullan()
        {
            state.Kullanimda(this);
        }
        public void Bosalt()
        {
            state.Bosta(this);
        }
        public void Kes()
        {
            state.Kesilmis(this);
        }
    }
    //Elektirik Kullanım için Arayüz
    interface IElektirikState
    {
        void Kullanimda(ElektrikContext context);
        void Bosta(ElektrikContext context);
        void Kesilmis(ElektrikContext context);
    }

    //Concreate Sınıflar
    class KullaniliyorState : IElektirikState
    {
        public void Bosta(ElektrikContext context)
        {
            context.State = new BostaState();
            Console.WriteLine("Elektrik Kapatılıp Boşa alındı.");
        }

        public void Kesilmis(ElektrikContext context)
        {
            context.State = new KesilmisState();
            Console.WriteLine("Elektrik Kesildi !");
        }

        public void Kullanimda(ElektrikContext context)
        {
            Console.WriteLine("Elektrik zaten kullanimda !");
        }
    }
    class BostaState : IElektirikState
    {
        public void Bosta(ElektrikContext context)
        {
            Console.WriteLine("Elektrik zaten Boş durumda.");
        }

        public void Kesilmis(ElektrikContext context)
        {
            Console.WriteLine("Kullanimda olmayan Boş Elektrik kesilemez !");
        }

        public void Kullanimda(ElektrikContext context)
        {
            context.State = new KullaniliyorState();
            Console.WriteLine("Elektrik Kullanilmaya başlandi !");
        }
    }
    class KesilmisState : IElektirikState
    {
        public void Bosta(ElektrikContext context)
        {
            Console.WriteLine("Kesilen elektrik boş konuma gelemez.");
        }

        public void Kesilmis(ElektrikContext context)
        {
            Console.WriteLine("Elektrik zaten Kesilmis !");
        }

        public void Kullanimda(ElektrikContext context)
        {
            context.State = new KullaniliyorState();
            Console.WriteLine("Elektrik Kullanilmaya başlandi !");
        }
    }

}
