using System;
using System.ComponentModel.DataAnnotations;

namespace SpiritSite.Models
{
    public class Quotation
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}