using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using SharpDX;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;

namespace Drawings_EloBuddy
{
     class Program
    {
        public bool disabledraw
        {
            get { return _setting["disab"].Cast<KeyBind>().CurrentValue; }
        }
        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Game_OnGameLoad;
            Game.OnTick += Game_OnTick;
        }

        public static Menu _menu, _setting;
        public static void Game_OnGameLoad(EventArgs args)
        {
            Chat.Print("Degzer Disable Drawings, Activated!");
            _menu = MainMenu.AddMenu("DISABLE DRAWINGS", "disabledrawings");
            _setting = _menu.AddSubMenu("Settings", "settings");
            _setting.AddGroupLabel("Settings");
            _setting.AddLabel("Drawings");
            _setting.Add("disab", new KeyBind("Disable Drawings", false, KeyBind.BindTypes.PressToggle, '-'));
        }
        public static void Game_OnTick(EventArgs args)
        {
            try
            {
                if (_setting["disab"].Cast<KeyBind>().CurrentValue == true)
                {
                    Hacks.DisableDrawings = true;
                    Hacks.DisableTextures = true;
                }
                if (_setting["disab"].Cast<KeyBind>().CurrentValue == false)
                {
                    Hacks.DisableTextures = false;
                    Hacks.DisableDrawings = false;
                }
            }
            catch
            {
                //nothing
            }
        }


    }
}
