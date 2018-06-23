namespace MappingChainDemo.Models
{
    public static class OrderVersions
    {
        public static string V1 { get; } = nameof(V1);
        public static string V2 { get; } = nameof(V2);
        public static string V3 { get; } = nameof(V3);

        public static string Latest { get; } = V3;
    }
}
