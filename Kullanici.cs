public class Kullanici
{
    public string KullaniciAdi { get; set; }
    public string Sifre { get; set; }
    public decimal Bakiye { get; set; }

    public Kullanici(string kullaniciAdi, string sifre, decimal bakiye)
    {
        KullaniciAdi = kullaniciAdi;
        Sifre = sifre;
        Bakiye = bakiye;
    }
}

