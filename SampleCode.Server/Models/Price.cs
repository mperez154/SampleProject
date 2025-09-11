using System.ComponentModel.DataAnnotations;

namespace SampleCode.Server.Models
{
    /// <summary>
    /// Price Entity
    /// </summary>
    public class Price
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(5)]
        public string Ticker { get; set; }
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal AdjClose { get; set; }
        public int Volume { get; set; }
    }
}