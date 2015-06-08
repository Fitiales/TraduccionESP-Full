// Decompiled with JetBrains decompiler
// Type: LanguagePatches.xImage
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
  public class xImage : MonoBehaviour
  {
    private static List<string> config;
    private static List<int> LoadedLevels;
    private bool IsOver;

    public xImage()
    {
      base.\u002Ector();
    }

    public static void LoadConfig()
    {
      if (!File.Exists(Loader.path + "Image.xml"))
        return;
      XmlDocument xmlDocument = new XmlDocument();
      xImage.config = new List<string>();
      xmlDocument.Load(Loader.path + "Image.xml");
      foreach (XmlElement xmlElement in xmlDocument.DocumentElement.ChildNodes)
        xImage.config.Add(xmlElement.InnerText);
    }

    private void Start()
    {
      if (!Loader.loadCache)
        return;
      xImage.LoadConfig();
      xImage.LoadedLevels = new List<int>();
    }

    private void Update()
    {
      if (!Loader.loadCache || this.IsOver || xImage.LoadedLevels.Contains(Application.get_loadedLevel()))
        return;
      xImage.LoadedLevels.Add(Application.get_loadedLevel());
      foreach (Material material in (Material[]) Resources.FindObjectsOfTypeAll<Material>())
      {
        Texture texture = material.GetTexture("_MainTex");
        if (!Object.op_Equality((Object) texture, (Object) null) && xImage.config.Contains(((Object) texture).get_name()))
        {
          Texture2D texture2D = new Texture2D(2, 2);
          texture2D.LoadImage(File.ReadAllBytes(KSPUtil.get_ApplicationRootPath() + Loader.images + "/" + ((Object) texture).get_name() + ".png"));
          material.SetTexture("_MainTex", (Texture) texture2D);
          GameObject gameObject = new GameObject("DDOL_" + ((Object) texture).get_name());
          ((Renderer) gameObject.AddComponent<MeshRenderer>()).set_material(material);
          Object.DontDestroyOnLoad((Object) gameObject);
        }
      }
      this.IsOver = true;
    }
  }
}
