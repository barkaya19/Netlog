using System.ComponentModel.DataAnnotations;

namespace Netlog.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
