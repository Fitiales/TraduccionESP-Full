// Decompiled with JetBrains decompiler
// Type: DTS_zh.xRead
// Assembly: DTS_zh, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 47EFDD05-99FC-43F3-97A1-47BF48227E44
// Assembly location: C:\Users\Yuanyela\Desktop\KSP_ES_3.6 full BETA\KSP_Data\Managed\DTS_zh.dll

using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace DTS_zh
{
  public class xRead
  {
    private static Dictionary<int, string> dict_zh;
    private static Dictionary<int, string> dict_en;

    public static string doActivate
    {
      get
      {
        string str;
        using (StreamReader streamReader = new StreamReader("GameData/KSP_ESP/PluginData/CACHE"))
          str = streamReader.ReadLine();
        return str;
      }
    }

    public static string Trans(int id)
    {
      if (xRead.dict_zh == null)
        xRead.Loadzh();
      if (xRead.dict_zh.ContainsKey(id))
        return xRead.dict_zh[id];
      if (xRead.dict_en == null)
        xRead.Loaden();
      if (xRead.dict_en.ContainsKey(id))
        return xRead.dict_en[id];
      return "[Not Found " + id.ToString() + "]";
    }

    public static void Loadzh()
    {
      XmlDocument xmlDocument = new XmlDocument();
      xRead.dict_zh = new Dictionary<int, string>();
      if (xRead.doActivate == "True" || xRead.doActivate == "true")
        xmlDocument.Load((Stream) File.OpenRead("GameData/KSP_ESP/xml/es.xml"));
      else
        xmlDocument.Load((Stream) File.OpenRead("GameData/KSP_ESP/xml/en.xml"));
      foreach (XmlNode xmlNode in xmlDocument.DocumentElement.ChildNodes)
      {
        if (xmlNode is XmlElement)
          xRead.dict_zh[int.Parse(((XmlElement) xmlNode).GetAttribute("id"))] = xmlNode.FirstChild.InnerText;
      }
    }

    public static void Loaden()
    {
      XmlDocument xmlDocument = new XmlDocument();
      xRead.dict_en = new Dictionary<int, string>();
      xmlDocument.Load((Stream) File.OpenRead("GameData/KSP_ESP/xml/en.xml"));
      foreach (XmlNode xmlNode in xmlDocument.DocumentElement.ChildNodes)
      {
        if (xmlNode is XmlElement)
          xRead.dict_en[int.Parse(((XmlElement) xmlNode).GetAttribute("id"))] = xmlNode.FirstChild.InnerText;
      }
    }

    public string Test(int a)
    {
      return xRead.Trans(a) ?? (string) null;
    }
  }
}
