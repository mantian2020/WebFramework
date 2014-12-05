using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheFramework;
using CacheFramework.Config;
using CommonHelper;
using DAOFramework;

namespace TestFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //生成memcache.config
            /*
            MemCachedConfigInfo memCachedConfigInfo = new MemCachedConfigInfo();
            memCachedConfigInfo.ApplyMemCached = true;
            memCachedConfigInfo.IntConnections = 3;
            memCachedConfigInfo.LocalCacheTime = 30000;
            memCachedConfigInfo.MaintenanceSleep = 30;
            memCachedConfigInfo.MaxConnections = 1024;
            memCachedConfigInfo.MinConnections = 3;
            memCachedConfigInfo.Nagle = true;
            memCachedConfigInfo.PoolName = "wowo";
            memCachedConfigInfo.ServerList = "127.0.0.1:11211";
            memCachedConfigInfo.SocketConnectTimeout = 1000;
            memCachedConfigInfo.SocketTimeout = 3000;
            Console.WriteLine(SerializeHelper.Serialize(memCachedConfigInfo));
            */
            //TianTianCache.CacheStrategy.AddObject("asdf","12123");
            //Console.WriteLine(TianTianCache.CacheStrategy.RetrieveObject("asdf"));
            IDataHelper dataHelper = new MySqlDataHelper();
            string connstr = "server=10.9.210.33;port=3307;database=wdtorder;user id=Swdtapp;password=OJ3WoZCWGrZuiQ95QOl8;pooling= true;charset=utf8";
            object result = dataHelper.ExecuteScalar(connstr, "SELECT order_id FROM wdt_order_info LIMIT 1");
            Console.WriteLine(result.ToString());

            Console.Read();
        }
    }
}
