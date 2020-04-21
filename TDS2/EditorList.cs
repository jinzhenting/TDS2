using System.Collections.Generic;
using System.Data;
using System.IO;

namespace TDS2
{
    public class EditorList
    {
        public EditorList()
        {
            DiskList diskList = new DiskList();
            DataTable dataTable = SqlFunction.Select("SELECT username FROM UserTable WHERE dept='Z'");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Editor editor = new Editor();
                editor.Name = dataRow[0].ToString();
                editor.EmbPath = Path.Combine(diskList.ZFlie.NetPath, dataRow[0].ToString(), "Emb");
                editor.JpgPath = Path.Combine(diskList.ZFlie.NetPath, dataRow[0].ToString(), "Jpg_Dst");
                editors.Add(editor);
                editorsName.Add(dataRow[0].ToString());
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {


        }

        /// <summary>
        /// 打版师列表
        /// </summary>
        private List<Editor> editors = new List<Editor>();
        /// <summary>
        /// 打版师列表
        /// </summary>
        public List<Editor> Editors
        {
            get { return editors; }
            set { editors = value; }
        }

        /// <summary>
        /// 打版师名字列表
        /// </summary>
        private List<string> editorsName = new List<string>();
        /// <summary>
        /// 打版师名字列表
        /// </summary>
        public List<string> EditorsName
        {
            get { return editorsName; }
            set { editorsName = value; }
        }
    }
}
