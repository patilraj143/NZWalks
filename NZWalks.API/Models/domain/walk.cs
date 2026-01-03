namespace NZWalks.API.Models.domain
{
    public class walk
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double lengthInKm { get; set; }
        public string? walkImageURL { get; set; }
        public Guid difficultId { get; set; }
        public difficulty difficulty { get; set; }
        public Guid regionId { get; set; }
        public region region { get; set; }
    }
}
