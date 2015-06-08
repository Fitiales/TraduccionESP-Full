// Decompiled with JetBrains decompiler
// Type: LanguagePatches.xSpaceCenter
// Assembly: LanguagePatches, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 50F499AA-F9C9-4FBB-B5B1-47B4317F08A4
// Assembly location: C:\Users\Yuanyela\Desktop\KSP_ES_3.6 full BETA\GameData\KSP_ESP\LanguagePatches\LanguagePatches.dll

using System.IO;
using System.Xml;
using UnityEngine;

namespace LanguagePatches
{
  [KSPAddon]
  public class xSpaceCenter : MonoBehaviour
  {
    private ScreenSafeGUIText SSGT;
    private string vab;
    private string sph;
    private string ac;
    private string ts;
    private string ab;
    private string rwy;
    private string mc;
    private string flg;
    private string rnd;
    private string lnchpd;

    public xSpaceCenter()
    {
      base.\u002Ector();
    }

    private void Start()
    {
      this.SSGT = (ScreenSafeGUIText) Object.FindObjectOfType<ScreenSafeGUIText>();
    }

    private void Update()
    {
      if (!Loader.loadCache || !File.Exists(Loader.path + "SpaceCenter.xml"))
        return;
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(Loader.path + "SpaceCenter.xml");
      bool flag = true;
      if (xmlDocument.DocumentElement.HasAttribute("replaceFont") && !bool.Parse(xmlDocument.DocumentElement.GetAttribute("replaceFont")))
        flag = false;
      foreach (XmlElement xmlElement in xmlDocument.DocumentElement.ChildNodes)
      {
        switch (xmlElement.GetAttribute("building"))
        {
          case "VAB":
            this.vab = xmlElement.InnerText;
            break;
          case "SPH":
            this.sph = xmlElement.InnerText;
            break;
          case "AstronautComplex":
            this.ac = xmlElement.InnerText;
            break;
          case "TrackingStation":
            this.ts = xmlElement.InnerText;
            break;
          case "AdministrationBuilding":
            this.ab = xmlElement.InnerText;
            break;
          case "Runway":
            this.rwy = xmlElement.InnerText;
            break;
          case "FlagPole":
            this.flg = xmlElement.InnerText;
            break;
          case "MissionControl":
            this.mc = xmlElement.InnerText;
            break;
          case "RD":
            this.rnd = xmlElement.InnerText;
            break;
          case "LaunchPad":
            this.lnchpd = xmlElement.InnerText;
            break;
        }
      }
      if ((string) this.SSGT.text != "" || this.SSGT.text != null)
      {
        switch ((string) this.SSGT.text)
        {
          case "Vehicle Assembly Building":
            this.SSGT.text = (__Null) this.vab;
            break;
          case "Astronaut Complex":
            this.SSGT.text = (__Null) this.ac;
            break;
          case "Spaceplane Hangar":
            this.SSGT.text = (__Null) this.sph;
            break;
          case "Flag Pole":
            this.SSGT.text = (__Null) this.flg;
            break;
          case "Research and Development":
            this.SSGT.text = (__Null) this.rnd;
            break;
          case "Tracking Station":
            this.SSGT.text = (__Null) this.ts;
            break;
          case "Launch Pad":
            this.SSGT.text = (__Null) this.lnchpd;
            break;
          case "Runway":
            this.SSGT.text = (__Null) this.rwy;
            break;
          case "Mission Control":
            this.SSGT.text = (__Null) this.mc;
            break;
          case "Administration Building":
            this.SSGT.text = (__Null) this.ab;
            break;
        }
      }
      if (flag)
      {
        if (xmlDocument.DocumentElement.HasAttribute("size"))
          xFont.FontIfy(this.SSGT, float.Parse(xmlDocument.DocumentElement.GetAttribute("size")));
        else
          xFont.FontIfy(this.SSGT, -1f);
      }
    }
  }
}
