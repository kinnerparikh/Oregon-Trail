using System;
using System.Collections.Generic;

class Game
{
    public static readonly string Title = "Minimalist Game Framework";
    public static readonly Vector2 Resolution = new Vector2(1280, 720);

    #region Variables
    //int score = 0;
    #endregion

    string text = "00";
    
    public static Minigame.Hunt huntScene;
    public static Minigame.FlappyBird flappyBirdScene;
    public static Scenes.Stores.Shop s;
    public static Scenes.Stores.Medbay med;
    public static Scenes.Stores.Garage g;
    public static Scenes.Dialouge d;
    public static Scenes.Stores.ShopPicker shopPicker;
    public static Scenes.staticScreens ss;
    public static Scenes.ShipPicker shipyard;

    private Music gameMusic = Engine.LoadMusic("Game Music.mp3");

    public Game()
    {
        Ship.Scene = 9;
        Ship.LastVisited = -1;
        Inventory.Oxygen = 1;
        Inventory.Food = 4;
        Ship.Fuel = 5;
        Inventory.CurrentStorageSpace = 10;
        ss = new Scenes.staticScreens(4);
        
        Inventory.Crew = new int[4];
        Inventory.Crew[0] = 4;
        Inventory.Crew[1] = 4;
        Inventory.Crew[2] = 4;
        Inventory.Crew[3] = 4;
        Inventory.Credits = 4000;
        Ship.AlienMultiplier = 1;
        Engine.PlayMusic(gameMusic);
    }

    public void Update()
    {
        //d.dialouge();
        //g.ShipRepair();
        //med.medbay();
        //s.shop();
        //huntScene.update();
        /* if (text.StartsWith("0"))
        {
            MenuPicker();
            if (Engine.TypedText.CompareTo("6") < 0) text = Engine.TypedText + text;
        }
        else if (Engine.TypedText.Equals("0")) text = Engine.TypedText + text;

        switch (text.Substring(0, 1))
        {
            case "1": ShopScreen(); break;
            case "2": MedStore(); break;
            case "3": ShipRepair(); break;
            case "4": huntScene.update(); break;
            case "5": flappyBirdScene.update(); break;
            case "6": GameOver(score); break;
            default: MenuPicker(); break;
        }
        //Console.Out.WriteLine(text);*/
        /*switch (Ship.Scene)
        {
            case 0: Scenes.ShipPicker.update(); break;
            case 1: break;
            case 2: 
        }*/

        //Engine.DrawTexture(t, new Vector2(0f, 0f));
        //Scenes.Campaign.update();

        switch (Ship.Scene)
        {
            case 0: //Ship Picker
                Scenes.ShipPicker.update();
                break;
            case 1: // Campaign
                Scenes.Campaign.update();
                break;
            case 2: // Shop Picker
                shopPicker.update();
                break;
            case 3: // Shop 1
                s.shop();
                break;
            case 4: // Medbay
                med.medbay();
                break;
            case 5: // Garage
                g.ShipRepair();
                break;
            case 6: // Inventory
                break;
            case 7: // Flappy
                flappyBirdScene.update();
                break;
            case 8: // hunt
                huntScene.update();
                break;
            case 9:
                ss.staticScreenUpdate();
                break;
            case 10:
                d.dialouge();
                break;

            default: Scenes.Campaign.update(); Ship.Scene = 1; break;
        }
    }
}