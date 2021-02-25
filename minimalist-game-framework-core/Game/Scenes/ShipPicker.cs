using System;
using System.Collections.Generic;
using System.Text;

/*
Moneybox - (50, 50) (250, 110)
Box 1 - (55, 180) (145, 270)
Box 2 - (235, 180) (325, 270)
Box 3 - (55, 365) (145, 455)
Box 4 - (235, 365) (325, 455)
Box 5 - (55, 550) (145, 640)
Box 6 - (235, 550) (325, 640)
Stats - (455, 180) (945, 645)

 -- THESE VALUES ARE WRONG - Below are the new CORRECT values

    - Box 1 - x[100-200] y [175-275]
    Box 2 - x[280-380] y [175-275]
    Box 3 - x[100-200] y [362-462]
    Box 4 - x[280-380] y [362-462]
    Box 5 - x[100-200] y [547-647]
    Box 6 - x[280-380] y [547-647]
     */

namespace Scenes
{
    class ShipPicker
    {
        private static int shipNum = -1;
        private static Texture background = Engine.LoadTexture("ShipPicker/shipselect.png");
        private static Texture redBox = Engine.LoadTexture("ShipPicker/RedRectangle.png");

        private static ResizableTexture ship1 = Engine.LoadResizableTexture("ship1.png",0,0,0,0);
        private static ResizableTexture ship2 = Engine.LoadResizableTexture("ship2.png",0,0,0,0);
        private static ResizableTexture ship3 = Engine.LoadResizableTexture("ship3.png",0,0,0,0);
        private static ResizableTexture ship4 = Engine.LoadResizableTexture("ship4.png", 0, 0, 0, 0);
        private static ResizableTexture ship5 = Engine.LoadResizableTexture("ship5.png", 0, 0, 0, 0);
        private static ResizableTexture ship6 = Engine.LoadResizableTexture("ship6.png", 0, 0, 0, 0);

        private static Texture ship1info = Engine.LoadTexture("ship1info.png");
        private static Texture ship2info = Engine.LoadTexture("ship2info.png");
        private static Texture ship3info = Engine.LoadTexture("ship3info.png");
        private static Texture ship4info = Engine.LoadTexture("ship4info.png");
        private static Texture ship5info = Engine.LoadTexture("ship5info.png");
        private static Texture ship6info = Engine.LoadTexture("ship6info.png");

        private static Bounds2 s1 = new Bounds2(new Vector2(100f, 175f), new Vector2(100f, 100f));
        private static Bounds2 s2 = new Bounds2(new Vector2(280f, 175f), new Vector2(100f, 100f));
        private static Bounds2 s3 = new Bounds2(new Vector2(100f, 362f), new Vector2(100f, 100f));
        private static Bounds2 s4 = new Bounds2(new Vector2(280f, 362f), new Vector2(100f, 100f));
        private static Bounds2 s5 = new Bounds2(new Vector2(100f, 547f), new Vector2(100f, 100f));
        private static Bounds2 s6 = new Bounds2(new Vector2(280f, 547f), new Vector2(100f, 100f));


        // six ships
        private ShipPicker() { }

        public static void update()
        {
            shipNumLogic();
            draw();

            if (Engine.GetKeyDown(Key.Return))
            {
                setShipValues(shipNum);
                Game.d = new Dialouge(3);
                Ship.Scene = 10;
            }
        }

        private static void setShipValues(int n)
        {
            //int shipDurability, int shipFuel, int shipArmor, int shipSpeed
            //Ship.shipDurability = 1;

            switch (shipNum)
            {
                case 0:
                    Ship.Fuel = 5;
                    Ship.Armor = 5;
                    Ship.MaxArmor = 5;
                    Ship.Speed = 5;
                    Inventory.StorageSpace = 30;
                    Inventory.CurrentStorageSpace = 0;
                    Inventory.Credits -= 2000;
                    Ship.PathName = "ship1.png";
                    break;
                case 1:
                    Ship.Fuel = 5;
                    Ship.Armor = 0;
                    Ship.MaxArmor = 0;
                    Ship.Speed = 4;
                    Inventory.StorageSpace = 30;
                    Inventory.CurrentStorageSpace = 0;
                    Inventory.Credits -= 500;
                    Ship.PathName = "ship2.png";
                    break;
                case 2:
                    Ship.Fuel = 5;
                    Ship.Armor = 1;
                    Ship.MaxArmor = 1;
                    Ship.Speed = 5;
                    Inventory.StorageSpace = 50;
                    Inventory.CurrentStorageSpace = 0;
                    Inventory.Credits -= 1500;
                    Ship.PathName = "ship3.png";
                    break;
                case 3:
                    Ship.Fuel = 5;
                    Ship.Armor = 3;
                    Ship.MaxArmor = 3;
                    Ship.Speed = 7;
                    Inventory.StorageSpace = 80;
                    Inventory.CurrentStorageSpace = 0;
                    Inventory.Credits -= 3000;
                    Ship.PathName = "ship4.png";
                    break;
                case 4:
                    Ship.Fuel = 5;
                    Ship.Armor = 1;
                    Ship.MaxArmor = 1;
                    Ship.Speed = 10;
                    Inventory.StorageSpace = 25;
                    Inventory.CurrentStorageSpace = 0;
                    Inventory.Credits -= 1500;
                    Ship.PathName = "ship5.png";
                    break;
                case 5:
                    Ship.Fuel = 5;
                    Ship.Armor = 2;
                    Ship.MaxArmor = 2;
                    Ship.Speed = 4;
                    Inventory.StorageSpace = 120;
                    Inventory.CurrentStorageSpace = 0;
                    Inventory.Credits -= 2000;
                    Ship.PathName = "ship6.png";
                    break;
            }

        }
        
        private static void draw()
        {
            Engine.DrawTexture(background, new Vector2(0f, 0f));
            if (shipNum!= -1) Engine.DrawTexture(redBox, selectPos());
            Engine.DrawString("Credits: " + Inventory.Credits, new Vector2(110f, 70f), Color.White, Fonts.Labelf20());
            Engine.DrawString("Pres Enter To Purchase Ship", new Vector2(350f, 70f), Color.White, Fonts.Labelf50());


            Engine.DrawResizableTexture(ship1, s1);
            Engine.DrawResizableTexture(ship2, s2);
            Engine.DrawResizableTexture(ship3, s3);
            Engine.DrawResizableTexture(ship4, s4);
            Engine.DrawResizableTexture(ship5, s5);
            Engine.DrawResizableTexture(ship6, s6);

            switch (shipNum)
            {
                case 0:
                    Engine.DrawTexture(ship1info, new Vector2(518f, 190f));
                    break;
                case 1:
                    Engine.DrawTexture(ship2info, new Vector2(518f, 190f));
                    break;
                case 2:
                    Engine.DrawTexture(ship3info, new Vector2(518f, 190f));
                    break;
                case 3:
                    Engine.DrawTexture(ship4info, new Vector2(518f, 190f));
                    break;
                case 4:
                    Engine.DrawTexture(ship5info, new Vector2(518f, 190f));
                    break;
                case 5:
                    Engine.DrawTexture(ship6info, new Vector2(518f, 190f));
                    break;

            }
                

            // -- Displays the info box
        }


        private static void shipNumLogic()
        {
            if (Engine.GetMouseButtonDown(MouseButton.Left))
            {
                float x = Engine.MousePosition.X;
                float y = Engine.MousePosition.Y;


                if (x>=100 && x <= 200)
                {
                    if (y >= 175 && y <= 275) shipNum = 0;
                    else if (y >= 362 && y <= 462) shipNum = 2;
                    else if (y >= 547 && y <= 647) shipNum = 4;
                }
                else if (x>=280 && x<=380)
                {
                    if (y >= 175 && y <= 275) shipNum = 1;
                    else if (y >= 362 && y <= 462) shipNum = 3;
                    else if (y >= 547 && y <= 647) shipNum = 5;
                }
            }
            
            
            /*if (Engine.GetKeyDown(Key.Down))
            {
                if (shipNum < 4) shipNum += 2;
            }
            if (Engine.GetKeyDown(Key.Up))
            {
                if (shipNum > 1) shipNum -= 2;
            }
            if (Engine.GetKeyDown(Key.Right))
            {
                if (shipNum % 2 == 0) shipNum++;
            }
            if (Engine.GetKeyDown(Key.Left))
            {
                if (shipNum % 2 == 1) shipNum--;
            }*/
        }
        
        private static Vector2 selectPos()
        {
            float x, y;

            if (shipNum % 2 == 0) x = 100f;
            else x = 280f;

            if (shipNum <= 1) y = 175f;
            else if (shipNum <= 3) y = 362f;
            else y = 547;

            return new Vector2(x, y);
        }
    }
}
