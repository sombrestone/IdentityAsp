using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRep.Infrastructure
{
    public class LogicException : Exception
    {
        public readonly int Code;

        public LogicException (string message,int code = 500) : base(message)
        {
            Code = code;
        }
    }
}
