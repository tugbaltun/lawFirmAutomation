using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Continued.Entity
{
    public class FoyKarti
    {
        private int _no;
        [DisplayName("Dosya No")]
        public int No
        {
            get { return _no; }
            set { _no = value; }
        }

        private string _yetkili;
        [DisplayName("Yetkili")]
        public string Yetkili
        {
            get { return _yetkili; }
            set { _yetkili = value; }
        }

        private DateTime _tarih;
        [DisplayName("Tarih")]
        public DateTime Tarih
        {
            get { return _tarih; }
            set { _tarih = value; }
        }
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]

        private string _icerik;
        [DisplayName("İçerik")]
        public string Icerik
        {
            get { return _icerik; }
            set { _icerik = value; }
        }

        private string _sonuc;
        [DisplayName("Sonuç")]
        public string Sonuc
        {
            get { return _sonuc; }
            set { _sonuc = value; }
        }

        private string _durum;
        [DisplayName("Durum")]
        public string Durum
        {
            get { return _durum; }
            set { _durum = value; }
        }

        [NotMapped]
        public IEnumerable<FoyKarti> KartCollection { get; set; }

        public string SearchKey { get; set; }
    }

    public static class HtmlHelperExtensions
    {
        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}
