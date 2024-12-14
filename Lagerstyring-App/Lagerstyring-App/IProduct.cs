namespace Lagerstyring_App
{
    public interface IProduct
    {
        public int Quantity { get; set; }
        public string Name { get; }
        public double Price { get; }
        public string Category { get; set; }

        void PrintInfo(List<IProduct> _products)
        {
        }
    }
}
