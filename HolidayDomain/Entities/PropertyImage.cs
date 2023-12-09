namespace DomainLayer.Entities
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
        public string ImageUrl { get; set; }
    }
}
