using System;
using Rage;
using RAGENativeUI;
using RAGENativeUI.Elements;
using System.Windows.Forms;

namespace Officer_Status_Plugin
{
    public class Menu
    {
        private static UIMenuItem menu10_7Item;
        private static UIMenuItem menu10_8Item;
        private static UIMenuItem menu10_19Item;
        private static UIMenuItem menu10_58Item;
        private static UIMenuItem menuAffirmativeItem;
        private static UIMenuItem menuNegativeItem;
        private static GameFiber menuProcessFiber;
        private static UIMenu mainMenu;
        private static MenuPool _MenuPool;

        public static void Main()
        {
            menuProcessFiber = new GameFiber(MenuProcess);
            _MenuPool = new MenuPool();
            mainMenu = new UIMenu("~r~Officer Status Menu", "By " + Globals.author);

            _MenuPool.Add(mainMenu);

            mainMenu.AddItem(menu10_7Item = new UIMenuItem(">>10-7<<", "Unavailable for Calls"));
            mainMenu.AddItem(menu10_8Item = new UIMenuItem(">>10-8<<", "Available for Calls"));
            mainMenu.AddItem(menu10_19Item = new UIMenuItem(">>10-19<<", "Returning to Station"));
            mainMenu.AddItem(menu10_58Item = new UIMenuItem(">>10-58<<", "Normal Traffic Stop"));
            mainMenu.AddItem(menuAffirmativeItem = new UIMenuItem(">>Affirmative<<"));
            mainMenu.AddItem(menuNegativeItem = new UIMenuItem(">>Negative<<"));
            mainMenu.RefreshIndex();

            mainMenu.OnItemSelect += OnItemSelect;

            mainMenu.AllowCameraMovement = true;
            mainMenu.MouseControlsEnabled = false;

            menuProcessFiber.Start();
            Game.Console.Print(Globals.PluginName + ": Menus Initialised");
        }

        private static void OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            Statuses statuses = new Statuses();
            if (sender == mainMenu)
            {
                if (selectedItem == menu10_7Item)
                {
                    statuses.ShowMe10_7();
                }
                else if (selectedItem == menu10_8Item)
                {
                    statuses.ShowMe10_8();
                }
                else if (selectedItem == menu10_19Item)
                {
                    statuses.ShowMe10_19();
                }
                else if (selectedItem == menu10_58Item)
                {
                    statuses.ShowMe10_58();
                }
                else if (selectedItem == menuAffirmativeItem)
                {
                    statuses.Affirmative();
                }
                else if (selectedItem == menuNegativeItem)
                {
                    statuses.Negative();
                }
            }
        }

        private static void MenuProcess()
        {
            while(true)
            {
                GameFiber.Yield();
                if (Game.IsKeyDown(Globals.menuKey))
                {
                    mainMenu.Visible = !mainMenu.Visible;

                }
                _MenuPool.ProcessMenus();
            }
        }

        public static void Stop()
        {
            _MenuPool.CloseAllMenus();
            menuProcessFiber.Abort();
        }
    }
}