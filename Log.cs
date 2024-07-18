using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Log
{
    private List<Islem> islemler;
    private List<string> hataliGirisler;

    public Log()
    {
        islemler = new List<Islem>();
        hataliGirisler = new List<string>();
    }

    public void IslemEkle(Islem islem)
    {
        islemler.Add(islem);
    }

    public void HataliGirisEkle(string kullaniciAdi)
    {
        hataliGirisler.Add($"{DateTime.Now:dd-MM-yyyy HH:mm:ss} - Hatalı giriş - {kullaniciAdi}");
    }

    public void GunSonuLogYaz(string dosyaAdi)
    {
        using (StreamWriter sw = new StreamWriter(dosyaAdi))
        {
            sw.WriteLine("İşlemler:");
            foreach (var islem in islemler)
            {
                sw.WriteLine(islem.ToString());
            }

            sw.WriteLine("\nHatalı Girişler:");
            foreach (var hata in hataliGirisler)
            {
                sw.WriteLine(hata);
            }
        }
    }

    public void GunSonuLogGoster()
    {
        Console.WriteLine("İşlemler:");
        foreach (var islem in islemler)
        {
            Console.WriteLine(islem.ToString());
        }

        Console.WriteLine("\nHatalı Girişler:");
        foreach (var hata in hataliGirisler)
        {
            Console.WriteLine(hata);
        }
    }
}
