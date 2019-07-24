using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClass
{
    public class cacheDataHepler
    {
        /// <summary>
        /// 活动大类、小类、触发因素缓存数据
        /// </summary>
        public static  List<ActiveClass> cacheActiveData = new List<ActiveClass>();
        /// <summary>
        /// 引入环节和代码类型缓存数据
        /// </summary>
        public static Dictionary<string, List<string>> partAndCode = new Dictionary<string, List<string>>();
    }
}
