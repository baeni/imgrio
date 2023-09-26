using System.ComponentModel.DataAnnotations;
using HeyRed.Mime;

namespace imgrio_api.Entities
{
    public class UserContent : IEntity
    {
        public UserContent(
            Guid id,
            Guid authorId,
            string title,
            string type,
            long size,
            string url,
            DateTime dateOfCreation)
        {
            Id = id;
            AuthorId = authorId;
            Title = title;
            Type = type;
            Size = size;
            Url = url;
            DateOfCreation = dateOfCreation;
        }

        [Key]
        public Guid Id { get; init; }
        public Guid AuthorId { get; init; }

        public string Title { get; init; }
        public string Type { get; init; }
        public long Size { get; init; }
        public string Url { get; init; }
        public DateTime DateOfCreation { get; init; }

        public override string ToString()
        {
            return $"{Id}.{MimeTypesMap.GetExtension(Type)}";
        }
    }
}