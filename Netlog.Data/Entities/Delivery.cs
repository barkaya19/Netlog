using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netlog.Data.Entities
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }
        public string DeliveryPerson { get; set; }
        public DateTime DeliveryDate { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Orders { get; set; }
        public string Plate { get; set; }
        public int Status { get; set; }
    }
}
