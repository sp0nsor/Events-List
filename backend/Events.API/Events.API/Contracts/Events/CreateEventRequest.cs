using System.ComponentModel.DataAnnotations;

namespace Events.API.Contracts.Events
{
    public record CreateEventRequest(
        [Required] string Name,
        [Required] string Description,
        [Required] string Place,
        [Required] string Category,
        [Required] int MaxParticipantCount,
        [Required] DateTime Time,
        [Required] IFormFile Image);
}
