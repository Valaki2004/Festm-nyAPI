using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FestményAPI.Model
{
    public class Berles
    {
        public int id { get; set; }
        public int uid { get; set; }
        public int paintingId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int dailyPrice { get; set; }
        [NotMapped]
        public int Duration => (endDate - startDate).Days + 1;
        [NotMapped]
        public int TotalPrice => (int)(endDate - startDate).TotalDays * dailyPrice;
    }
}
