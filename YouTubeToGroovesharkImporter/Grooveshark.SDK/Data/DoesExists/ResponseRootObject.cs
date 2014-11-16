using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grooveshark.SDK.Data.DoesExists
{
    /// <summary>
    /// Response returned by DoesExists Method
    /// </summary>
    public class ResponseRootObject : BaseResponseRootObject
    {
        public bool result { get; set; }
    }
}
