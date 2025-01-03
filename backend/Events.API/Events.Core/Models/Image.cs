namespace Events.Core.Models
{
    public class Image
    {
        private Image(Guid id, Guid eventId, string fileName)
        {
            Id = id;
            FileName = fileName;
            EventId = eventId;
        }

        public Guid Id { get; }

        public Guid EventId { get; }

        public string FileName { get; }

        public static Image Create(Guid id, Guid eventId, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new Exception("File name cannot be null");

            return new Image(id, eventId, fileName);
        }
    }
}
