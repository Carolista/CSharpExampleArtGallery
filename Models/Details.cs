namespace CSharpExampleArtGallery;

public class Details
{
    public int Id { get; set; }
    public string? YearCreated { get; set; }
    public string? Media { get; set; }
    public string? Description { get; set; }
    public double? Height { get; set; }
    public double? Width { get; set; }
    public double? Depth { get; set; }

    public Details() { }

    public Details(
        string? yearCreated,
        string? media,
        string? description,
        double? height,
        double? width,
        double? depth
    )
    {
        YearCreated = yearCreated;
        Media = media;
        Description = description;
        Height = height;
        Width = width;
        Depth = depth;
    }

    public override bool Equals(object? obj)
    {
        return obj is Details details && Id == details.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public string GetDimensions()
    {
        string inches = '"'.ToString();
        string heightFormatted = Height + inches + "H";
        string widthFormatted = " x " + Width + inches + "W";
        string depthFormatted = Depth > 0 ? " x " + Depth + inches + "D" : "";
        return heightFormatted + widthFormatted + depthFormatted;
    }
}
