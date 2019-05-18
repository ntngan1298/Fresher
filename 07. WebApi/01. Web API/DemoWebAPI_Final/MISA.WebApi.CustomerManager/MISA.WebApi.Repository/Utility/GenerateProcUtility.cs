using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebApi.Repository
{
    /// <summary>
    /// Sinh các chuỗi tên Store truy vấn dữ liệu
    /// </summary>
    public class GenerateProcUtility
    {
        public string GetObjectByObjectID<T>()
        {
            var oObject = Activator.CreateInstance<T>();
            string tableName = oObject.GetType().Name;
            string strProc = String.Format("dbo.Proc_Get{0}By{0}ID", tableName);
            return strProc;
        }
        public string GetListObject<T>()
        {
            var oObject = Activator.CreateInstance<T>();
            string tableName = oObject.GetType().Name;
            string strProc = String.Format("dbo.Proc_GetList{0}", tableName);
            return strProc;
        }
        public string GetListObjectByMultiParam<T>()
        {
            var oObject = Activator.CreateInstance<T>();
            string tableName = oObject.GetType().Name;
            string strProc = String.Format("dbo.Proc_GetList{0}ByMultiParam", tableName);
            return strProc;
        }
        public string InsertObject<T>()
        {
            var oObject = Activator.CreateInstance<T>();
            string tableName = oObject.GetType().Name;
            string strProc = String.Format("dbo.Proc_Insert{0}", tableName);
            return strProc;
        }
        public string UpdateObject<T>()
        {
            var oObject = Activator.CreateInstance<T>();
            string tableName = oObject.GetType().Name;
            string strProc = String.Format("dbo.Proc_Update{0}", tableName);
            return strProc;
        }
        public string DeleteObjectByID<T>()
        {
            var oObject = Activator.CreateInstance<T>();
            string tableName = oObject.GetType().Name;
            string strProc = String.Format("dbo.Proc_Delete{0}By{0}ID", tableName);
            return strProc;
        }
    }
}
