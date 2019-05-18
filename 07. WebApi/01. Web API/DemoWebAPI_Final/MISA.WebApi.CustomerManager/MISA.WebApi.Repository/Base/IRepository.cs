using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebApi.Repository
{
    public interface IRepository<T> where T : class
    {
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        IEnumerable<T> GetAll();
        List<T> GetListObject<T>(string strProc);
        List<T> GetListObjext<T>(string sql, object[] value);
        List<T> GetListObjectPaging<T>(string sql, string sqlTotal, int start, int limit, out int total);
        int UpdateDataObject<T>(T oObject, string sql);
        int DeleteData(string sql, string[] name, object[] value, int Nparameter);
    }
}
