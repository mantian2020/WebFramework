using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonHelper;
using Memcached.ClientLibrary;

namespace CacheFramework.Config
{
  public sealed class MemCachedManager
  {
    public enum Stats
    {
      Default,
      Reset,
      Malloc,
      Maps,
      Sizes,
      Slabs,
      Items,
      CachedDump,
      Detail
    }
    private static MemcachedClient mc;
    private static SockIOPool pool;
    private static MemCachedConfigInfo memCachedConfigInfo;
    private static string[] serverList;
    public static string[] ServerList
    {
      get
      {
        return serverList;
      }
      set
      {
        if (value != null)
        {
          serverList = value;
        }
      }
    }
    public static MemcachedClient CacheClient
    {
      get
      {
        if (mc == null)
        {
          CreateManager();
        }
        return mc;
      }
    }
    static MemCachedManager()
    {
      mc = null;
      pool = null;
      memCachedConfigInfo = MemCachedConfigs.GetConfig();
      serverList = null;
      CreateManager();
    }
    private static void CreateManager()
    {
      serverList = StringHelper.SplitString(memCachedConfigInfo.ServerList, ",");
      pool = SockIOPool.GetInstance(memCachedConfigInfo.PoolName);
      pool.SetServers(serverList);
      pool.InitConnections = memCachedConfigInfo.IntConnections;
      pool.MinConnections = memCachedConfigInfo.MinConnections;
      pool.MaxConnections = memCachedConfigInfo.MaxConnections;
      pool.SocketConnectTimeout = memCachedConfigInfo.SocketConnectTimeout;
      pool.SocketTimeout = memCachedConfigInfo.SocketTimeout;
      pool.MaintenanceSleep = (long)memCachedConfigInfo.MaintenanceSleep;
      pool.Failover = memCachedConfigInfo.FailOver;
      pool.Nagle = memCachedConfigInfo.Nagle;
      pool.HashingAlgorithm = HashingAlgorithm.NewCompatibleHash;
      pool.Initialize();
      mc = new MemcachedClient();
      mc.PoolName = memCachedConfigInfo.PoolName;
      mc.EnableCompression = false;
    }
    public static void Dispose()
    {
      if (MemCachedConfigs.GetConfig().ApplyMemCached && pool != null)
      {
        pool.Shutdown();
      }
    }
    public static string GetSocketHost(string key)
    {
      string result = "";
      SockIO sockIO = null;
      try
      {
        sockIO = SockIOPool.GetInstance(memCachedConfigInfo.PoolName).GetSock(key);
        if (sockIO != null)
        {
          result = sockIO.Host;
        }
      }
      finally
      {
        if (sockIO != null)
        {
          sockIO.Close();
        }
      }
      return result;
    }
    public static string[] GetConnectedSocketHost()
    {
      SockIO sockIO = null;
      string text = null;
      string[] array = serverList;
      for (int i = 0; i < array.Length; i++)
      {
        string text2 = array[i];
        if (!StringHelper.StrIsNullOrEmpty(text2))
        {
          try
          {
            sockIO = SockIOPool.GetInstance(memCachedConfigInfo.PoolName).GetConnection(text2);
            if (sockIO != null)
            {
                text = StringHelper.MergeString(text2, text);
            }
          }
          finally
          {
            if (sockIO != null)
            {
              sockIO.Close();
            }
          }
        }
      }
      return StringHelper.SplitString(text, ",");
    }
    public static ArrayList GetStats()
    {
      ArrayList arrayList = new ArrayList();
      string[] array = serverList;
      for (int i = 0; i < array.Length; i++)
      {
        string value = array[i];
        arrayList.Add(value);
      }
      return GetStats(arrayList, Stats.Default, null);
    }
    public static ArrayList GetStats(ArrayList serverArrayList, Stats statsCommand, string param)
    {
      ArrayList arrayList = new ArrayList();
      param = (StringHelper.StrIsNullOrEmpty(param) ? "" : param.Trim().ToLower());
      string command = "stats";
      switch (statsCommand)
      {
        case Stats.Reset:
          command = "stats reset";
          break;
        case Stats.Malloc:
          command = "stats malloc";
          break;
        case Stats.Maps:
          command = "stats maps";
          break;
        case Stats.Sizes:
          command = "stats sizes";
          break;
        case Stats.Slabs:
          command = "stats slabs";
          break;
        case Stats.Items:
          command = "stats";
          break;
        case Stats.CachedDump:
          {
              string[] array = StringHelper.SplitString(param, " ");
              if (array.Length == 2 && StringHelper.IsNumericArray(array))
            {
              command = "stats cachedump  " + param;
            }
            break;
          }
        case Stats.Detail:
          if (string.Equals(param, "on") || string.Equals(param, "off") || string.Equals(param, "dump"))
          {
            command = "stats detail " + param.Trim();
          }
          break;
        default:
          command = "stats";
          break;
      }
      Hashtable hashtable = CacheClient.Stats(serverArrayList);
      foreach (string text in hashtable.Keys)
      {
        arrayList.Add(text);
        Hashtable hashtable2 = (Hashtable)hashtable[text];
        foreach (string text2 in hashtable2.Keys)
        {
          arrayList.Add(text2 + ":" + hashtable2[text2]);
        }
      }
      return arrayList;
    }
  }
}
