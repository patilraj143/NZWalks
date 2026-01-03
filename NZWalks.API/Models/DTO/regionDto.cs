namespace NZWalks.API.Models.DTO
{
    public class regionDto
    {
        public Guid id { get; set; }
        public string code { get; set; }

        public string name { get; set; }

        public string? regionImageURL { get; set; }
    }
}
