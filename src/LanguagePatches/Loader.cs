// Decompiled with JetBrains decompiler
// Type: LanguagePatches.Loader
// Assembly: LanguagePatches, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 50F499AA-F9C9-4FBB-B5B1-47B4317F08A4
// Assembly location: C:\Users\Yuanyela\Desktop\KSP_ES_3.6 full BETA\GameData\KSP_ESP\LanguagePatches\LanguagePatches.dll

using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace LanguagePatches
{
  [KSPAddon]
  public class Loader : MonoBehaviour
  {
    private static string Ipath = "";
    private static string Iimages = "";
    private static string Iraw = "";
    private static string ImustRestart = "";
    private static string IfullLang = "";
    private static string IfullLangEN = "";
    private static string Iversion = "";
    private static string Icredits = "";
    private static string cachePath = "";
    private static string ILangPrefix = "";

    public static bool loadCache
    {
      get
      {
        bool flag = false;
        StreamReader streamReader = new StreamReader(Loader.cachePath);
        string str = streamReader.ReadLine();
        streamReader.Close();
        if (bool.Parse(str) != flag)
          flag = bool.Parse(str);
        return flag;
      }
    }

    public static string path
    {
      get
      {
        return Loader.Ipath;
      }
      set
      {
        Loader.Ipath = value;
      }
    }

    public static string images
    {
      get
      {
        return Loader.Iimages;
      }
      set
      {
        Loader.Iimages = value;
      }
    }

    public static string rawPath
    {
      get
      {
        return Loader.Iraw;
      }
      set
      {
        Loader.Iraw = value;
      }
    }

    public static string mustRestart
    {
      get
      {
        return Loader.ImustRestart;
      }
      set
      {
        Loader.ImustRestart = value;
      }
    }

    public static string fullLang
    {
      get
      {
        return Loader.IfullLang;
      }
      set
      {
        Loader.IfullLang = value;
      }
    }

    public static string credits
    {
      get
      {
        return Loader.Icredits;
      }
      set
      {
        Loader.Icredits = value;
      }
    }

    public static string version
    {
      get
      {
        return Loader.Iversion;
      }
      set
      {
        Loader.Iversion = value;
      }
    }

    public static string fullLangEnglish
    {
      get
      {
        return Loader.IfullLangEN;
      }
      set
      {
        Loader.IfullLangEN = value;
      }
    }

    public static string langPrefix
    {
      get
      {
        return Loader.ILangPrefix;
      }
      set
      {
        Loader.ILangPrefix = value;
      }
    }

    public Loader()
    {
      base.\u002Ector();
    }

    public static void writeCache(bool toggle)
    {
      if (File.Exists(Loader.cachePath))
        File.Delete(Loader.cachePath);
      TextWriter textWriter = (TextWriter) new StreamWriter(Loader.cachePath);
      textWriter.Write(toggle);
      textWriter.Close();
    }

    public void Awake()
    {
      if (Enumerable.Count<ConfigNode>((IEnumerable<ConfigNode>) GameDatabase.get_Instance().GetConfigNodes("LanguagePatches")) == 1)
      {
        ConfigNode configNode = GameDatabase.get_Instance().GetConfigNodes("LanguagePatches")[0];
        Loader.Ipath = configNode.GetValue("path") + "/" + configNode.GetNode("Root").GetValue("script") + "/" + configNode.GetValue("lang");
        Loader.Iimages = configNode.GetValue("path") + "/" + configNode.GetNode("Root").GetValue("images");
        Loader.Iraw = configNode.GetValue("path");
        Loader.ILangPrefix = configNode.GetValue("lang");
        Loader.ImustRestart = configNode.GetNode("Settings").GetValue("mustRestart");
        Loader.IfullLang = configNode.GetNode("Settings").GetValue("fullLang");
        Loader.IfullLangEN = configNode.GetNode("Settings").GetValue("fullLangEnglish");
        Loader.Iversion = configNode.GetNode("Settings").GetValue("version");
        Loader.Icredits = configNode.GetNode("Settings").GetValue("credits");
        Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/" + Loader.Iraw + "/PluginData");
        Loader.cachePath = Loader.Iraw + "/PluginData/CACHE";
        if (File.Exists(Loader.cachePath))
          return;
        Loader.writeCache(true);
      }
      else
        Object.Destroy((Object) this);
    }
  }
}
