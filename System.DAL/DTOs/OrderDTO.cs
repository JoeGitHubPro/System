namespace System.DAL.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ProductOrderItemDTO> Products { get; set; }
    }

}
