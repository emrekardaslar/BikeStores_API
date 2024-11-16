namespace BikeStores.Application.UseCases.GetProduct
{
    public class GetProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
    }
}
