using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CommonClass
{
    /// <summary>
    /// XML帮助类
    /// </summary>
    public class XMLHelper
    {
        public XMLHelper()
        {

        }
        public static void ReadXMLByPath(string path)
        {
            //<1>实例化一个XML文档操作对象.
            XmlDocument doc = new XmlDocument();

            //<2>使用XML对象加载XML.
            doc.Load(path);
            //<3>获取根节点.
            XmlNode root = doc.SelectSingleNode("root");
            //<4>获取根节点下所有子节点.
            XmlNodeList nodeList = root.ChildNodes;
            //<5>遍历输出.
            List<ActiveClass> dataList = new List<ActiveClass>();
            foreach (XmlNode node in nodeList)
            {
                switch (node.Name)
                {
                    case "activeBigClass": getCacheDataOfActive(node); break;
                    case "part": getPartAndCode(node); break;
                    case "codeType": getPartAndCode(node); break;
                    default:
                        break;
                }
            }
            cacheDataHepler.cacheActiveData = dataList;
        }
        /// <summary>
        /// 缓存活动大类数据
        /// </summary>
        /// <param name="node"></param>
        private static void getCacheDataOfActive(XmlNode node)
        {
            ActiveClass ac = new ActiveClass();
            ac.id = Guid.NewGuid();
            int bigCount = node.ChildNodes.Count;
            if (bigCount > 0)
            {
                for (int i = 0; i < bigCount; i++)
                {

                    if (i == 0)
                    {
                        ac.name = node.ChildNodes[0].InnerText;
                    }
                    else
                    {
                        ActiveSmallClass asc = new ActiveSmallClass();
                        asc.id = Guid.NewGuid();
                        int smallCount = node.ChildNodes[i].ChildNodes.Count;
                        if (smallCount > 0)
                        {
                            for (int j = 0; j < smallCount; j++)
                            {
                                if (j == 0)
                                {
                                    asc.name = node.ChildNodes[i].ChildNodes[0].InnerText;
                                }
                                else
                                {
                                    int triggerCount = node.ChildNodes[i].ChildNodes[j].ChildNodes.Count;
                                    for (int k = 0; k < triggerCount; k++)
                                    {
                                        asc.triggers.Add(node.ChildNodes[i].ChildNodes[j].ChildNodes[k].InnerText);
                                    }

                                }
                            }
                        }
                        ac.smList.Add(asc);
                    }

                }
            }
            cacheDataHepler.cacheActiveData.Add(ac);
        }
        /// <summary>
        /// 缓存引入环节数据和代码类型
        /// </summary>
        private static void getPartAndCode(XmlNode node)
        {
            int count = node.ChildNodes.Count;
            List<string> list = new List<string>();
            for (int i = 0; i < count; i++)
            {
                list.Add(node.ChildNodes[i].InnerText);
            }
            if (node.Name == "part")
            {
                cacheDataHepler.partAndCode.Add("part", list);
            }
            else
            {
                cacheDataHepler.partAndCode.Add("codeType", list);
            }
        }
    }
}
