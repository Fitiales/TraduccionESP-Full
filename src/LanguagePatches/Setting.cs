// Decompiled with JetBrains decompiler
// Type: LanguagePatches.Setting
// Assembly: LanguagePatches, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 50F499AA-F9C9-4FBB-B5B1-47B4317F08A4
// Assembly location: C:\Users\Yuanyela\Desktop\KSP_ES_3.6 full BETA\GameData\KSP_ESP\LanguagePatches\LanguagePatches.dll

using UnityEngine;

namespace LanguagePatches
{
  [KSPAddon]
  public class Setting : MonoBehaviour
  {
    public static bool toggle = true;

    public Setting()
    {
      base.\u002Ector();
    }

    private void Awake()
    {
      Setting.toggle = Loader.loadCache;
    }

    private void OnGUI()
    {
      GUI.set_skin(HighLogic.get_Skin());
      if (Setting.toggle)
        Setting.toggle = GUI.Toggle(new Rect((float) (Screen.get_width() - 250), 0.0f, 200f, 50f), (Setting.toggle ? 1 : 0) != 0, " " + Loader.fullLang + " (" + Loader.mustRestart + ")");
      else
        Setting.toggle = GUI.Toggle(new Rect((float) (Screen.get_width() - 250), 0.0f, 200f, 50f), Setting.toggle, " English (Needs restart)");
      GUI.Label(new Rect(10f, 10f, 200f, 200f), "Translated in " + Loader.fullLangEnglish + " by " + Loader.credits);
      Loader.writeCache(Setting.toggle);
    }
  }
}
