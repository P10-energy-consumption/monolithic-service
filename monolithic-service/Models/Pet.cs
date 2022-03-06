namespace monolithic_service.Models
{
    public class Pet
    {
        public int ID { get; set; }
        public PetCategory Category { get; set; }
        public string? Name { get; set; }
        public List<string>? PhotoUrls { get; set; }
        public string? Tags { get; set; }
        public PetStatus Status { get; set; }
    }
}
