using System.ComponentModel.DataAnnotations;

public class Registration
{
    public int Id { get; set; }

    [Required]
    public string ParticipantName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public int EventId { get; set; }
    public Event Event { get; set; }
}
