using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDS2
{
    public class Extension
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
        /// 关联程序
        /// </summary>
        private string app;
        /// <summary>
        /// 关联程序
        /// </summary>
        public string App
        {
            get { return app; }
            set { app = value; }
        }

        /// <summary>
        /// 是否启用关联
        /// </summary>
        private bool relation;
        /// <summary>
        /// 是否启用关联
        /// </summary>
        public bool Relation
        {
            get { return relation; }
            set { relation = value; }
        }
        
    }
}
