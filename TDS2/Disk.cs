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
    }
}
