using System.Text.Json.Serialization;

namespace Walmad.Core.src.Parameter;

public class GetAllParams
{
    public int Limit { get; set; } = 120;
    public int Offset { get; set; } = 0;
    public SortType sortType { get; set; } = SortType.byTitle;
    public SortOrder sortOrder { get; set; } = SortOrder.asc;
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortType
{
    byTitle,
    byPrice
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SortOrder
{
    asc,
    desc
}
