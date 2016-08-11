using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace AttendanceTools
{
   public static class CommonHelper
    {
       static ConcurrentDictionary<string, string> configDictionary = new ConcurrentDictionary<string, string>();

       /// <summary>
       /// 取出配置文件
       /// </summary>
       /// <param name="xmlstr"></param>
       /// <returns></returns>
       public static string GetConfigData(string xmlstr)
       {
           return configDictionary.GetOrAdd(xmlstr, ConfigurationManager.AppSettings[xmlstr]);
       }

    }
}
