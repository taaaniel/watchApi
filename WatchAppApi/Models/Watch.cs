namespace WatchAppApi.Models;

public class Watch
{
    public int Id { get; set; }
    public string Brand { get; set; } = default!;
    public string Manufacturer { get; set; } = default!;
    public string Model { get; set; } = default!;
    public string? ReferenceNumber { get; set; }
    public string? SerialNumber { get; set; }
    public WatchMovementType MovementType { get; set; }
    public string? MovementCaliber { get; set; }
    public string? MovementManufacturer { get; set; }
    public WatchCrystalType CrystalType { get; set; }
    public WatchConditionType ConditionType { get; set; }
    public DateOnly? PurchaseDate { get; set; }
    public decimal? PurchasePrice { get; set; }
    public string? Currency { get; set; }
    public string? SellerName { get; set; }
    public string? PurchaseLocation { get; set; }
    public DateOnly? LastServiceDate { get; set; }
    public DateOnly? NextServiceDueDate { get; set; }
    public DateOnly? LastBatteryReplacementDate { get; set; }
    public DateOnly? NextBatteryReplacementDueDate { get; set; }
    public bool HasOriginalBox { get; set; }
    public bool HasOriginalPapers { get; set; }
    public bool IsUnderWarranty { get; set; }
    public DateOnly? WarrantyExpirationDate { get; set; }
    public string? DialColor { get; set; }
    public string? CaseMaterial { get; set; }
    public string? StrapMaterial { get; set; }
    public int? WaterResistanceMeters { get; set; }
    public decimal? CaseDiameterMm { get; set; }
    public decimal? ThicknessMm { get; set; }
    public string? Notes { get; set; }
    public List<WatchPhotoDto> Photos { get; set; } = new();
    public List<ServiceRecordDto> ServiceRecords { get; set; } = new();
    public List<BatteryReplacementDto> BatteryReplacements { get; set; } = new();
}