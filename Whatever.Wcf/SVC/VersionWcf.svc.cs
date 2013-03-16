using System.Reflection;

namespace Whatever.Wcf
{
    public class VersionWcf : IVersionWcf
    {
        /// <summary>
        /// 获取版本号
        /// </summary>
        public string GetVersion() {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
