using System.Collections.Generic;
using System.Data;
using System.IO;

namespace TDS2
{
    public class EditorList
    {
        public EditorList()
        {
            DataTable dataTable = SqlFunction.Select("SELECT username FROM UserTable WHERE dept='Z'");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Editor editor = new Editor();
                editor.Name = dataRow[0].ToString();
                editor.EmbPath = Path.Combine(FileSystem.ZFile(), dataRow[0].ToString(), "Emb");
                editor.JpgPath = Path.Combine(FileSystem.ZFile(), dataRow[0].ToString(), "Jpg_Dst");
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
        /// 通过版师编号获取图片文件夹
        /// </summary>
        /// <param name="editor">版师编号</param>
        /// <returns></returns>
        public static string GetJpgFolder(string editor)
        {
            return Path.Combine(FileSystem.ZFile(), editor, "Jpg_Dst");
        }

        /// <summary>
        /// 通过版师编号获取内部格式文件夹
        /// </summary>
        /// <param name="editor">版师编号</param>
        /// <returns></returns>
        public static string GetEmbFolder(string editor)
        {
            return Path.Combine(FileSystem.ZFile(), editor, "Emb");
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
