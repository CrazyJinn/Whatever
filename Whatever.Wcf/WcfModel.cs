using System.Linq;

namespace Whatever.Wcf
{
    public enum WcfStatus
    {
        /// <summary>
        /// 未知错误
        /// </summary>
        UnknowError = -1,

        QuerySuccessful = 102,
        QueryNoData = 103,
        QueryError = 104,

        AddSuccessful = 151,
        AddFailed = 152,

        UpdateSuccessful = 161,
        UpdateFailed = 162,

        RequestTimeOut = 1,

        /// <summary>
        /// 参数错误
        /// </summary>
        ParameterError = 2,
    }

    public class WcfModel
    {
        public WcfModel() {
            this.Code = WcfStatus.UnknowError;
            this.ErrorMsg = null;
        }
        public WcfStatus Code { get; set; }

        public string ErrorMsg { get; set; }

        public string Data { get; set; }
    }
}