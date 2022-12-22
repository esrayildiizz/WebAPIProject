using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Entities
{
    public class Ligler
    {
        [Key]
        public int LId { get; set; }
        public string LigAd { get; set; }
    }
}
