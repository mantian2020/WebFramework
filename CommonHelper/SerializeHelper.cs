using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonHelper
{
    public class SerializeHelper
    {
        /// <summary>
        /// 将实体类序列化成json
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="data">实体类型值</param>
        /// <returns>序列化后的json</returns>
        public static string SerializeData<T>(T data)
        {

            string json = JsonConvert.SerializeObject(data);

            return json;
        }

        /// <summary>
        /// 将json反序列化成实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="json">json串</param>
        /// <returns>反序列后的实体类</returns>
        public static T Deserialize<T>(string json)
        {
            T data = (T)JsonConvert.DeserializeObject(json, typeof(T));

            return data;
        }
    }
}
