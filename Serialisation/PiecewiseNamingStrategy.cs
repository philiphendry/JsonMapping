using System;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace JsonMapping.Serialisation
{
    public class PiecewiseNamingStrategy : NamingStrategy
    {
        readonly NamingStrategy baseStrategy;

        public PiecewiseNamingStrategy(NamingStrategy baseStrategy)
        {
            this.baseStrategy = baseStrategy ?? throw new ArgumentNullException();
        }

        protected override string ResolvePropertyName(string name)
        {
            return String.Join(".", name.Split('.')
                .Select(n => baseStrategy.GetPropertyName(n, false)));
        }
    }
}