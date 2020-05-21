
namespace TDS2
{
   public class Disk
    {
        /// <summary>
        /// 名称
        /// </summary>
        private string name;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 网络路径
        /// </summary>
        private string netPath;
        /// <summary>
        /// 网络路径
        /// </summary>
        public string NetPath
        {
            get { return netPath; }
            set { netPath = value; }
        }

        /// <summary>
        /// 本地路径
        /// </summary>
        private string localPath;
        /// <summary>
        /// 本地路径
        /// </summary>
        public string LocalPath
        {
            get { return localPath; }
            set { localPath = value; }
        }

        /// <summary>
        /// 登陆时映射
        /// </summary>
        private string autoMapping;
        /// <summary>
        /// 登陆时映射
        /// </summary>
        public string AutoMapping
        {
            get { return autoMapping; }
            set { autoMapping = value; }
        }

        /// <summary>
        /// 检测断开时重映
        /// </summary>
        private string autoCheck;
        /// <summary>
        /// 检测断开时重映
        /// </summary>
        public string AutoCheck
        {
            get { return autoCheck; }
            set { autoCheck = value; }
        }

        /// <summary>
        /// 映射性质
        /// </summary>
        private string forever;
        /// <summary>
        /// 映射性质
        /// </summary>
        public string Forever
        {
            get { return forever; }
            set { forever = value; }
        }

        /// <summary>
        /// 认证方式
        /// </summary>
        private string windowsAccount;
        /// <summary>
        /// 认证方式
        /// </summary>
        public string WindowsAccount
        {
            get { return windowsAccount; }
            set { windowsAccount = value; }
        }

        /// <summary>
        /// 登陆用户
        /// </summary>
        private string userName;
        /// <summary>
        /// 登陆用户
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// 登陆密码
        /// </summary>
        private string password;
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
