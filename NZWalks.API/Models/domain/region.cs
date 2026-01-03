namespace NZWalks.API.Models.domain
{
    public class region
    {
        public Guid id { get; set; }
        public string code { get; set; }

        public string name { get; set; }

        public string? regionImageURL { get; set; }
    }
}
