namespace DataAccess.Models
{
    public class Check
    {

        public long id { get; set; }
        public string? cekSira { get; set; }
        public string kimdenAlindi { get; set; }
        public string bankasi { get; set; }
        public string subesi { get; set; }
        public string vadeAyi { get; set; }
        public DateTime vadeTarihi { get; set; }
        public string cekTuru { get; set; }

        public string cekNu { get; set; }
        public string hesapNu { get; set; }
        public string? kimeCiroEdildi { get; set; }
        public DateTime? cikisTarihi { get; set; }
        public string? tutar { get; set; }
        public string yasalMi { get; set; }
        public long cekType { get; set; }
        public bool alınacakMiOdenecekMi { get; set; }
        public DateTime cekinAlindigiTarih { get; set; }
        public Nullable<bool> KendimeCiro { get; set; }


    }
    public class CheckDto
    {

        public long id { get; set; }
        public string? cekSira { get; set; }
        public string kimdenAlindi { get; set; }
        public string bankasi { get; set; }
        public string subesi { get; set; }
        public string vadeAyi { get; set; }
        public DateTime vadeTarihi { get; set; }
        public string cekTuru { get; set; }

        public string cekNu { get; set; }
        public string hesapNu { get; set; }
        public string? kimeCiroEdildi { get; set; }
        public DateTime? cikisTarihi { get; set; }
        public string? tutar { get; set; }
        public string yasalMi { get; set; }
        public string ciroEdilen { get; set; }
        public string kalan { get; set; }
        public string kendimeCiro { get; set; }
        public Nullable<long> cekType { get; set; }

        public bool alınacakMiOdenecekMi { get; set; }
        public DateTime cekinAlindigiTarih { get; set; }
        // public virtual CekType CekType1 { get; set; }


    }
    public class CheckPostDto
    {

        public long id { get; set; }
        public string? cekSira { get; set; }
        public string kimdenAlindi { get; set; }
        public string bankasi { get; set; }
        public string subesi { get; set; }
        public string vadeAyi { get; set; }
        public DateTime vadeTarihi { get; set; }
        public string cekTuru { get; set; }

        public string cekNu { get; set; }
        public string hesapNu { get; set; }
        public string? kimeCiroEdildi { get; set; }
        public DateTime? cikisTarihi { get; set; }
        public string? tutar { get; set; }
        public string yasalMi { get; set; }

        //public string kendimeCiro { get; set; }
        public Nullable<long> cekType { get; set; }

        public bool alinacakMiOdenecekMi { get; set; }
        public DateTime cekinAlindigiTarih { get; set; }
        // public virtual CekType CekType1 { get; set; }


    }
}
