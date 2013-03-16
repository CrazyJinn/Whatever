
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
    }

    public static class TagErrorMsg
    {
        public static string CannotFindTagByID = "CannotFindTagByID";
    }

    public static class SysErrorMsg
    {
        public static string InvalidId = "Invalid Id";
    }
}
