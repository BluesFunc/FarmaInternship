namespace Core.Application.Wrappers;

public record PaginationList<TData>
    where TData : notnull
{
    private readonly IReadOnlyList<TData> _data;
    public int TotalElements { get; }
    public int ItemPerPage { get; }
    public int CurrentPage { get; }
    public int MaxPages { get; }

    public PaginationList(IReadOnlyList<TData> list, int pageNo = 1, int itemPerPage = 5)
    {
        _data = list;
        TotalElements = _data.Count;
        ItemPerPage = itemPerPage;
        CurrentPage = pageNo;
        MaxPages = (int)Math.Ceiling((double)TotalElements / ItemPerPage);
    }
}