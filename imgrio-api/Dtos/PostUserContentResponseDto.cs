using imgrio_api.Entities;

namespace imgrio_api.Dtos
{
    public class PostUserContentResponseDto
    {
        public PostUserContentResponseDto(UserContent userContent, string url)
        {
            UserContent = userContent;
            Url = url;
        }

        public UserContent UserContent { get; init; }
        public string Url { get; init; }
    }
}
