namespace RobinCanlas.Models
{
    public class GetAllCloudinaryApi
    {
        public string AssetId { get; set; }
        public string PublicId { get; set; }
        public string Format { get; set; }
        public string Version { get; set; }
        public string ResourceType { get; set; }
        public string Type { get; set; }
        public string CreatedAt { get; set; }
        public long Bytes { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Uri Url { get; set; }
        public Uri SecureUrl { get; set; }
    }

    public class GetAllCloudinaryApiRoot
    {
        public List<GetAllCloudinaryApi> Resources { get; set; }
        public int StatusCode { get; set; }
    }
}