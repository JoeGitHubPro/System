namespace System.DAL.DTOs
{
    public class InvoiceDTO
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ProductOrderItemDTO> Products { get; set; }
    }

}
