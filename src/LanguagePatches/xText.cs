// Decompiled with JetBrains decompiler
// Type: LanguagePatches.xText
// Assembly: LanguagePatches, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 50F499AA-F9C9-4FBB-B5B1-47B4317F08A4
// Assembly location: C:\Users\Yuanyela\Desktop\KSP_ES_3.6 full BETA\GameData\KSP_ESP\LanguagePatches\LanguagePatches.dll

using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

namespace LanguagePatches
{
  [KSPAddon]
  public class xText : MonoBehaviour
  {
    private string directory;
    private static Dictionary<string, string> dict_Field;
    private List<SpriteText> patched;
    private List<SpriteTextRich> patchedRich;
    private TextWriter logger;
    private bool[] finish;

    public xText()
    {
      base.\u002Ector();
    }

    public void Awake()
    {
      if (!Loader.loadCache)
        return;
      xText.LoadDict();
      Directory.CreateDirectory(this.directory);
      this.logger = (TextWriter) new StreamWriter(Path.Combine(this.directory, ((object) (GameScenes) HighLogic.LoadedScene).ToString() + ".log"));
    }

    public void Update()
    {
      if (!Loader.loadCache)
        return;
      if (this.patched.Count < Resources.FindObjectsOfTypeAll(typeof (SpriteText)).Length)
      {
        foreach (SpriteText text in Resources.FindObjectsOfTypeAll(typeof (SpriteText)))
        {
          if (!this.patched.Contains(text))
          {
            this.logger.WriteLine("[SpriteText] " + text.get_Text());
            text.set_Text(xText.Trans(text.get_Text()));
            xFont.FontIfy(text);
            this.patched.Add(text);
            text.UpdateMesh();
          }
        }
      }
      else
        this.finish[0] = true;
      if (this.patchedRich.Count < Resources.FindObjectsOfTypeAll(typeof (SpriteTextRich)).Length)
      {
        foreach (SpriteTextRich text in Resources.FindObjectsOfTypeAll(typeof (SpriteTextRich)))
        {
          if (!this.patchedRich.Contains(text))
          {
            this.logger.WriteLine("[SpriteTextRich] " + text.get_Text());
            text.set_Text(xText.Trans((string) text.text));
            xFont.FontIfy(text);
            this.patchedRich.Add(text);
            text.UpdateMesh();
          }
        }
      }
      else
        this.finish[1] = true;
      if (this.finish[0] && this.finish[1])
        this.logger.Flush();
    }

    public static void LoadDict()
    {
      if (!File.Exists(Loader.path + "Text.xml"))
        return;
      XmlDocument xmlDocument = new XmlDocument();
      xText.dict_Field = new Dictionary<string, string>();
      xmlDocument.Load(Loader.path + "Text.xml");
      foreach (XmlElement xmlElement in xmlDocument.DocumentElement.ChildNodes)
        xText.dict_Field[xmlElement.GetAttribute("name")] = xmlElement.FirstChild.InnerText;
    }

    public static string Trans(string value)
    {
      if (xText.dict_Field == null)
        xText.LoadDict();
      if (xText.dict_Field == null)
        return value;
      return !xText.dict_Field.ContainsKey(value) ? value : xText.dict_Field[value];
    }
  }
}
