namespace BlogApi.Dtos.UserDtos
{
    public class UpdateUserResponseDto
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
