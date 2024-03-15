namespace Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int  DetailsId { get; set; }
        public string Details { get; set; }
        public ProductType ProductType { get; set; }
    }
}