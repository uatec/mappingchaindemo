namespace MappingChainDemo
{
    public interface IVersionChainLinkMapper
    {
        object DowngradeObject(object upper);
    }
}