using System;
using Common.Msg;
using Common;

namespace Common.Exception
{
    public class RepeatedUsernameException : ApplicationException
    {
        public string OutMsg { get; private set; }

        public RepeatedUsernameException(string message)
            : base(message) {
            this.OutMsg = UserErrorMsg.RepeatedUsernameOut;
            MyEmail.Send(Message);
        }
    }
}
