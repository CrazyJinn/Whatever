
namespace Common.Msg
{
    public static class UserErrorMsg
    {
        public static string RepeatedUsername = "Username: {0} is Repeated ";
        public static string RepeatedUsernameOut = "出错啦，有重复用户名";

        public static string RepeatedPing = "Username: {0} is Repeated ";
        public static string RepeatedPingOut = "出错啦，Ping重复";

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
