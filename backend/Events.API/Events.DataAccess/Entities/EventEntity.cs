using System.Security.Cryptography.X509Certificates;

namespace Events.DataAccess.Entities
{
    public class EventEntity
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;
        
        public string Place { get; set; } = string.Empty;
        
        public string Category {  get; set; } = string.Empty;
        
        public int MaxParticipantCount { get; set; } = 0;
        
        public DateTime Time {  get; set; }
        
        public Guid ImageId { get; set; }

        public ImageEntity? Image { get; set; }
        
        public IList<RegistrationEntity> Registrations { get; set; } = [];
    }
}
