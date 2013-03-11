using System;
using Common.Msg;

namespace Common.Exception
{
    public class RepeatedUsernameException : ApplicationException
    {
        public RepeatedUsernameException()
            : base(ErrorMsg.RepeatedUsername)
        {
            //在这里写入一个Log
        }
    }
}
