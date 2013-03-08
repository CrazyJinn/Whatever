using System.Linq;

namespace Whatever.Wcf
{
    //public class Data
    //{
    //    public object POCOdata { get; set; }
    //}

    //public class Status
    //{
    //    public WcfStatus Code { get; set; }

    //    public string ErrorMsg { get; set; }
    //}

    public enum WcfStatus
    {
        UnknowError = -1,
        QuerySuccessful = 102,
        QueryError = 103,

        AddSuccessful = 151,
        AddFailed = 152,

        RequestTimeOut = 1,
        ParameterError = 2,
    }

    public class WcfModel<T>
    {
        public WcfModel()
        {
            this.Code = WcfStatus.UnknowError;
            this.ErrorMsg = null;
        }
        public WcfStatus Code { get; set; }

        public string ErrorMsg { get; set; }

        public T Data { get; set; }
    }

}