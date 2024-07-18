using System;

class Program
{
    static void Main(string[] args)
    {
        ATM atm = new ATM();
        Kullanici aktifKullanici = null;

        while (true)
        {
            if (aktifKullanici == null)
            {
                Console.WriteLine("\nATM'ye Hoşgeldiniz");
                Console.Write("Kullanıcı adı: ");
                string kullaniciAdi = Console.ReadLine();
                Console.Write("Şifre: ");
                string sifre = Console.ReadLine();

                if (atm.GirisYap(kullaniciAdi, sifre, out aktifKullanici))
                {
                    Console.WriteLine("Giriş başarılı!");
                }
                else
                {
                    Console.WriteLine("Hatalı kullanıcı adı veya şifre.");
                    continue;
                }
            }

            Console.WriteLine("\nYapmak istediğiniz işlemi seçin:");
            Console.WriteLine("1. Para Çekme");
            Console.WriteLine("2. Para Yatırma");
            Console.WriteLine("3. Ödeme Yapma");
            Console.WriteLine("4. Gün Sonu Al");
            Console.WriteLine("5. Çıkış Yap");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Console.Write("Çekmek istediğiniz miktar: ");
                    decimal cekilecekMiktar = decimal.Parse(Console.ReadLine());
                    atm.ParaCek(aktifKullanici, cekilecekMiktar);
                    break;
                case "2":
                    Console.Write("Yatırmak istediğiniz miktar: ");
                    decimal yatirilacakMiktar = decimal.Parse(Console.ReadLine());
                    atm.ParaYatir(aktifKullanici, yatirilacakMiktar);
                    break;
                case "3":
                    Console.Write("Ödemek istediğiniz miktar: ");
                    decimal odemeMiktar = decimal.Parse(Console.ReadLine());
                    atm.OdemeYap(aktifKullanici, odemeMiktar);
                    break;
                case "4":
                    atm.GunSonuAl();
                    break;
                case "5":
                    aktifKullanici = null;
                    Console.WriteLine("Çıkış yapıldı.");
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }
}

