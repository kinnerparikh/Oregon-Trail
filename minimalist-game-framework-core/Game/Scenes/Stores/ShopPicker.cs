using System;
using System.Collections.Generic;
using System.Text;

namespace Scenes.Stores
{
    class ShopPicker
    {
        private Texture background = Engine.LoadTexture("StationMenu.png");
        private int num;

        public ShopPicker(int storeNum)
        {
            num = storeNum;
        }

        public void update()
        {
            Engine.DrawTexture(background, new Vector2(0f, 0f));
            Engine.DrawString(Campaign.names[num], new Vector2(325, 150), Color.Black, Fonts.Titlef60());
            if (Engine.GetMouseButtonDown(MouseButton.Left)) hitBoxCheck();
        }

        private void hitBoxCheck()
        {
            Vector2 mousePos = Engine.MousePosition;
            if (mousePos.X > 411 && mousePos.X < 822)
            {
                // go to shop
                if (mousePos.Y > 268 && mousePos.Y < 347){
                    if (num == 1) //go to ship one;
                    {
                        Game.s = new Shop(1);
                        Ship.Scene = 3;
                    }
                    else if(num == 5)//goto ship 2
                    {
                        Game.s = new Shop(5);
                        Ship.Scene = 3;
                    }
                    
                    else Game.s = new Shop(9); //treating scene 3 as shop 3
                    //Differentiate between the ships wiuth the shop constructor shop(1) goes to first ship shop(2) goes to second etc
                    
                    Ship.Scene = 3;

                }
                // go to medbay
                if (mousePos.Y > 378 && mousePos.Y < 457) 
                {
                    Ship.Scene = 4;
                    Game.med = new Medbay();
                }
                // go to ship repair
                if (mousePos.Y > 489 && mousePos.Y < 568) 
                {
                    Ship.Scene = 5;
                    Game.g = new Garage();
                }
                // continue journey
                if (mousePos.Y > 600 && mousePos.Y < 679) Ship.Scene = 1;
            }
        }
    }
}
