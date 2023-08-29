using System.ComponentModel.DataAnnotations;

namespace imgrio_api.Models;

public class UserSettings
{
    public UserSettings(
        Guid userId,
        bool imageAnimation,
        string language)
    {
        UserId = userId;
        ImageAnimation = imageAnimation;
        Language = language;
    }
    
    [Key]
    public Guid UserId { get; private set; }
    public bool ImageAnimation { get; set; }
    public string Language { get; set; }
}