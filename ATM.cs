using System;
using System.Collections.Generic;

public class ATM
{
    private List<Kullanici> kullanicilar;
    private Log log;

    public ATM()
    {
        kullanicilar = new List<Kullanici>
        {
            new Kullanici("user1", "pass1", 1000),
            new Kullanici("user2", "pass2", 2000),
            new Kullanici("user3", "pass3", 3000)
        };
        log = new Log();
    }

    public bool GirisYap(string kullaniciAdi, string sifre, out Kullanici kullanici)
    {
        kullanici = kullanicilar.Find(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre);
        if (kullanici == null)
        {
            log.HataliGirisEkle(kullaniciAdi);
            return false;
        }
        return true;
    }

    public void ParaCek(Kullanici kullanici, decimal miktar)
    {
        if (kullanici.Bakiye >= miktar)
        {
            kullanici.Bakiye -= miktar;
            log.IslemEkle(new Islem(kullanici.KullaniciAdi, "Para Çekme", miktar, DateTime.Now));
            Console.WriteLine($"{miktar:C} çekildi. Kalan bakiye: {kullanici.Bakiye:C}");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
    }

    public void ParaYatir(Kullanici kullanici, decimal miktar)
    {
        kullanici.Bakiye += miktar;
        log.IslemEkle(new Islem(kullanici.KullaniciAdi, "Para Yatırma", miktar, DateTime.Now));
        Console.WriteLine($"{miktar:C} yatırıldı. Yeni bakiye: {kullanici.Bakiye:C}");
    }

    public void OdemeYap(Kullanici kullanici, decimal miktar)
    {
        if (kullanici.Bakiye >= miktar)
        {
            kullanici.Bakiye -= miktar;
            log.IslemEkle(new Islem(kullanici.KullaniciAdi, "Ödeme Yapma", miktar, DateTime.Now));
            Console.WriteLine($"{miktar:C} ödeme yapıldı. Kalan bakiye: {kullanici.Bakiye:C}");
        }
        else
        {
            Console.WriteLine("Yetersiz bakiye.");
        }
    }

    public void GunSonuAl()
    {
        string dosyaAdi = $"EOD_{DateTime.Now:ddMMyyyy}.txt";
        log.GunSonuLogYaz(dosyaAdi);
        log.GunSonuLogGoster();
    }
}
