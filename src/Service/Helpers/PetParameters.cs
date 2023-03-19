namespace Service.Helpers;

public class PetParameters
{
    const int maxPageSize = 10;
    public string Name { get; set; } = string.Empty;
    public int HealthState { get; set; }
    public string OrderBy { get; set; } = "Name";
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 5;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
    }
}