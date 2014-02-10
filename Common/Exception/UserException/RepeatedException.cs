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
    public class RepeatedException : ApplicationException
    {
        public string OutMsg { get; private set; }

        public RepeatedException(string message)
            : base(message) {
            this.OutMsg = UserErrorMsg.RepeatedMsgOut;
            MyEmail.Send(Message);
        }
    }
}
