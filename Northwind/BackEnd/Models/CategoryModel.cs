namespace BackEnd.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
    }
}
