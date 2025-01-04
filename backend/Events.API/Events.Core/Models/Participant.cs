using System.Security;

namespace Events.Core.Models
{
    public class Participant
    {
        private readonly List<Registration> registrations = [];

        private Participant(
            Guid id,
            string firstName,
            string lastName,
            DateTime birthDate,
            string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirhtDate = birthDate;
            Email = email;
        }

        public Guid Id { get; }
        
        public string FirstName { get; }
        
        public string LastName {  get; }

        public DateTime BirhtDate { get; }

        public string Email { get; }

        public IReadOnlyList<Registration> Registrations => registrations;

        public static Participant Create(Guid id, string firstName, string lastName,
            DateTime birthDate, string email)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new Exception("First name cannot be null");

            if (string.IsNullOrEmpty(lastName))
                throw new Exception("Last name cannot be null");

            if (birthDate > DateTime.Today.AddYears(-18))
                throw new Exception("You must be over 18 years old");

            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("Email cannot be null");

            return new Participant(id, firstName, lastName, birthDate, email);
        }

    }
}
