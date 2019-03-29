using Rage;
using RAGENativeUI;
using RAGENativeUI.Elements;
using System.Drawing;

namespace Officer_Status_Plugin.NorthCarolina
{
    internal class Menu
    {
        private static UIMenuItem menuGeneralItem;
        private static UIMenuItem menuServiceItem;
        private static UIMenuItem menuBackupItem;

        private static UIMenuItem menu10_5Item;
        private static UIMenuItem menu10_6Item;
        private static UIMenuItem menu10_7Item;
        private static UIMenuItem menu10_8Item;
        private static UIMenuListItem menu10_11List;
        private static object[] List10_11 = new object[] { "Occupied x1", "Occupied x2", "Occupied x3", "Occupied x4" };
        private static UIMenuItem menu10_15Item;
        private static UIMenuItem menu10_19Item;
        private static UIMenuItem menu10_23Item;
        private static UIMenuListItem menu10_32List;
        private static object[] List10_32 = new object[] { "Code 2", "Code 3", "Female"};
        private static UIMenuItem menu10_41Item;
        private static UIMenuItem menu10_42Item;
        private static UIMenuItem menu10_51Item;
        private static UIMenuItem menu10_52Item;
        private static UIMenuItem menu10_53Item;
        private static UIMenuItem menu10_71Item;
        private static UIMenuItem menu10_99Item;
        private static UIMenuItem menuAffirmativeItem;
        private static UIMenuItem menuNegativeItem;
        private static UIMenuItem menuCode5Item;

        private static GameFiber menuProcessFiber;
        private static UIMenu mainMenu;
        private static UIMenu serviceMenu;
        private static UIMenu generalMenu;
        private static UIMenu backupMenu;
        private static MenuPool _MenuPool;

        internal static void MainMenu()
        {
            mainMenu = new UIMenu("Officer Status Menu", "" + Globals.Unit);
            mainMenu.SetMenuWidthOffset(10);

            _MenuPool.Add(mainMenu);

            mainMenu.AddItem(menuGeneralItem = new UIMenuItem("General Statuses"));
            mainMenu.BindMenuToItem(generalMenu, menuGeneralItem);
            generalMenu.ParentMenu = mainMenu;
            mainMenu.AddItem(menuServiceItem = new UIMenuItem("Service Statuses"));
            mainMenu.BindMenuToItem(serviceMenu, menuServiceItem);
            serviceMenu.ParentMenu = mainMenu;
            mainMenu.AddItem(menuBackupItem = new UIMenuItem("Backup Statuses"));
            mainMenu.BindMenuToItem(backupMenu, menuBackupItem);
            backupMenu.ParentMenu = mainMenu;
            mainMenu.AddItem(menu10_99Item = new UIMenuItem("Panic"));
            menu10_99Item.BackColor = Color.Red;
            menu10_99Item.HighlightedBackColor = Color.Red;

            mainMenu.RefreshIndex();

            mainMenu.OnItemSelect += OnItemSelect;

            mainMenu.AllowCameraMovement = true;
            mainMenu.MouseControlsEnabled = false;
        }

        internal static void ServiceMenu()
        {
            serviceMenu = new UIMenu("Service Status Menu", "" + Globals.Unit);
            serviceMenu.SetMenuWidthOffset(10);
            _MenuPool.Add(serviceMenu);

            serviceMenu.AddItem(menu10_5Item = new UIMenuItem(">>10-5", "~g~Break"));
            serviceMenu.AddItem(menu10_6Item = new UIMenuItem(">>10-6", "~g~Busy"));
            serviceMenu.AddItem(menu10_7Item = new UIMenuItem(">>10-7", "~g~Out of Service"));
            serviceMenu.AddItem(menu10_8Item = new UIMenuItem(">>10-8", "~g~Available for Calls"));
            serviceMenu.AddItem(menu10_41Item = new UIMenuItem(">>10-41", "~g~Beginning Tour of Duty"));
            serviceMenu.AddItem(menu10_42Item = new UIMenuItem(">>10-42", "~g~Ending Tour of Duty"));

            serviceMenu.RefreshIndex();

            serviceMenu.OnItemSelect += OnItemSelect;


            serviceMenu.AllowCameraMovement = true;
            serviceMenu.MouseControlsEnabled = false;
        }

        internal static void GeneralMenu()
        {
            generalMenu = new UIMenu("General Status Menu", "" + Globals.Unit);
            generalMenu.SetMenuWidthOffset(10);
            _MenuPool.Add(generalMenu);

            generalMenu.AddItem(menu10_11List = new UIMenuListItem(">>10-11", "~g~Traffic Stop", List10_11));
            generalMenu.AddItem(menu10_15Item = new UIMenuItem(">>10-15", "~g~Suspect in Custody, Returning to Station"));
            generalMenu.AddItem(menu10_19Item = new UIMenuItem(">>10-19", "~g~Returning to Station"));
            generalMenu.AddItem(menu10_23Item = new UIMenuItem(">>10-23", "~g~Arrived on Scene"));
            generalMenu.AddItem(menuCode5Item = new UIMenuItem(">>Code 5", "~g~Felony Stop"));
            generalMenu.AddItem(menuAffirmativeItem = new UIMenuItem(">>Affirmative"));
            generalMenu.AddItem(menuNegativeItem = new UIMenuItem(">>Negative"));

            generalMenu.RefreshIndex();
            generalMenu.OnItemSelect += OnItemSelect;

            generalMenu.AllowCameraMovement = true;
            generalMenu.MouseControlsEnabled = false;
        }

        internal static void BackupMenu()
        {
            backupMenu = new UIMenu("Backup Status Menu", "" + Globals.Unit);
            backupMenu.SetMenuWidthOffset(10);
            _MenuPool.Add(backupMenu);

            backupMenu.AddItem(menu10_32List = new UIMenuListItem(">>10-32", "~g~General Backup", List10_32));
            backupMenu.AddItem(menu10_51Item = new UIMenuItem(">>10-51", "~g~Request a Tow Truck"));
            backupMenu.AddItem(menu10_52Item = new UIMenuItem(">>10-52", "~g~Request an EMS"));
            backupMenu.AddItem(menu10_53Item = new UIMenuItem(">>10-53", "~g~Request Fire Department"));
            backupMenu.AddItem(menu10_71Item = new UIMenuItem(">>10-71", "~g~Request Supervisor"));

            backupMenu.RefreshIndex();
            backupMenu.OnItemSelect += OnItemSelect;

            backupMenu.AllowCameraMovement = true;
            backupMenu.MouseControlsEnabled = false;
        }

        internal static void Main()
        {
            menuProcessFiber = new GameFiber(MenuProcess);
            _MenuPool = new MenuPool();

            MainMenu();
            ServiceMenu();
            GeneralMenu();
            BackupMenu();

            menuProcessFiber.Start();
            Game.Console.Print(Globals.PluginName + ": Menus Initialised");
        }

        private static void OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            General general = new General();
            Backup backup = new Backup();
            Services services = new Services();
            TrafficStop trafficStop = new TrafficStop();

            if (sender == generalMenu && selectedItem == menu10_11List) { } else { _MenuPool.CloseAllMenus(); }
            if(sender == mainMenu)
            {
                if(selectedItem == menu10_99Item)
                {
                    general.ShowMe10_99();
                }
            }
            if(sender == generalMenu)
            {
                if (selectedItem == menu10_11List)
                {
                    string selectedListItem = menu10_11List.SelectedItem.ToString();
                    if (selectedListItem == "Occupied x1")
                    {
                        trafficStop.ShowMe10_11O1();
                    }
                    if (selectedListItem == "Occupied x2")
                    {
                        trafficStop.ShowMe10_11O2();
                    }
                    if (selectedListItem == "Occupied x3")
                    {
                        trafficStop.ShowMe10_11O3();
                    }
                    if (selectedListItem == "Occupied x4")
                    {
                        trafficStop.ShowMe10_11O4();
                    }
                }
                else if (selectedItem == menu10_15Item) { general.ShowMe10_15(); }
                else if (selectedItem == menu10_19Item) { general.ShowMe10_19(); }
                else if (selectedItem == menu10_23Item) { general.ShowMe10_23(); }
                else if (selectedItem == menuCode5Item) { trafficStop.ShowMeCode5(); }
                else if (selectedItem == menuAffirmativeItem) { general.Affirmative(); }
                else if (selectedItem == menuNegativeItem) { general.Negative(); }
            }
            if(sender == serviceMenu)
            {
                if (selectedItem == menu10_5Item) { services.ShowMe10_5();  }
                else if (selectedItem == menu10_6Item) { services.ShowMe10_6(); }
                else if (selectedItem == menu10_7Item) { services.ShowMe10_7(); }
                else if (selectedItem == menu10_8Item) { services.ShowMe10_8(); }
                else if (selectedItem == menu10_41Item) { services.ShowMe10_41(); }
                else if (selectedItem == menu10_42Item) { services.ShowMe10_42(); }
            }
            if(sender == backupMenu)
            {
                if (selectedItem == menu10_32List)
                {
                    string selectedListItem = menu10_32List.SelectedItem.ToString();
                    if (selectedListItem == "Code 2")
                    {
                        backup.Requesting10_32C2();
                    }
                    else if (selectedListItem == "Code 3")
                    {
                        backup.Requesting10_32C3();
                    }
                    else if (selectedListItem == "Female")
                    {
                        backup.Requesting10_32F();
                    }
                }
                else if(selectedItem == menu10_51Item)
                {
                    backup.Requesting10_51();
                }
                else if(selectedItem == menu10_52Item)
                {
                    backup.Requesting10_52();
                }
                else if(selectedItem == menu10_53Item)
                {
                    backup.Requesting10_53();
                }
                else if (selectedItem == menu10_71Item)
                {
                    backup.Requesting10_71();
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

        internal static void Stop()
        {
            _MenuPool.CloseAllMenus();
            menuProcessFiber.Abort();
        }
    }
}