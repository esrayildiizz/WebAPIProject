﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcClient.Models
{
    public class Ligler
    {
        [Key]
        public int Id { get; set; }
        public string LigAd { get; set; }
    }
}
