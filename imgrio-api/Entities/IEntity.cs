using System.ComponentModel.DataAnnotations;

namespace imgrio_api.Entities;

public interface IEntity
{
    [Key]
    public Guid Id { get; init; }
    public Guid AuthorId { get; init; }
}
