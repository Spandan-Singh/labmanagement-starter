namespace CapstoneData.Model
{
    public class Lab
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryDbo Category { get; set; }
        public AutherDbo Auther { get; set; }
    }
}
