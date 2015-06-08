// Decompiled with JetBrains decompiler
// Type: LanguagePatches.xLoading
// Assembly: LanguagePatches, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 50F499AA-F9C9-4FBB-B5B1-47B4317F08A4
// Assembly location: C:\Users\Yuanyela\Desktop\KSP_ES_3.6 full BETA\GameData\KSP_ESP\LanguagePatches\LanguagePatches.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

namespace LanguagePatches
{
  [KSPAddon]
  public class xLoading : MonoBehaviour
  {
    private List<string> mytips;
    private string nowText;
    private float size;
    private TextMesh loadText;
    private Random random;
    private bool fontIfy;

    public xLoading()
    {
      base.\u002Ector();
    }

    private void Start()
    {
      if (!Loader.loadCache || !File.Exists(Loader.path + "LoadingTips.xml"))
        return;
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(Loader.path + "LoadingTips.xml");
      foreach (XmlNode xmlNode in xmlDocument.DocumentElement.ChildNodes)
        this.mytips.Add(xmlNode.InnerText ?? "");
      if (xmlDocument.DocumentElement.HasAttribute("size"))
        this.size = float.Parse(xmlDocument.DocumentElement.GetAttribute("size"));
      if (xmlDocument.DocumentElement.HasAttribute("replaceFont"))
        this.fontIfy = bool.Parse(xmlDocument.DocumentElement.GetAttribute("replaceFont"));
    }

    private void Update()
    {
      if (!Loader.loadCache)
        return;
      if (Object.op_Equality((Object) this.loadText, (Object) null))
      {
        GameObject gameObject = GameObject.Find("Text");
        if (Object.op_Equality((Object) gameObject, (Object) null))
          return;
        this.loadText = (TextMesh) gameObject.GetComponent<TextMesh>();
        if ((double) this.size == 0.0)
          this.size = this.loadText.get_characterSize();
      }
      if (this.nowText != this.loadText.get_text())
      {
        int index = this.random.Next(this.mytips.Count);
        this.loadText.set_text("" + this.mytips[index]);
        this.nowText = this.loadText.get_text();
        if (this.mytips.Count > 1)
          this.mytips.RemoveAt(index);
        if (this.fontIfy)
          xFont.FontIfy(this.loadText, this.size);
      }
    }
  }
}
