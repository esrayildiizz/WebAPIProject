using System.ComponentModel.DataAnnotations;

namespace MvcClient.Models
{
    public class Formalar
    {
        [Key]
        public int Id { get; set; }
        public string Renk{ get; set; }
    }
}
