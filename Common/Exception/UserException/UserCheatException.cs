using System;
using Common.Msg;
using Common;

namespace Common.Exception
{
    public class UserCheatException : ApplicationException
    {
        public string OutMsg { get; private set; }

        public UserCheatException(string message)
            : base(message) {
        }
    }
}
