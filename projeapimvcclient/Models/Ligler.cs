using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcClient.Models
{
    public class Ligler
    {
        [Key]
        public int Id { get; set; }
        public string LigAd { get; set; }
        public int TID { get; set; }
        [ForeignKey("TID")]
        public Takimlar Takimlar { get; set; }
    }
}
