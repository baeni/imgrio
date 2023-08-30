using System.ComponentModel.DataAnnotations;

namespace imgrio_api.Models;

public class UserSetting
{
    public UserSetting(
        Guid id,
        Guid userId,
        string key,
        string value)
    {
        Id = id;
        UserId = userId;
        Key = key;
        Value = value;
    }
    
    [Key]
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Key { get; private set; }
    public string Value { get; internal set; }
}