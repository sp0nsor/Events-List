namespace Events.Core.Models
{
    public class Event
    {
        private readonly List<Registration> registrations = [];

        private Event(
            Guid id,
            string name,
            string description,
            string place,
            DateTime time,
            string category,
            int maxPeopleCount,
            Image image)
        {
            Id = id;
            Name = name;
            Description = description;
            Place = place;
            Time = time;
            Category = category;
            MaxParticipantCount = maxPeopleCount;
            Image = image;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Description { get; }

        public string Place {  get; }

        public DateTime Time { get; }

        public string Category {  get; }

        public int MaxParticipantCount { get; }

        public Image Image { get; }

        public IReadOnlyList<Registration> Registrations => registrations;

        public static Event Create(Guid id, string name, string description,
            string place, DateTime time, string category,
            int maxUsersCount, Image image)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name cannot be null");

            if (string.IsNullOrWhiteSpace(description))
                throw new Exception("Description cannot be null");

            if (string.IsNullOrWhiteSpace(place))
                throw new Exception("Place cannot be null");

            if (string.IsNullOrWhiteSpace(category))
                throw new Exception("Category cannot be null");

            if (maxUsersCount <= 0)
                throw new Exception("People count cannot be negative");

            if (time < DateTime.Now)
                throw new Exception("Date must be longer than today");

            return new Event(id, name, description, place, time, category, maxUsersCount, image);
        }
    }
}
