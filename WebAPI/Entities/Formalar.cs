using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entities
{
    public class Formalar
    {
        [Key]
        public int Id { get; set; }
        public string Renk{ get; set; }
    }
}
