namespace Core.Application.Wrappers;

public record PaginationList<TData>
    where TData : notnull
{
    public IReadOnlyList<TData> Data { get; }
    public int TotalElements { get; }
    public int ItemPerPage { get; }
    public int CurrentPage { get; }
    public int MaxPages { get; }

    public PaginationList(IReadOnlyList<TData> list, int pageNo = 1, int itemPerPage = 5)
    {
        Data = list;
        TotalElements = Data.Count;
        ItemPerPage = itemPerPage;
        CurrentPage = pageNo;
        MaxPages = (int)Math.Ceiling((double)TotalElements / ItemPerPage);
    }
}