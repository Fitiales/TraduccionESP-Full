// Decompiled with JetBrains decompiler
// Type: LanguagePatches.xMenu
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
  internal class xMenu : MonoBehaviour
  {
    private static bool fontIfy = true;
    private bool isOver;

    public xMenu()
    {
      base.\u002Ector();
    }

    public static void TM(TextButton3D tb3D, string text, float size = -1f)
    {
      TextMesh mesh = (TextMesh) ((Component) ((Component) tb3D).get_transform()).GetComponent<TextMesh>();
      mesh.set_text(text);
      if (!xMenu.fontIfy)
        return;
      xFont.FontIfy(mesh, size);
    }

    private void Update()
    {
      if (!Loader.loadCache || (this.isOver || !File.Exists(Loader.path + "Menu.xml")))
        return;
      GameObject gameObject = GameObject.Find("MainMenu");
      if (!Object.op_Equality((Object) gameObject, (Object) null))
      {
        MainMenu mainMenu = (MainMenu) gameObject.GetComponent<MainMenu>();
        foreach (TextMesh mesh in (TextMesh[]) Object.FindObjectsOfType<TextMesh>())
          xFont.FontIfy(mesh, -1f);
        List<string> list = new List<string>();
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(Loader.path + "Menu.xml");
        if (xmlDocument.DocumentElement.HasAttribute("replaceFont"))
          xMenu.fontIfy = bool.Parse(xmlDocument.DocumentElement.GetAttribute("replaceFont"));
        foreach (XmlElement element in xmlDocument.DocumentElement.ChildNodes)
        {
          switch (element.GetAttribute("name"))
          {
            case "backBtn":
              xMenu.TM((TextButton3D) mainMenu.backBtn, element.InnerText, this.GetSize(element));
              break;
            case "startBtn":
              xMenu.TM((TextButton3D) mainMenu.startBtn, element.InnerText, this.GetSize(element));
              ((TextMesh) ((Component) gameObject.get_transform().FindChild("stage 2").FindChild("Header")).GetComponent<TextMesh>()).set_text(element.InnerText);
              break;
            case "settingBtn":
              xMenu.TM((TextButton3D) mainMenu.settingBtn, element.InnerText, this.GetSize(element));
              break;
            case "spaceportBtn":
              xMenu.TM((TextButton3D) mainMenu.spaceportBtn, element.InnerText, this.GetSize(element));
              break;
            case "commBtn":
              xMenu.TM((TextButton3D) mainMenu.commBtn, element.InnerText, this.GetSize(element));
              break;
            case "continueBtn":
              xMenu.TM((TextButton3D) mainMenu.continueBtn, element.InnerText, this.GetSize(element));
              break;
            case "creditsBtn":
              xMenu.TM((TextButton3D) mainMenu.creditsBtn, element.InnerText, this.GetSize(element));
              break;
            case "newGameBtn":
              xMenu.TM((TextButton3D) mainMenu.newGameBtn, element.InnerText, this.GetSize(element));
              break;
            case "quitBtn":
              xMenu.TM((TextButton3D) mainMenu.quitBtn, element.InnerText, this.GetSize(element));
              break;
            case "scenariosBtn":
              xMenu.TM((TextButton3D) mainMenu.scenariosBtn, element.InnerText, this.GetSize(element));
              break;
            case "trainingBtn":
              xMenu.TM((TextButton3D) mainMenu.trainingBtn, element.InnerText, this.GetSize(element));
              break;
            case "KSPsiteURL":
              mainMenu.KSPsiteURL = (__Null) element.InnerText;
              break;
            case "SpaceportURL":
              mainMenu.SpaceportURL = (__Null) element.InnerText;
              break;
          }
        }
        this.isOver = true;
      }
    }

    private float GetSize(XmlElement element)
    {
      if (element.HasAttribute("size"))
        return float.Parse(element.GetAttribute("size"));
      return -1f;
    }
  }
}
