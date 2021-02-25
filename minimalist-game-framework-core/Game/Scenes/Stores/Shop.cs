using System;
namespace Scenes.Stores
{
    public class Shop
    {
        /*HitBoxes
            - top left = x[1080,1400] y[173,233]
            - Top right = x[1555, 1838] y[^^]

            - second Right x[1080, 1400] y [310, 370]
            - second Left  x[1555, 1838]

            - Third RIght x[1080, 1400] y [445, 505]
            - Third Left x[1555, 1838]
               
            - Red x[1067, 1362]
            - Green x[1550, 1845] y[888,978]
            

            -Info x[1804, 1875] y [18, 86]

        */


        /* Display Boxes
        Box 1: Displays Location Name
        Box 2: Displays static text = "current selection"
        Box 3: Displays price of current slection
        Box 4: Displays current selection name
        Box 5: Displays static text = "Cash"
        Box 6: Displays current cash
        Box 7: Displays purchase status, when no purchase has been made should not apear

        */

        // Animated store man
        private Texture storeman;
        // Background
        private ResizableTexture storefront;
        // Frameindex for animation control
        private float frameIndex;
        private int locationNum;

        private int[] prices;
        private string locationName;
        private string specialty1; 
        private string specialty2;

        private Vector2 displayBox0;
        private Vector2 displayBox1;
        private Vector2 displayBox2;
        private Vector2 displayBox3;
        private Vector2 displayBox4;
        private Vector2 displayBox5;
        private Vector2 displayBox6;
        private Vector2 displayBox7;

        private string curDisplayBox0;
        private string curDisplayBox1;
        private string curDisplayBox2;
        private string curDisplayBox3;
        private string curDisplayBox4;
        private string curDisplayBox5;
        private string curDisplayBox6;
        private string curDisplayBox7;
        private int selection;


        private string[] descriptions;


        public Shop(int location)
        {
            descriptions = new string[6];
            locationNum = location;

            prices = new int[6];

            if (location == 1)
            {
                prices[0] = 100; //fuel
                prices[2] = 30;  //food
                prices[3] = 300; //o2
                prices[1] = 500; //armor
                locationName = "Retipuj Station";
                specialty1 = "Rocket Boots";
                specialty2 = "Hunting Knife";
                prices[4] = 200;
                prices[5] = 500;
                descriptions[4] = "Allows you to double jump when hunting.";
                descriptions[5] = "Gives you much more food per alien kill.";
            }
            else if (location == 5)
            {
                prices[0] = 125; //fuel
                prices[2] = 35;  //food
                prices[3] = 400; //o2
                prices[1] = 700; //armor
                locationName = "Meteoropolis";
                specialty1 = "Rocket Boots"; //
                specialty2 = "Meditation Manual";
                prices[4] = 250;
                prices[5] = 100;
                descriptions[4] = "Allows you to double jump when hunting.";
                descriptions[5] = "You use oxygen at half the rate when hunting.";
            }
            else
            {
                prices[0] = 160; //fuel
                prices[2] = 40;  //food
                prices[3] = 600; //o2
                prices[1] = 1000; //armor
                locationName = "Milke Station";
                specialty1 = "Risky Fuel"; //->Provides 2 extra fuel capacity, harms Crewmates
                specialty2 = "Hunting Knife"; //->Gives you much more food per alien kill
                prices[4] = 200;
                prices[5] = 600;
                descriptions[4] = "Provides 2 extra fuel capacity, harms Crewmates.";
                descriptions[5] = "Gives you much more food per alien kill.";
            }


            descriptions[0] = "Each unit provides distance depending on your ship.";
            descriptions[2] = "Each of your crew consumes 2 Food per fuel cycle.";
            descriptions[3] = "Oxygen limits how long you spend while hunting.";
            descriptions[1] = "Armor Kits automatically repairs Armor when low.";

            displayBox0 = new Vector2((1100f * (2f / 3f)), (60f * (2f / 3f)));
            displayBox1 = new Vector2(60f, 605f);
            displayBox2 = new Vector2((1050f * (2f / 3f)), (20f * (2f / 3f)));
            displayBox3 = new Vector2((1050f * (2f / 3f)), (60f * (2f / 3f)));
            displayBox4 = new Vector2((1320f * (2f / 3f)), (20f * (2f / 3f)));
            displayBox5 = new Vector2((1050f * (2f / 3f)), (565f * (2f / 3f)));
            displayBox6 = new Vector2((1430f * (2f / 3f)), (565f * (2f / 3f)));
            displayBox7 = new Vector2((1050f * (2f / 3f)), (675f * (2f / 3f)));



            curDisplayBox0 = null;
            curDisplayBox1 = locationName;
            curDisplayBox2 = "Current Selection";
            curDisplayBox3 = "NA";
            curDisplayBox4 = "No Item Selected";
            curDisplayBox5 = "Credits";
            curDisplayBox6 = Inventory.Credits + "";
            curDisplayBox7 = null;


            storeman = Engine.LoadTexture("Town1Shop big.png");
            storefront = Engine.LoadResizableTexture("Storefront1.png", 0, 0, 0, 0);
            frameIndex = 0f;
            //starjediBack = Engine.LoadFont("Starjedi.ttf", 30);


        }
        private int hitBoxCheck()
        {
            Vector2 currPos = Engine.MousePosition;
            if (currPos.X > (1080 * (2f/3f)) && currPos.X < (1400 * (2f / 3f)))
            {
                if (currPos.Y > (173 * (2f / 3f)) && currPos.Y < (233 * (2f / 3f))) return 1; 
                if (currPos.Y > (310 * (2f / 3f)) && currPos.Y < (370 * (2f / 3f))) return 3;
                if (currPos.Y > (445 * (2f / 3f)) && currPos.Y < (505 * (2f / 3f))) return 5;

            }

            if (currPos.X > (1555 * (2f / 3f)) && currPos.X < (1838 * (2f / 3f)))
            {
                if (currPos.Y > (173 * (2f / 3f)) && currPos.Y < (233 * (2f / 3f))) return 2;
                if (currPos.Y > (310 * (2f / 3f)) && currPos.Y < (370 * (2f / 3f))) return 4;
                if (currPos.Y > (445 * (2f / 3f)) && currPos.Y < (505 * (2f / 3f))) return 6;
            }

            if (currPos.Y > (888 * (2f / 3f)) && currPos.Y < (978 * (2f / 3f)))
            {
                if (currPos.X > (1067 * (2f / 3f)) && currPos.X < (1362 * (2f / 3f))) return 7;
                if (currPos.X > (1550 * (2f / 3f)) && currPos.X < (1848 * (2f / 3f))) return 8;
            }

            if (currPos.Y > (18 * (2f / 3f)) && currPos.Y < (86 * (2f / 3f)) && currPos.X > (1804 * (2f / 3f)) && currPos.X < (1875 * (2f / 3f))) return 9;

            return -1;
        }
        private string currentItem(int curSelection)
        {
            switch (curSelection)
            {
                case 1:
                    return "Fuel";
                    break;
                case 2:
                    return "Armor Kit";
                    break;
                case 3:
                    return "Food";
                    break;
                case 4:
                    return "Oxygen";
                    break;
                case 5:
                    return specialty1;
                    break;
                case 6:
                    return specialty2;
                    break;
                default: return "No Item Selected"; break;
            }

        }
        private void addToInventory(int curSelection)
        {
            Inventory.Credits -= prices[curSelection - 1];
            switch (curSelection)
            {
                case 1:
                    Ship.Fuel++;
                    Console.WriteLine("Purchase successfull");
                    break;
                case 2:
                    Inventory.ArmorKit++;
                    Console.WriteLine("Purchase successfull");
                    break;
                case 3:
                    Inventory.Food++;
                    Console.WriteLine("Purchase successfull");
                    break;
                case 4:
                    Inventory.Oxygen++;
                    Console.WriteLine("Purchase successfull");
                    break;
                //case 5:
                  //  Inventory.Speciality1++;
                  //  Console.WriteLine("Purchase successfull");
                   // break;
                //case 6:
                   // Inventory.Speciality2++;
                  //  Console.WriteLine("Purchase successfull");
                    //break;
               
            }

        }

        private Bounds2 manBounds;
        public void shop()
        {
            int curCash = Inventory.Credits;
            
            frameIndex = (frameIndex + Engine.TimeDelta * 2) % 2.0f;
            manBounds = new Bounds2(new Vector2(0f, ((int)frameIndex) * 640f), new Vector2(640f, 640f));

            Engine.DrawResizableTexture(storefront, new Bounds2(0, 0, 1280, 720));
            Engine.DrawTexture(storeman, new Vector2(0, 25), source: manBounds);
            //Engine.DrawString("(0) Back", new Vector2(10f, 10f), Color.Black, Fonts.BackButtonf30());
            Engine.DrawString(curDisplayBox0, displayBox0, Color.Black, Fonts.Labelf20());
            Engine.DrawString(curDisplayBox1, displayBox1, Color.White, Fonts.Labelf50());
            Engine.DrawString(curDisplayBox2, displayBox2, Color.Black, Fonts.Labelf20());
            Engine.DrawString(curDisplayBox3, displayBox3, Color.Black, Fonts.Labelf20());
            Engine.DrawString(curDisplayBox4, displayBox4, Color.Black, Fonts.Labelf20());
            Engine.DrawString(curDisplayBox5, displayBox5, Color.Black, Fonts.Labelf32());
            Engine.DrawString(curDisplayBox6, displayBox6, Color.Black, Fonts.Labelf32());
            Engine.DrawString(curDisplayBox7, displayBox7, Color.Black, Fonts.Labelf32());

            Engine.DrawString("Buy", new Vector2((1620f * (2f / 3f)), (905f * (2f / 3f))), Color.Black, Fonts.Labelf50());
            Engine.DrawString("Back", new Vector2((1110f * (2f / 3f)), (905f * (2f / 3f))), Color.Black, Fonts.Labelf50());

            Engine.DrawString(currentItem(1), new Vector2((1130f * (2f / 3f)), (193f * (2f / 3f))), Color.Black, Fonts.Labelf20());
            Engine.DrawString(currentItem(2), new Vector2((1605f * (2f / 3f)), (193f * (2f / 3f))), Color.Black, Fonts.Labelf20());
            Engine.DrawString(currentItem(3), new Vector2((1130f * (2f / 3f)), (330f * (2f / 3f))), Color.Black, Fonts.Labelf20());
            Engine.DrawString(currentItem(4), new Vector2((1605f * (2f / 3f)), (330f * (2f / 3f))), Color.Black, Fonts.Labelf20());
            Engine.DrawString(currentItem(5), new Vector2((1130f * (2f / 3f)), (465f * (2f / 3f))), Color.Black, Fonts.Labelf20());
            Engine.DrawString(currentItem(6), new Vector2((1605f * (2f / 3f)), (465f * (2f / 3f))), Color.Black, Fonts.Labelf20());


            if (Engine.GetMouseButtonDown(MouseButton.Left))
            {
                int temp = hitBoxCheck();

                if (temp == 8)
                {
                    if (selection != 0)
                    {
                        if (curCash>= prices[selection-1])
                        {    
                            //add to inventory
                            //Display: Purchased *item name*
                            //update box 3 and 4 to display no item slected
                            //Update cash value in inventory and on screen on box 6

                            if (Inventory.CurrentStorageSpace < Inventory.StorageSpace && selection < 5) 
                            {
                                addToInventory(selection);
                                curDisplayBox7 = "Purchased: " + currentItem(selection);
                                curDisplayBox6 = "$" + Inventory.Credits;
                                Inventory.CurrentStorageSpace++;
                                curCash -= prices[selection - 1];
                            }
                            else if (selection >= 5)
                            {
                                if (locationNum == 1) 
                                {
                                    if(selection == 5)
                                    {
                                        if (!Inventory.RocketBoots)
                                        {
                                            addToInventory(5);
                                            Inventory.RocketBoots = true;
                                            curDisplayBox7 = "Purchased: " + currentItem(selection);
                                            curDisplayBox6 = "$" + Inventory.Credits;
                                        }
                                        else
                                        {
                                            curDisplayBox7 = "Item Already Owned";
                                        }
                                    }
                                    if (selection == 6)
                                    {
                                        if (!Inventory.Knife)
                                        {
                                            addToInventory(6);
                                            Inventory.Knife = true;
                                            curDisplayBox7 = "Purchased: " + currentItem(selection);
                                            curDisplayBox6 = "$" + Inventory.Credits;
                                        }
                                        else
                                        {
                                            curDisplayBox7 = "Item Already Owned";
                                        }
                                    }
                                }
                                if (locationNum == 2)
                                {
                                    if (selection == 5)
                                    {
                                        if (!Inventory.RocketBoots)
                                        {
                                            addToInventory(5);
                                            Inventory.RocketBoots = true;
                                            curDisplayBox7 = "Purchased: " + currentItem(selection);
                                            curDisplayBox6 = "$" + Inventory.Credits;
                                        }
                                        else
                                        {
                                            curDisplayBox7 = "Item Already Owned";
                                        }
                                    }
                                    if (selection == 6)
                                    {
                                        if (!Inventory.Book)
                                        {
                                            addToInventory(6);
                                            Inventory.Book = true;
                                            curDisplayBox7 = "Purchased: " + currentItem(selection);
                                            curDisplayBox6 = "$" + Inventory.Credits;
                                        }
                                        else
                                        {
                                            curDisplayBox7 = "Item Already Owned";
                                        }
                                    }
                                }
                                else
                                {
                                    if (selection == 5)
                                    {
                                        if (!Inventory.RiskyFuel)
                                        {
                                            addToInventory(5);
                                            Inventory.RiskyFuel = true;
                                            curDisplayBox7 = "Purchased: " + currentItem(selection);
                                            curDisplayBox6 = "$" + Inventory.Credits;
                                        }
                                        else
                                        {
                                            curDisplayBox7 = "Item Already Owned";
                                        }
                                    }
                                    if (selection == 6)
                                    {
                                        if (!Inventory.Knife)
                                        {
                                            addToInventory(6);
                                            Inventory.Knife = true;
                                            curDisplayBox7 = "Purchased: " + currentItem(selection);
                                            curDisplayBox6 = "$" + Inventory.Credits;
                                        }
                                        else
                                        {
                                            curDisplayBox7 = "Item Already Owned";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                curDisplayBox7 = "No Storage Left";
                            }
                        }
                        else
                        {
                            //Display: insufficiant funds - in box 7
                            curDisplayBox7 = "Insufficiant Funds";
                        }
                    }
                    else
                    {
                        //Error: no item selected Currently - in box 7
                        curDisplayBox7 = "No Item Selected";
                    }
                }
                else if (temp == 7)
                {
                    Ship.Scene = 2;
                }
                else if (temp == 9)
                {
                    //display info button text screen
                }
                else if (temp > 0)
                {
                    selection = temp;
                    curDisplayBox3 = "$" +prices[selection - 1];
                    curDisplayBox4 = currentItem(selection);
                    curDisplayBox0 = descriptions[selection - 1];
                }
            }
        }
    }
}