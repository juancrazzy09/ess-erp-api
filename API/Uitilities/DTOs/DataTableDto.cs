namespace API.Uitilities.DTOs
{
    public class DataTableRequestDto
    {
        public int id { get; set; }
        public int Draw { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchValue { get; set; }
        public string? Status { get; set; }
    }
    public class DataTableResponseDto<T>
    {
        public int Draw { get; set; }
        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
        public List<T>? Data { get; set; }
    }
}
