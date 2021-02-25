using System;
namespace Scenes.Stores
{
    /*
     * Hit Boxes:
     * 
     * Red x[1067, 1362]
     - Green x[1550, 1845] y[888,978]
     * 
     * 
     * 
     */
    public class Medbay
    {
        // Animated medman
        private Texture medman;
        // Background
        private ResizableTexture medstore;
        // Frameindex for animation control
        private float frameIndex;

        private Vector2 displayBox1;
        private string curDisplayBox1;

        private Vector2 displayBox5;
        private Vector2 displayBox6;

        private string curDisplayBox5;
        private string curDisplayBox6;

        private Vector2 displayBox7;
        private string curDisplayBox7;

        private Vector2 displayBox8;
        private string curDisplayBox8;


        private int hitBoxCheck()

        {
            Vector2 currPos = Engine.MousePosition;
            
            if (currPos.Y > (888 * (2f / 3f)) && currPos.Y < (978 * (2f / 3f)))
            {
                if (currPos.X > (1067 * (2f / 3f)) && currPos.X < (1362 * (2f / 3f))) return 1;
                if (currPos.X > (1550 * (2f / 3f)) && currPos.X < (1848 * (2f / 3f))) return 2;
            }

            if (currPos.Y > (18 * (2f / 3f)) && currPos.Y < (86 * (2f / 3f)) && currPos.X > (1804 * (2f / 3f)) && currPos.X < (1875 * (2f / 3f))) return 3;

            return -1;
        }

        public Medbay()
        {
            
            displayBox1 = new Vector2(60f, 605f);
            displayBox5 = new Vector2((1050f * (2f / 3f)), (665f * (2f / 3f)));
            displayBox6 = new Vector2((1430f * (2f / 3f)), (665f * (2f / 3f)));
            displayBox7 = new Vector2((1050f * (2f / 3f)), (775f * (2f / 3f)));
            displayBox8 = new Vector2(850f, 370f);

            curDisplayBox1 = "Medbay";
            curDisplayBox5 = "Credits";
            curDisplayBox6 = Inventory.Credits + "";
            curDisplayBox7 = null;
            curDisplayBox8 = "150 Credits";
            medman = Engine.LoadTexture("Town1Med big.png");
            medstore = Engine.LoadResizableTexture("healstore.png", 0, 0, 0, 0);
            frameIndex = 0f;
        }

        private Bounds2 manBounds;
        public void medbay()
        {
            
            frameIndex = (frameIndex + Engine.TimeDelta * 2) % 2.0f;
            manBounds = new Bounds2(new Vector2(0f, ((int)frameIndex) * 640f), new Vector2(640f, 640f));


            Engine.DrawResizableTexture(medstore, new Bounds2(0, 0, 1280, 720));
            Engine.DrawTexture(medman, new Vector2(0, 25), source: manBounds);
            // Engine.DrawString("(0) Back", new Vector2(10f, 10f), Color.Black, Fonts.BackButtonf30());
            Engine.DrawString(curDisplayBox1, displayBox1, Color.Black, Fonts.Labelf50());
            Engine.DrawString(curDisplayBox7, displayBox7, Color.Black, Fonts.Labelf32());
            Engine.DrawString(curDisplayBox5, displayBox5, Color.Black, Fonts.Labelf32());
            Engine.DrawString(curDisplayBox6, displayBox6, Color.Black, Fonts.Labelf32());
            Engine.DrawString(curDisplayBox8, displayBox8, Color.Black, Fonts.Labelf32());

            Engine.DrawString("Buy", new Vector2((1570f * (2f / 3f)), (895f * (2f / 3f))), Color.Black, Fonts.Labelf50());
            Engine.DrawString("Back", new Vector2((1087f * (2f / 3f)), (895f * (2f / 3f))), Color.Black, Fonts.Labelf50());

            if (Engine.GetMouseButtonDown(MouseButton.Left))
            {
                int temp = hitBoxCheck();

                if (temp == 2)
                {
                    if (Inventory.Credits > 10)
                    {
                        if (Inventory.Crew[0] != 4 || Inventory.Crew[1] != 4 || Inventory.Crew[2] != 4 || Inventory.Crew[3] != 4)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (Inventory.Crew[i] < 3 && Inventory.Crew[i] != 0) Inventory.Crew[i] += 2;
                                else if (Inventory.Crew[i] == 3) Inventory.Crew[i]++;
                            }
                            curDisplayBox7 = "Crew Healed";
                            Inventory.Credits -= 150;
                            curDisplayBox6 = Inventory.Credits + "";
                        }
                        else
                        {
                            curDisplayBox7 = "Crew Full Health!";
                        }
                    }
                    else
                    {
                        curDisplayBox7 = "Insufficiant Funds";
                    }
                }

                else if (temp == 1)
                {
                    Ship.Scene = 2;
                }
                else if (temp == 3)
                {
                    //display info button text screen
                }
                

            }
        }
    }
}






















































