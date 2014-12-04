using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Memcached.ClientLibrary;
using CacheFramework.Config;

namespace CacheFramework
{
    public class MemCachedStrategy : ICacheStrategy
    {
        private int m_timeout = 60000;
        #region ICacheStrategy 成员
        /// <summary>
        /// 加入当前对象到缓存中
        /// </summary>
        /// <param name="objId">对象的键值</param>
        /// <param name="o">缓存的对象</param>
        public void AddObject(string objId, object o)
        {
            if (!string.IsNullOrEmpty(objId))
            {
                MemCachedManager.CacheClient.Set(objId, o, DateTime.Now.AddSeconds(TimeOut));
            }
        }

        public void AddObject(string objId, object o, int expire)
        {
            throw new NotImplementedException();
        }

        public void AddObjectWithFileChange(string objId, object o, string[] files)
        {
            throw new NotImplementedException();
        }

        public void AddObjectWithDepend(string objId, object o, string[] dependKey)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 删除缓存对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        public void RemoveObject(string objId)
        {
            if (MemCachedManager.CacheClient.KeyExists(objId))
            {
                MemCachedManager.CacheClient.Delete(objId);
            }
        }
        /// <summary>
        /// 返回一个指定的对象
        /// </summary>
        /// <param name="objId">对象的关键字</param>
        /// <returns>对象</returns>
        public object RetrieveObject(string objId)
        {
            object obj = null;
            if (!string.IsNullOrEmpty(objId))
            {
                obj = MemCachedManager.CacheClient.Get(objId);    
            }
            return obj;
        }

        public int TimeOut
        {
            get
            {
                return m_timeout;
            }
            set
            {
                m_timeout = value;
            }
        }

        public void FlushAll()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
