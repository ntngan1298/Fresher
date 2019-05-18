using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebApi.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        private SqlConnection _conn;
        protected readonly IUnitOfWork _uow;

        /// <summary>
        /// Constructure
        /// </summary>
        /// <param name="uow">Unit of work</param>
        /// Created by: NVMANH (01/02/2018)
        public BaseRepository(IUnitOfWork uow)
        {
            if (uow == null) throw new ArgumentNullException("unitOfWork");
            _uow = uow;
            _conn = _uow.DataContext.Connection;
        }
        #region BASE
        /// <summary>
        /// Get List Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strProc"></param>
        /// <returns></returns>
        public List<T> GetListObject<T>(string strProc)
        {
            List<T> lstObject = new List<T>();
            try
            {
                using (SqlCommand cmd = _conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = strProc;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var oObject = Activator.CreateInstance<T>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                string fieldName = reader.GetName(i);
                                if (oObject.GetType().GetProperty(fieldName) != null && reader[fieldName] != DBNull.Value)
                                {
                                    oObject.GetType().GetProperty(fieldName).SetValue(oObject, reader[fieldName], null);
                                }
                            }
                            lstObject.Add(oObject);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return lstObject;
        }

        /// <summary>
        /// Lấy danh sách một đối tượng theo các tham số truyền vào
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="value">mảng các tham số truyền vào</param>
        /// create by: manhnv
        /// create date: 30/06/2015
        /// <returns></returns>
        public List<T> GetListObjext<T>(string sql, object[] value)
        {
            List<T> lstObject = new List<T>();
            try
            {
                using (var cmd = _conn.CreateCommand())
                {
                    //SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sql;

                    //Gán giá trị tham số:
                    SqlCommandBuilder.DeriveParameters(cmd);
                    foreach (SqlParameter p in cmd.Parameters)
                    {
                        var i = cmd.Parameters.IndexOf(p);
                        if (i > 0 && i <= value.Length)
                        {
                            p.Value = value[i - 1];
                        }
                        else if (i > value.Length)
                        {
                            break;
                        }
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var oProduct = Activator.CreateInstance<T>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string fieldName = reader.GetName(i);
                            if (oProduct.GetType().GetProperty(fieldName) != null && reader[fieldName] != DBNull.Value)
                            {
                                oProduct.GetType().GetProperty(fieldName).SetValue(oProduct, reader[fieldName], null);
                            }
                        }
                        lstObject.Add(oProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstObject;
        }

        /// <summary>
        /// Lấy danh sách đối tượng theo trang
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="sqlTotal"></param>
        /// <param name="start"></param>
        /// <param name="limit"></param>
        /// <param name="total"></param>
        /// Createby: ManhNV
        /// Createdate: 30/06/2015
        public List<T> GetListObjectPaging<T>(string sql, string sqlTotal, int start, int limit, out int total)
        {
            List<T> lstObject = new List<T>();
            total = 0;
            try
            {
                using (var cmd = _conn.CreateCommand())
                {
                    //SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sort", "");
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@limit", limit);
                    cmd.Parameters.Add("@outValue", SqlDbType.Int);
                    cmd.Parameters["@outValue"].Direction = ParameterDirection.Output;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var oObject = Activator.CreateInstance<T>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string fieldName = reader.GetName(i);
                            if (oObject.GetType().GetProperty(fieldName) != null && reader[fieldName] != DBNull.Value)
                            {
                                oObject.GetType().GetProperty(fieldName).SetValue(oObject, reader[fieldName], null);
                            }
                        }
                        lstObject.Add(oObject);
                    }
                    //conn.Close();

                    //conn.Open();
                    SqlCommand cmd2 = new SqlCommand(sqlTotal, _conn);
                    total = (int)cmd2.ExecuteScalar();
                }
                //conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstObject;
        }

        /// <summary>
        /// Thêm, sửa dữ liệu. Trả về trạng thái.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="sql"></param>
        /// <param name="isEdit"></param>
        /// Người tạo: ManhNV
        /// Ngày tạo: 30/06/2015
        /// <returns></returns>
        public int UpdateDataObject<T>(T oObject, string sql)
        {
            try
            {
                using (SqlCommand cmd = _conn.CreateCommand())
                {
                    //SqlCommand cmd = new SqlCommand(sql, conn);
                    //cmd = new SqlCommand(sql, _conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sql;
                    SqlCommandBuilder.DeriveParameters(cmd);
                    foreach (SqlParameter item in cmd.Parameters)
                    {
                        if (oObject.GetType().GetProperty(item.ParameterName.Replace("@", string.Empty)) != null)
                        {
                            item.Value = oObject.GetType().GetProperty(item.ParameterName.Replace("@", string.Empty)).GetValue(oObject, null);
                        }
                        else
                        {
                            item.Value = DBNull.Value;
                        }
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete record objext object, return true or false
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="Nparameter"></param>
        /// Create by: manhnv
        /// Create date: 30/06/2015
        /// <returns></returns>
        public int DeleteData(string sql, string[] name, object[] value, int Nparameter)
        {
            var result = 0;
            try
            {
                using (var cmd = _conn.CreateCommand())
                {
                    //SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sql;
                    for (int i = 0; i < Nparameter; i++)
                    {
                        cmd.Parameters.AddWithValue(name[i], value[i]);
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Xóa dữ liệu với nhiều tham số đầu vào
        /// </summary>
        /// <param name="sql">Tên store</param>
        /// <param name="param">Mảng các tham số</param>
        /// <returns></returns>
        /// Created by: NVMANH ()
        public int DeleteData(string sql, object[] param)
        {
            var result = 0;
            try
            {
                using (var cmd = _conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sql;
                    SqlCommandBuilder.DeriveParameters(cmd);

                    int countParameters = cmd.Parameters.Count - 1; // Bỏ qua param @RETURN_VALUE của các store
                    if (param.Length >= countParameters)
                    {
                        for (int i = 1; i <= countParameters; i++)
                        {
                            cmd.Parameters[i].Value = param[i-1];
                        }
                    }
                    else
                    {
                        throw new System.ArgumentException("Tham số đầu vào cho store không đủ", "Erro");
                    }
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        #endregion

        #region "GetData"
        /// <summary>
        /// Lấy thông tin đối tượng theo ID của đối tượng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectID"></param>
        /// <returns></returns>
        public T GetObjectByObjectID<T>(object objectID)
        {
            string strProc = (new GenerateProcUtility()).GetObjectByObjectID<T>();
            return GetListObjext<T>(strProc, (new object[] { objectID })).FirstOrDefault();
        }
        /// <summary>
        /// Lấy danh sách chứa toàn bộ các đối tượng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetListObject<T>()
        {
            string strProc = (new GenerateProcUtility()).GetListObject<T>();
            return GetListObject<T>(strProc);
        }

        /// <summary>
        /// Lấy danh sách đối tượng theo tham số (test)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        public List<T> GetListObjectByMultiParam<T>(object param)
        {
            string strProc = (new GenerateProcUtility()).GetListObjectByMultiParam<T>();
            return GetListObjext<T>(strProc, (new object[] { param }));
        }

        /// <summary>
        /// Lấy danh sách chứa toàn bộ các đối tượng dựa theo các tham số được truyền vào
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<T> GetListObject<T>(object[] arrParam)
        {
            string strProc = (new GenerateProcUtility()).GetListObject<T>();
            return GetListObjext<T>(strProc, arrParam);
        }
        #endregion

        #region "Update/Insert Data"
        public int UpdateObject<T>(T oObject)
        {
            string strProc = (new GenerateProcUtility()).UpdateObject<T>();
            return UpdateDataObject<T>(oObject, strProc);
        }

        public int InsertObject<T>(T oObject)
        {
            string strProc = (new GenerateProcUtility()).InsertObject<T>();
            return UpdateDataObject<T>(oObject, strProc);
        }

        /// <summary>
        /// Xóa đối tượng theo id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        /// Created by: NVMANH (05/03/2018)
        public int DeleteObjectByID<T>(object id)
        {
            string strProc = (new GenerateProcUtility()).DeleteObjectByID<T>();
            var oObject = Activator.CreateInstance<T>();
            string tableName = oObject.GetType().Name;
            return DeleteData(strProc, new object[] { id });
        }

        /// <summary>
        /// Xóa đối tượng theo với nhiều tham số đầu vào
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <returns></returns>
        /// Created by: NVMANH (05/03/2018)
        public int DeleteObjectByMultiParam<T>(object[] param)
        {
            string strProc = (new GenerateProcUtility()).DeleteObjectByID<T>();
            var oObject = Activator.CreateInstance<T>();
            string tableName = oObject.GetType().Name;
            return DeleteData(strProc, new object[] { param });
        }
        #endregion

        //************************************************************************************
        #region OTHER
        public int Insert(T entity)
        {
            int i = 0;
            try
            {
                using (var cmd = _conn.CreateCommand())
                {
                    //InsertCommandParameters(entity, cmd);
                    i = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public int Update(T entity)
        {
            int i = 0;
            using (var cmd = _conn.CreateCommand())
            {

                //UpdateCommandParameters(entity, cmd);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }


        public int Delete(T entity)
        {
            int i = 0;
            using (var cmd = _conn.CreateCommand())
            {

                //DeleteCommandParameters(entity, cmd);
                i = cmd.ExecuteNonQuery();
            }
            return i;
        }



        public IEnumerable<T> GetAll()
        {
            using (var cmd = _conn.CreateCommand())
            {

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    return Maps(reader);
                }
            }
        }

        protected virtual void InsertCommandParameters(T entity, SqlCommand cmd) { }
        protected virtual void UpdateCommandParameters(T entity, SqlCommand cmd) { }
        protected virtual void DeleteCommandParameters(T entity, SqlCommand cmd) { }
        protected virtual T Map(SqlDataReader reader) { return null; }
        protected virtual List<T> Maps(SqlDataReader reader) { return null; }
        #endregion
    }
}
