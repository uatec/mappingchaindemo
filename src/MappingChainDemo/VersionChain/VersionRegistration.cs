using System;

namespace MappingChainDemo.VersionChain
{
    public class VersionRegistration
    {
        public string Version { get; set; }
        public IVersionChainLinkMapper Mapper { get; set; }
    }
}