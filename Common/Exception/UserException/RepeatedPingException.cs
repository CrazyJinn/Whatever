using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Msg;

namespace Common.Exception
{
    /// <summary>
    /// 虽然我不是真的认为Ping会重复，但还是加上为好
    /// </summary>
    public class RepeatedPingException : ApplicationException
    {
        public string OutMsg { get; private set; }

        public RepeatedPingException(string message)
            : base(message) {
            this.OutMsg = UserErrorMsg.RepeatedPingOut;
            MyEmail.Send(Message);
        }
    }
}
