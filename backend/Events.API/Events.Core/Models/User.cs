using System.Security;

namespace Events.Core.Models
{
    public class User
    {
        private readonly List<Event> events = [];

        private User(
            Guid id,
            string firstName,
            string lastName,
            DateTime birthDate,
            string email,
            string passwordHash)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirhtDate = birthDate;
            Email = email;
            PasswordHash = passwordHash;
        }

        public Guid Id { get; }
        
        public string FirstName { get; }
        
        public string LastName {  get; }

        public DateTime BirhtDate { get; }

        public string Email { get; }

        public string PasswordHash { get; }

        public IReadOnlyList<Event> Events => events;

        public static User Create(Guid id, string firstName, string lastName,
            DateTime birthDate, string email, string passwordHash)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new Exception("First name cannot be null");

            if (string.IsNullOrEmpty(lastName))
                throw new Exception("Last name cannot be null");

            if (birthDate > DateTime.Today.AddYears(-18))
                throw new Exception("You must be over 18 years old");

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email cannot be null");

            return new User(id, firstName, lastName, birthDate, email, passwordHash);
        }

    }
}
