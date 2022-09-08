

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netlog.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string DispatchPoint { get; set; }
        public string Receiver { get; set; }
        public string ContactPhone { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Products { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
