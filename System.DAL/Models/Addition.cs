namespace System.DAL.Models
{
    public class Addition
    {
        public int AdditionId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
