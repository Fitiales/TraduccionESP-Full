// Decompiled with JetBrains decompiler
// Type: LanguagePatches.xFont
// Assembly: LanguagePatches, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 50F499AA-F9C9-4FBB-B5B1-47B4317F08A4
// Assembly location: C:\Users\Yuanyela\Desktop\KSP_ES_3.6 full BETA\GameData\KSP_ESP\LanguagePatches\LanguagePatches.dll

using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

namespace LanguagePatches
{
  public static class xFont
  {
    private static Dictionary<string, string> fonts = (Dictionary<string, string>) null;

    public static void FontIfy(TextMesh mesh, float size = -1f)
    {
      Font font = Resources.GetBuiltinResource(typeof (Font), "Arial.ttf") as Font;
      Color color = ((Component) mesh).get_renderer().get_sharedMaterial().get_color();
      ((Component) mesh).get_renderer().set_sharedMaterial(font.get_material());
      ((Component) mesh).get_renderer().get_sharedMaterial().set_color(color);
      mesh.set_font(font);
      mesh.set_richText(true);
      if ((double) size == -1.0)
        return;
      mesh.set_text("<size=" + size.ToString() + ">" + mesh.get_text() + "</size>");
    }

    public static void FontIfy(ScreenSafeGUIText text, float size = -1f)
    {
      Font font = Resources.GetBuiltinResource(typeof (Font), "Arial.ttf") as Font;
      ((GUIStyle) text.textStyle).set_font(font);
      ((GUIStyle) text.textStyle).set_richText(true);
      if ((double) size == -1.0)
        return;
      text.text = (__Null) ("<size=" + size.ToString() + ">" + (string) text.text + "</size>");
    }

    public static void FontIfy(SpriteText text)
    {
    }

    public static void FontIfy(SpriteTextRich text)
    {
    }

    private static void GetConfig()
    {
      if (!File.Exists(Loader.path + "Font.xml"))
        return;
      XmlDocument xmlDocument = new XmlDocument();
      xFont.fonts = new Dictionary<string, string>();
      xmlDocument.Load(Loader.path + "Font.xml");
      foreach (XmlElement xmlElement in xmlDocument.DocumentElement.ChildNodes)
        xFont.fonts[xmlElement.GetAttribute("name")] = xmlElement.InnerText;
    }
  }
}
