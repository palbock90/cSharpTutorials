using System;

namespace Versioning.Contracts
{
    public class ProductResponseV1
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductResponseV2
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
    }
}
