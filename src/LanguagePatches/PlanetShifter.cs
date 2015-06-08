// Decompiled with JetBrains decompiler
// Type: LanguagePatches.PlanetShifter
// Assembly: LanguagePatches, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 50F499AA-F9C9-4FBB-B5B1-47B4317F08A4
// Assembly location: C:\Users\Yuanyela\Desktop\KSP_ES_3.6 full BETA\GameData\KSP_ESP\LanguagePatches\LanguagePatches.dll

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using UnityEngine;

namespace LanguagePatches
{
  [KSPAddon]
  public class PlanetShifter : MonoBehaviour
  {
    public PlanetShifter()
    {
      base.\u002Ector();
    }

    public Dictionary<string, string> LoadConfig()
    {
      if (!File.Exists(Loader.path + "Body.xml"))
        return (Dictionary<string, string>) null;
      Dictionary<string, string> dictionary = new Dictionary<string, string>();
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(Loader.path + "Body.xml");
      foreach (XmlElement xmlElement in xmlDocument.DocumentElement.ChildNodes)
        dictionary[xmlElement.Name] = xmlElement.InnerText;
      return dictionary;
    }

    private void Start()
    {
      if (!Loader.loadCache)
        return;
      Dictionary<string, string> dictionary = this.LoadConfig();
      if (dictionary != null)
      {
        using (List<CelestialBody>.Enumerator enumerator = ((List<CelestialBody>) FlightGlobals.get_Bodies()).GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            CelestialBody current = enumerator.Current;
            if (Enumerable.Contains<string>((IEnumerable<string>) dictionary.Keys, ((Object) ((Component) current).get_gameObject()).get_name()))
            {
              current.bodyDescription = (__Null) dictionary[((Object) ((Component) current).get_gameObject()).get_name()];
              current.CBUpdate();
            }
          }
        }
      }
    }
  }
}
