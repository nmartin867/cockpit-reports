namespace ServerReports.Core.ViewModels;

public class PaginatedDataViewModel<T>
{
    public IEnumerable<T> Data { get; set; }
    public int TotalCount { get; set; }

    public PaginatedDataViewModel(IEnumerable<T> data, int totalCount)
    {
        Data = data;
        TotalCount = totalCount;
    }
}