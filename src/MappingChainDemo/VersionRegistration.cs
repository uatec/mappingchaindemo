using System;

namespace MappingChainDemo
{
    public class VersionRegistration
    {
        public string Version { get; set; }
        public IVersionChainLinkMapper Mapper { get; set; }
    }
}