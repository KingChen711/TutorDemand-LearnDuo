namespace K17221TutorDemand.Models.QueryParameters;

public abstract class BaseParameters
{
    private const int MaxPageSize = 50;
    private int _pageSize = 10;

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = Math.Min(value, MaxPageSize);
    }

    public int PageNumber { get; set; } = 1;
    public string? OrderBy { get; set; }
    public string? SearchTerm { get; set; }
}