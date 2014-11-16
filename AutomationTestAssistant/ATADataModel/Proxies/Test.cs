using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATADataModel
{
    using System;
    using System.Collections.Generic;

    public partial class Test : IEquatable<string>
    {
        public bool Equals(string other)
        {
            return this.MethodId.Equals(other);
        }
    }
}
