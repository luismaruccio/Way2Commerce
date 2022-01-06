namespace Way2Commerce.Data.Models.DTOs
{
    public class ViewProductDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Category { get; set; }
    }
}
