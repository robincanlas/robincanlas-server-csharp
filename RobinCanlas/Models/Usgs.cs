﻿namespace RobinCanlas.Models
{
    public class Usgs
    {

    }

    public class UsgsFeatures
    {
        public string type { get; set; }
        public UsgsProperties properties { get; set; }
        public UsgsGeometry geometry { get; set; }
        public string id { get; set; }
    }

    public class UsgsProperties
    {
        public double mag { get; set; }
        public string place { get; set; }
        public long time { get; set; }
        public long updated { get; set; }
        public int? tz { get; set; }
        public string url { get; set; }
        public string detail { get; set; }
        public int? felt { get; set; }
        public double? cdi { get; set; }
        public double? mmi { get; set; }
        public string? alert { get; set; }
        public string status { get; set; }
        public int tsunami { get; set; }
        public int sig { get; set; }
        public string net { get; set; }
        public string code { get; set; }
        public string ids { get; set; }
        public string sources { get; set; }
        public string types { get; set; }
        public int? nst { get; set; }
        public double? dmin { get; set; }
        public double rms { get; set; }
        public double? gap { get; set; }
        public string magType { get; set; }
        public string type { get; set; }
    }

    public class UsgsGeometry
    {
        public string type { get; set; }
        public double[] coordinates { get; set; }
    }

    public class UsgsGet
    {
        public string type { get; set; }
        public Metadata metadata { get; set; }
        public double[] bbox { get; set; }
        public UsgsFeatures[] features { get; set; }
    }

    public class Metadata
    {
        public long generated { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string api { get; set; }
        public int count { get; set; }
        public int status { get; set; }
    }
}
