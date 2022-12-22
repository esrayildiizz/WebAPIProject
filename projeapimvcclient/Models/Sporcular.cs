using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcClient.Models
{
    public class Sporcular
    {
     
        public int Id { get; set; }
        public string  Adsoyad { get; set; }
        public int Yas { get; set; }
        public string  Adres { get; set; }
        public int TID { get; set; }
        [ForeignKey("TID")]
        public Takimlar Takimlar { get; set; }  

    }
}
