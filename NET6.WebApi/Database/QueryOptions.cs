namespace NET6.WebApi.Database
{
    public class QueryOptions
    {
        public bool IncludeRelated { get; set; }
        public string Filter { get; set; } = string.Empty;
        public string OrderBy { get; set; } = string.Empty;
        public int Skip { get; set; }
        public int Limit { get; set; }
    }
}
