public class Islem
{
    public string KullaniciAdi { get; set; }
    public string IslemTuru { get; set; }
    public decimal Miktar { get; set; }
    public DateTime Tarih { get; set; }

    public Islem(string kullaniciAdi, string islemTuru, decimal miktar, DateTime tarih)
    {
        KullaniciAdi = kullaniciAdi;
        IslemTuru = islemTuru;
        Miktar = miktar;
        Tarih = tarih;
    }

    public override string ToString()
    {
        return $"{Tarih:dd-MM-yyyy HH:mm:ss} - {KullaniciAdi} - {IslemTuru} - {Miktar:C}";
    }
}
