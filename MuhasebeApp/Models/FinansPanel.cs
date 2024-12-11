namespace DataAccess.Models
{
    public class FinansPanel
    {
        public long id { get; set; }
        public string kimeVerdi { get; set; }
        public string paraNasılVerildi { get; set; }
        public string tutar { get; set; }
        public DateTime verildigiTarih { get; set; }
        public string ay { get; set; }
        public string?toplamTutar { get; set; }
    }
}
