
namespace Common.Msg
{
    public static class UserErrorMsg
    {
        public static string RepeatedMsg = "{0}: {1} is Repeated ";
        public static string RepeatedMsgOut = "出错啦，{0}重复";

        public static string CannotFindUserByNameAndPsd = "CannotFindUserByNameAndPsd";
        public static string CannotFindUserByPing = "CannotFindUserByPing";
        public static string CannotFindUserByID = "CannotFindUserByID";

        public static string UserCheat = "User Cheat at {0}";
    }

    public static class TagErrorMsg
    {
        public static string CannotFindTagByID = "CannotFindTagByID";
    }

    public static class SysErrorMsg
    {
        /// <summary>
        /// 非法的ID
        /// </summary>
        public static string InvalidId = "Invalid Id";
    }

    public static class DataBaseErrorMsg
    {
        public static string DataBaseDown = "数据库于 {0} 挂掉了，请立即处理";
    }
}
