namespace Events.DataAccess.Entities
{
    public class ImageEntity
    {
        public Guid Id { get; set; }
        
        public Guid EventId { get; set; }

        public EventEntity? Event { get; set; }
        
        public string FileName { get; set; } = string.Empty;
    }
}
