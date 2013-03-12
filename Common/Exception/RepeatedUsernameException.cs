using System;
using Common.Msg;
using Common;

namespace Common.Exception
{
    public class RepeatedUsernameException : ApplicationException
    {
        public RepeatedUsernameException(string message)
            : base(message)
        {
            MyEmail.Send(Message);
        }
    }
}
