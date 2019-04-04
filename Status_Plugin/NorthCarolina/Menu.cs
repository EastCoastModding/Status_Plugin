﻿using Rage;
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
        private static readonly object[] List10_11 = new object[] { "Occupied x1", "Occupied x2", "Occupied x3", "Occupied x4" };
        private static UIMenuItem menu10_15Item;
        private static UIMenuItem menu10_16Item;
        private static UIMenuItem menu10_19Item;
        private static UIMenuItem menu10_23Item;
        private static UIMenuListItem menu10_32List;
        private static readonly object[] List10_32 = new object[] { "Code 2", "Code 3", "Female", "Traffic Stop", "K9"};
        private static UIMenuItem menu10_38Item;
        private static UIMenuItem menu10_41Item;
        private static UIMenuItem menu10_42Item;
        private static UIMenuItem menu10_51Item;
        private static UIMenuListItem menu10_52Item;
        private static readonly object[] List10_52 = new object[] { "Injuries", "Fatalities" };
        private static UIMenuItem menu10_53Item;
        private static UIMenuItem menu10_71Item;
        private static UIMenuItem menu10_72Item;
        private static UIMenuItem menu10_99Item;
        private static UIMenuItem menuAffirmativeItem;
        private static UIMenuItem menuNegativeItem;
        private static UIMenuItem menuCode5Item;
        private static UIMenuItem menuSignal60Item;

        private static GameFiber menuProcessFiber;
        private static UIMenu mainMenu;
        private static UIMenu serviceMenu;
        private static UIMenu generalMenu;
        private static UIMenu backupMenu;
        private static UIMenu signalMenu;
        private static MenuPool _MenuPool;
        private static UIMenuItem menuSignalItem;

        internal static bool MainMenu()
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
            mainMenu.AddItem(menuSignalItem = new UIMenuItem("Signal Statuses"));
            mainMenu.BindMenuToItem(signalMenu, menuSignalItem);
            signalMenu.ParentMenu = mainMenu;
            mainMenu.AddItem(menu10_99Item = new UIMenuItem("Panic"));
            menu10_99Item.BackColor = Color.Red;
            menu10_99Item.HighlightedBackColor = Color.Red;

            mainMenu.RefreshIndex();

            mainMenu.OnItemSelect += OnItemSelect;

            mainMenu.AllowCameraMovement = true;
            mainMenu.MouseControlsEnabled = false;

            return true;
        }

        internal static bool ServiceMenu()
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

            return true;
        }

        internal static bool GeneralMenu()
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

            return true;
        }

        internal static bool BackupMenu()
        {
            backupMenu = new UIMenu("Backup Status Menu", "" + Globals.Unit);
            backupMenu.SetMenuWidthOffset(10);
            _MenuPool.Add(backupMenu);

            backupMenu.AddItem(menu10_16Item = new UIMenuItem(">>10-16", "~g~Request a Prison Transport"));
            backupMenu.AddItem(menu10_32List = new UIMenuListItem(">>10-32", "~g~Request General Backup", List10_32));
            backupMenu.AddItem(menu10_38Item = new UIMenuItem(">>10-38", "~g~Request Roadblock(Pursuit)"));
            backupMenu.AddItem(menu10_51Item = new UIMenuItem(">>10-51", "~g~Request a Tow Truck"));
            backupMenu.AddItem(menu10_52Item = new UIMenuListItem(">>10-52", "~g~Request an EMS", List10_52));
            backupMenu.AddItem(menu10_53Item = new UIMenuItem(">>10-53", "~g~Request Fire Department"));
            backupMenu.AddItem(menu10_71Item = new UIMenuItem(">>10-71", "~g~Request Supervisor"));
            backupMenu.AddItem(menu10_72Item = new UIMenuItem(">>10-72", "~g~Request Air Unit(Pursuit)"));

            backupMenu.RefreshIndex();
            backupMenu.OnItemSelect += OnItemSelect;

            backupMenu.AllowCameraMovement = true;
            backupMenu.MouseControlsEnabled = false;

            return true;
        }

        internal static bool SignalMenu()
        {
            signalMenu = new UIMenu("Signal Status Menu", "" + Globals.Unit);
            signalMenu.SetMenuWidthOffset(10);
            _MenuPool.Add(signalMenu);

            signalMenu.AddItem(menuSignal60Item = new UIMenuItem(">>Signal 60", "~g~Drugs found"));

            signalMenu.RefreshIndex();
            signalMenu.OnItemSelect += OnItemSelect;

            signalMenu.AllowCameraMovement = true;
            signalMenu.MouseControlsEnabled = false;

            return true;
        }

        internal static void Main()
        {
            menuProcessFiber = new GameFiber(MenuProcess);
            _MenuPool = new MenuPool();

            GameFiber.SleepUntil(ServiceMenu, 1000);
            GameFiber.SleepUntil(GeneralMenu, 1000);
            GameFiber.SleepUntil(BackupMenu, 1000);
            GameFiber.SleepUntil(SignalMenu, 1000);
            GameFiber.SleepUntil(MainMenu, 1000);

            menuProcessFiber.Start();
            Game.Console.Print(Globals.PluginName + ": Menus Initialised");
        }

        private static void OnItemSelect(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if (sender == generalMenu && selectedItem == menu10_11List) { } else { _MenuPool.CloseAllMenus(); }
            if(sender == mainMenu)
            {
                if(selectedItem == menu10_99Item)
                {
                    General.ShowMe10_99();
                }
            }
            if(sender == generalMenu)
            {
                if (selectedItem == menu10_11List)
                {
                    string selectedListItem = menu10_11List.SelectedItem.ToString();
                    if (selectedListItem == "Occupied x1")
                    {
                        TrafficStop.ShowMe10_11O1();
                    }
                    if (selectedListItem == "Occupied x2")
                    {
                        TrafficStop.ShowMe10_11O2();
                    }
                    if (selectedListItem == "Occupied x3")
                    {
                        TrafficStop.ShowMe10_11O3();
                    }
                    if (selectedListItem == "Occupied x4")
                    {
                        TrafficStop.ShowMe10_11O4();
                    }
                }
                else if (selectedItem == menu10_15Item) { General.ShowMe10_15(); }
                else if (selectedItem == menu10_19Item) { General.ShowMe10_19(); }
                else if (selectedItem == menu10_23Item) { General.ShowMe10_23(); }
                else if (selectedItem == menuCode5Item) { TrafficStop.ShowMeCode5(); }
                else if (selectedItem == menuAffirmativeItem) { General.Affirmative(); }
                else if (selectedItem == menuNegativeItem) { General.Negative(); }
            }
            if(sender == serviceMenu)
            {
                if (selectedItem == menu10_5Item) { Services.ShowMe10_5();  }
                else if (selectedItem == menu10_6Item) { Services.ShowMe10_6(); }
                else if (selectedItem == menu10_7Item) { Services.ShowMe10_7(); }
                else if (selectedItem == menu10_8Item) { Services.ShowMe10_8(); }
                else if (selectedItem == menu10_41Item) { Services.ShowMe10_41(); }
                else if (selectedItem == menu10_42Item) { Services.ShowMe10_42(); }
            }
            if(sender == backupMenu)
            {
                if (selectedItem == menu10_16Item)
                {
                    Backup.requesting10_16();
                }
                else if (selectedItem == menu10_32List)
                {
                    string selectedListItem = menu10_32List.SelectedItem.ToString();
                    if (selectedListItem == "Code 2")
                    {
                        Backup.Requesting10_32C2();
                    }
                    else if (selectedListItem == "Code 3")
                    {
                        Backup.Requesting10_32C3();
                    }
                    else if (selectedListItem == "Female")
                    {
                        Backup.Requesting10_32F();
                    }
                    else if (selectedListItem == "Traffic Stop")
                    {
                        Backup.Requesting10_32TS();
                    }
                    else if (selectedListItem == "K9")
                    {
                        Backup.Requesting10_32K9();
                    }
                }
                else if (selectedItem == menu10_38Item)
                {
                    Backup.Requesting10_38();
                }
                else if (selectedItem == menu10_51Item)
                {
                    Backup.Requesting10_51();
                }
                else if (selectedItem == menu10_52Item)
                {
                    string selectedListItem = menu10_32List.SelectedItem.ToString();
                    if (selectedListItem == "Injuries")
                    {
                        Backup.Requesting10_52I();
                    }
                    else if (selectedListItem == "Fatalities")
                    {
                        Backup.Requesting10_52F();
                    }
                }
                else if (selectedItem == menu10_53Item)
                {
                    Backup.Requesting10_53();
                }
                else if (selectedItem == menu10_71Item)
                {
                    Backup.Requesting10_71();
                }
                else if (selectedItem == menu10_72Item)
                {
                    Backup.Requesting10_72();
                }
            }
            if (sender == signalMenu)
            {
                if (selectedItem == menuSignal60Item)
                {
                    Signals.Signal60();
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