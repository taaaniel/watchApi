namespace WatchAppApi.Models;

public class WatchPhotoDto
{
    public Guid Id { get; set; }
    public string Url { get; set; } = default!;
    public string? Description { get; set; }
}

public class ServiceRecordDto
{
    public Guid Id { get; set; }
    public DateOnly ServiceDate { get; set; }
    public string Description { get; set; } = default!;
    public decimal? Cost { get; set; }
    public string? Currency { get; set; }
}

public class BatteryReplacementDto
{
    public Guid Id { get; set; }
    public DateOnly ReplacementDate { get; set; }
    public string? BatteryType { get; set; }
    public decimal? Cost { get; set; }
    public string? Currency { get; set; }
}