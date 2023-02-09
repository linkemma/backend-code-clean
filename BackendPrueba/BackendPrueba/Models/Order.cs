namespace BackendPrueba.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate  { get; set; }
        public int OrderStatus { get; set; }
        public decimal Price { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipConuntry { get; set; }
        
    }
}
