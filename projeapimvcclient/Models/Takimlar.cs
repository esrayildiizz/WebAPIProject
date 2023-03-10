using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcClient.Models
{
    public class Takimlar
    {
        [Key]
        public int TID { get; set; }
        public string TakimAdi { get; set; }

        public int LId { get; set; }
        [ForeignKey("LId")]
        public Ligler Ligler { get; set; }
    }
}
