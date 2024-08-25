namespace RobinCanlas.Models
{
    public class GetAllFlickr
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Thumbnail { get; set; }
        public string Url { get; set; }
        public string Src { get; set; }
        public string Raw { get; set; }
        public string Original { get; set; }
    }

    public class GetAllFlickrApi
    {
        public string Id { get; set; }
        public string Owner { get; set; }
        public string Secret { get; set; }
        public string Server { get; set; }
        public int Farm { get; set; }
        public string Title { get; set; }
        public int Ispublic { get; set; }
        public int Isfriend { get; set; }
        public int Isfamily { get; set; }
        public string Url_o { get; set; }
        public int Height_o { get; set; }
        public int Width_o { get; set; }
    }

    public class FlickrPhoto
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public List<GetAllFlickrApi> Photo { get; set; }
    }

    public class FlickrPhotos
    {
        public FlickrPhoto Photos { get; set; }
    }

    public class FlickrPhotosData
    {
        public FlickrPhotos Data { get; set; }
    }
}
