namespace NET6.WebApi.Database
{
    public class QueryOptions
    {
        public bool IncludeRelated { get; set; }
        public string Filter { get; set; } = string.Empty;
        public string OrderBy { get; set; } = "Id";
        public int Skip { get; set; } = 0;
        public int Limit { get; set; } = 0;
    }
}
