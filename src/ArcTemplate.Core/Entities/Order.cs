namespace ArcTemplate.Core.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public string StoreName { get; set; }
        public string StaffFirstName { get; set; }
        public string StaffLastName { get; set; }
        public decimal TotalOrderValue { get; set; }
    }
}
