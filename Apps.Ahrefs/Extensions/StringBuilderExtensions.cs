using System.Text;

namespace Apps.Ahrefs.Extensions;

internal static class StringBuilderExtensions
{
    public static void AppendIfNotEmpty(this StringBuilder builder, string paramName, string? value)
    {
        if (!string.IsNullOrEmpty(value))
            builder.Append($"&{paramName}={value}");
    }
    public static void AppendIfNotEmpty(this StringBuilder builder, string paramName, IEnumerable<string>? values)
    {
        if (values != null && values.Any())
        {
            string stringValues = string.Join(",", values);
            builder.Append($"&{paramName}={stringValues}");
        }
    }
}
