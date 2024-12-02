namespace Infrastructure.Options;

public class ReportOptions
{
    public const string Key = "ReportSettings";

    public string? PdfWatermark { get; init; }
    public string? ExcelTemplate { get; init; }
}