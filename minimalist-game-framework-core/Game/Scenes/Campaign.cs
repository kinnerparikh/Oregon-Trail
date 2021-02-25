using System;
using System.Collections.Generic;
using System.Text;

namespace Scenes
{
    class Campaign
    {
        private static bool greenp = false;
        private static bool orangep = false;
        private static bool redp = false;
        private static bool yellowp = false;
        private static bool bluep = false;

        private static bool station1 = false;
        private static bool station2 = false;
        private static bool station3 = false;

        private static bool asteroid1 = false;
        private static bool asteroid2 = false;
        private static bool asteroid3 = false;
        private static bool asteroid4 = false;
        private static bool isStarving = false;

        private static float shipX = 180f;
        private static readonly Vector2 size = new Vector2(7313f, 720f);
        public static Vector2 backgroundPos = new Vector2(0, 0);

        private static ResizableTexture background = Engine.LoadResizableTexture("MapFinal.png", 0, 0, 0, 0);
        private static Texture ship1 = Engine.LoadTexture(Ship.PathName);

        private static double lightyears = 0;
        
        public static String[] names = { "zorp", "Retipuj Station", "organ", "mitian hazard", "rooje", "Meteoropolis Station", "Bifon Hazard", "Lazon Hazard" , "smooc", "Milke Station", "azure", "final frontier"};

        // start-180
        // No activity = -1
        // green planet - 578 = 0
        // ship 1 - 1146 = 1
        // orange planet - 1725 = 2
        // astroid field 1 - 2119 = 3
        // red planet - 2769 = 4
        // ship 2 - 3448 = 5 
        // astroid field 2 - 3867 = 6
        // astroid field 3 - 4561 = 7
        // yellow planet - 5059 = 8
        // ship 3 - 5805 =9
        // blue planet - 6315 = 10
        // astroid field 4 - 6887 = 11


        private Campaign() {}
        
        public static void campaignReset() 
        {
            shipX = 180;
            greenp = false;
            orangep = false;
            redp = false;
            yellowp = false;
            bluep = false;

            station1 = false;
            station2 = false;
            station3 = false;

            asteroid1 = false;
            asteroid2 = false;
            asteroid3 = false;
            asteroid4 = false;
            Ship.LastVisited = -1;
            Ship.AlienMultiplier = 1;
            backgroundPos = new Vector2(0, 0);
            isStarving = false;
        }

        public static void update()
        {
            
            lastActivityMarker(Ship.LastVisited);
            Engine.DrawResizableTexture(background, new Bounds2(backgroundPos, size));
            Engine.DrawTexture(ship1, new Vector2(20f, 352f - 180f));
            moveBackground();
            if (isStarving)
            {
                Engine.DrawString("CREWMATES ARE STARVING", new Vector2(400f, 10f), Color.Red, Fonts.Dialougef24());
            }
            Engine.DrawString("Click I for Inventory", new Vector2(0f, 0f), Color.Black, Fonts.Dialougef24());
            if (Engine.GetKeyDown(Key.I))
            {
                Game.ss = new staticScreens(8);
                Ship.Scene = 9;
            }
            lightyears = backgroundPos.X * -1;
        }

        private static void updateInventory(bool check)
        {
            if (check)
            {
                Inventory.Crew[0] -= 1;
                Inventory.Crew[1] -= 1;
                Inventory.Crew[2] -= 1;
                Inventory.Crew[3] -= 1;
                isStarving = true;
            }
            
            if (Inventory.Crew[0] == 0 || Ship.Fuel== 0)
            {
                if (Ship.Fuel == 0 && Inventory.Crew[0] == 0)
                {
                    if (Inventory.RiskyFuel)
                    {
                        Ship.Fuel += 2;
                        Inventory.RiskyFuel = false;
                    }
                    else
                    {
                        Game.ss = new staticScreens(1);
                        Ship.Scene = 9;
                    }
                }
                else
                {
                    Game.ss = new staticScreens(1);
                    Ship.Scene = 9;
                }
                    
            }
        }
        private static void moveBackground()
        {
            int activity = checkIfActivity();
            if (activity == -1)
            {
                backgroundPos.X--;
                shipX++;
                if ((shipX - 180) % (50 * Ship.Speed) == 0) {
                    if (Inventory.Food > 4) Inventory.Food -= 4;
                    else updateInventory(true);
                    updateInventory(false);
                    Ship.Fuel--;
                    
                }
                if (shipX >= 7300)
                {
                    Game.ss = new staticScreens(2);
                    Ship.Scene = 9;
                }
                //This is where you trigger different things ie check for health ==0 or food == 0 or triger dialouge on x=500 or whatever
                if (shipX == 5700)
                {
                    Game.d = new Dialouge(2);
                    Ship.Scene = 10;
                }
                if (shipX == 5750)
                {
                    Game.d = new Dialouge(1);
                    Ship.Scene = 10;
                }
            }
            else
            {
                button(activity);
            } 
        }

        private static void button(int val)
        {
            backgroundPos.X--;
            shipX++;
            switch (val)
            {
                // ships
                case 1: case 5: case 9: Game.shopPicker = new Stores.ShopPicker(val); Ship.Scene = 2; return; break;
                // Lazer fields
                case 3: case 6: case 7: case 11: Game.ss = new staticScreens(6); Ship.LastVisited = val; Ship.Scene = 9; return; break;
                //Planets
                default:
                    {
                        Engine.DrawString("Press space to stop at" + names[val], new Vector2(147f, 90f), Color.Black, Fonts.Titlef60()); 
                        break;
                    }
            }
            
            if (Engine.GetKeyDown(Key.Space))
            {
                Ship.LastVisited = val;
                Game.ss = new staticScreens(5);

                Ship.Scene = 9;
            }
        }
        private static void lastActivityMarker(int num)
        {
            switch (num)
            {
                case 0:  greenp = true;  break;
                case 2: orangep = true; break;
                case 3: asteroid1 = true; break;
                case 4: redp = true; break;

                case 6: asteroid2 = true; break;
                case 7: asteroid3 = true; break;
                case 8: yellowp = true; break;
                case 10: bluep = true; break;
                case 11: asteroid4 = true; break;
            }
        }

        private static int checkIfActivity()
        {
            if (shipX > 400 && shipX < 660 && !greenp)
            {
                return 0;
            }
            else if (shipX > 1050 && shipX < 1210 && !station1)
            {
                station1 = true;
                return 1;
            }
            else if (shipX > 1705 && shipX < 1745 && !orangep)
            {
                return 2;
            }
            else if (shipX> 2099 && shipX<2139&& !asteroid1)
            {
                return 3;
            }
            else if (shipX > 2749 && shipX < 2789 && !redp)
            {
                return 4;
            }
            else if (shipX > 3428 && shipX < 3468 && !station2)
            {
                station2 = true;
                return 5;
            }
            else if (shipX > 3847 && shipX < 3887 && !asteroid2)
            {
                return 6;
            }
            else if (shipX > 4541 && shipX < 4581 && !asteroid3)
            {
                return 7;
            }
            else if (shipX > 5039 && shipX < 5079 && !yellowp)
            {
                return 8;
            }
            else if (shipX > 5785 && shipX < 5825 && !station3)
            {
                station3 = true;
                return 9;
            }
            else if (shipX > 6295 && shipX < 6335 && !bluep)
            {
                return 10;
            }
            else if (shipX > 6867 && shipX < 6907 && !asteroid4)
            {
                return 11;
            }
            else
            {
                return -1;
            }
        }
    }
}
                                        