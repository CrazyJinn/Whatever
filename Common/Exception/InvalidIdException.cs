using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Msg;

namespace Common.Exception
{
    public class InvalidIdException : ApplicationException
    {
        public InvalidIdException() : base(SysErrorMsg.InvalidId) { }
    }
}
