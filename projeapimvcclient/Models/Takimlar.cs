using System.ComponentModel.DataAnnotations;

namespace MvcClient.Models
{
    public class Takimlar
    {
        [Key]
        public int TID { get; set; }
        public string TakimAdi { get; set; }
    }
}
