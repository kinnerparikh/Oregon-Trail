using System;
using System.Collections.Generic;
using System.Text;

namespace Scenes
{
    class staticScreens
    {
        //staticscreens(1) = game over
        //Staticscreens()2 + Win Screen
        //3 = stats screen
        //4= titl
        private string curPath;
        private Texture texture;
        private int curNum;

        public staticScreens(int num)
        {
            curPath = "ss" + num + ".png";
            curNum = num;
            texture = Engine.LoadTexture(curPath);
        }

        public void staticScreenUpdate()
        {
            Engine.DrawTexture(texture, new Vector2(0f, 0f));
            Console.WriteLine(curPath + "drawn");
            if (curNum == 3)
            {
                Engine.DrawString("Score : 52", new Vector2(525f, 350f), Color.White, Fonts.Labelf32());
                //Draw out stats here and say click space to restart
                if (Engine.GetKeyDown(Key.Space)) {
                    Ship.Scene = 9;
                }

                // money, fuel, food, oxyge
                double finalScore = 0.0;

            }
            if (curNum == 8)
            {
                Engine.DrawString("Fuel: " + Ship.Fuel, new Vector2(400f, 300f), Color.White, Fonts.Labelf20());
                Engine.DrawString("Food: " + Inventory.Food, new Vector2(100f, 300f), Color.White, Fonts.Labelf20());
                Engine.DrawString("Oxygen: " + Inventory.Oxygen, new Vector2(100f, 350f), Color.White, Fonts.Labelf20());
                Engine.DrawString("Armor Kits: " + Inventory.ArmorKit, new Vector2(100f, 400f), Color.White, Fonts.Labelf20());
                Engine.DrawString("RocketBoots Aquired =  " + Inventory.RocketBoots, new Vector2(100f, 450f), Color.White, Fonts.Labelf20());
                Engine.DrawString("Meditation Book Aquired =  " + Inventory.Book, new Vector2(100f, 500f), Color.White, Fonts.Labelf20());
                Engine.DrawString("Hunting Knife Aquired =  " + Inventory.Knife, new Vector2(100f, 550f), Color.White, Fonts.Labelf20());
                Engine.DrawString("RiskyFuel Aquired =  " + Inventory.RiskyFuel, new Vector2(100f, 600f), Color.White, Fonts.Labelf20());
                Engine.DrawString("Juicer Aquired =  " + Inventory.Juicer, new Vector2(100f, 650f), Color.White, Fonts.Labelf20());
                Engine.DrawString("Armor: " + Ship.Armor + "/" + Ship.MaxArmor, new Vector2(400f, 350f), Color.White, Fonts.Labelf20());

                Engine.DrawString("Current Inventory Space Used = " + Inventory.CurrentStorageSpace + " / " + Inventory.StorageSpace, new Vector2(100f, 150f), Color.White, Fonts.Labelf20());
                Engine.DrawString("Crewmate 1 Health: " + Inventory.Crew[0] + "/4", new Vector2(700f, 300f), Color.White, Fonts.Labelf20());
                Engine.DrawString("Crewmate 2 Health: " + Inventory.Crew[1] + "/4", new Vector2(700f, 350f), Color.White, Fonts.Labelf20());
                Engine.DrawString("Crewmate 3 Health: " + Inventory.Crew[2] + "/4", new Vector2(700f, 400f), Color.White, Fonts.Labelf20());
                Engine.DrawString("Crewmate 4 Health: " + Inventory.Crew[3] + "/4", new Vector2(700f, 450f), Color.White, Fonts.Labelf20());
            }
            if (Engine.GetKeyDown(Key.Space))
            {
                sceneSwitchLocal();
            }
        }

        private void sceneSwitchLocal()
        {
            if (curNum == 1 || curNum == 2)
            {
                Game.ss = new staticScreens(3);
                Ship.Scene = 9;
            }
            else if (curNum == 4)
            {
                Ship.Scene = 0;
            }
            
            else if (curNum ==7 || curNum ==8 || curNum == 9 || curNum == 10)
            {
                Ship.Scene = 1;
            }
            
            else if (curNum ==5 )
            {
                if (Inventory.Oxygen > 0)
                {
                    Game.huntScene = new Minigame.Hunt();
                    Inventory.Oxygen -= 1;
                    Inventory.CurrentStorageSpace -= 1;
                    Ship.Scene = 8;
                }
                else
                {
                    Game.ss = new staticScreens(7);
                    Ship.Scene = 9;
                }
                
            }
            else if (curNum == 6)
            {
                Game.flappyBirdScene = new Minigame.FlappyBird(); 
                Ship.Scene = 7;
            }
            
            else
            {
                Console.WriteLine("game over");
                Inventory.Credits = 6000;
                Inventory.Crew = new int[4];
                Inventory.Crew[0] = 4;
                Inventory.Crew[1] = 4;
                Inventory.Crew[2] = 4;
                Inventory.Crew[3] = 4;
                Campaign.campaignReset();
                Inventory.Food = 4;
                Ship.Fuel = 5;
                Inventory.CurrentStorageSpace = 10;

                Inventory.Armor = 0;
                //Inventory.Food = 0;
                Inventory.ArmorKit = 0;
                Inventory.Oxygen = 1;
                Inventory.RocketBoots = false;
                Inventory.Knife = false;
                Inventory.Book = false;
                Inventory.Juicer = false;
                Inventory.RiskyFuel = false;
                Game.ss = new staticScreens(4);
                Ship.Scene = 9;
            }
        }
        

    }
}
