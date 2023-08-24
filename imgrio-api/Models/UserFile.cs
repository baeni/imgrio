using HeyRed.Mime;

namespace imgrio_api.Models
{
    public class UserFile
    {
        public UserFile(
            Guid id,
            string author,
            string title,
            string type,
            long size,
            string url,
            bool isSelfHosted,
            DateTime dateOfCreation)
        {
            Id = id;
            Author = author;
            Title = title;
            Type = type;
            Size = size;
            Url = url;
            IsSelfHosted = isSelfHosted;
            DateOfCreation = dateOfCreation;
        }

        public Guid Id { get; private set; }
        public string Author { get; private set; }
        public string Title { get; private set; }
        public string Type { get; private set; }
        public long Size { get; private set; }
        public string Url { get; private set; }
        public bool IsSelfHosted { get; private set; }
        public DateTime DateOfCreation { get; private set; }

        public override string ToString()
        {
            return $"{Id}.{MimeTypesMap.GetExtension(Type)}";
        }
    }
}