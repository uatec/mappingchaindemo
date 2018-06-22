namespace MappingChainDemo
{
    public abstract class VersionChainLinkMapper<TUpper, TLower> : IVersionChainLinkMapper
    {
        public abstract TLower Downgrade(TUpper upperVersion);

        object IVersionChainLinkMapper.DowngradeObject(object upper)
        {
            return this.Downgrade((TUpper) upper);
        }   
    }
}