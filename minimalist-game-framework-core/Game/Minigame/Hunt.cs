using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Minigame
{
    class Hunt
    {
        // Load some textures when the game starts:
        Texture digitMap = Engine.LoadTexture("digit.png");
        Texture texKnight = Engine.LoadTexture("PunchPlayer.png");
        Texture imp = Engine.LoadTexture("Imp.png");
        Texture huntBackground = Engine.LoadTexture("huntbackground.png");
        Texture platform = Engine.LoadTexture("PlatformClone.png");

        float gravity = 0.08f;   // constant downward acceleration
        float flapping = -3f;   // upward acceleration whenever isFlapping is true
        float maxSpeed = 6;
        float velY = 0;
        int posX = 50;
        float posY = 200;
        int impposX = 1280;
        int impposY = 360;
        bool isjumping=false;
        bool knightFaceLeft = false;
        int score = 0; // - Number of aliens
        int impAnim = 0;
        bool ispunching = false;
        int punchAnim = 0;
        bool startingVars = true;
        bool impdead = true;
        int showOxygen = 30;
        int  oxygen = 30;
        bool switcher = true;
        int second;
        int curtime;
        int platformlevel1 = 625;
        int platformlevel2 = 500;
        int numplats1st = 0;
        int numplats2nd = 0;
        int rbJumpCount = 0;
        ArrayList platlist = new ArrayList();


        string text = "00";

        public Hunt()
        {
        }


        public bool PlatformCollision(float fposY)
        {
            int b = 0;
            foreach (int i in platlist)
            {
                if (posX > i && posX < i + 182)
                {
                    if (b < numplats1st + 1)
                    {
                        if (fposY > platformlevel1-32 && fposY < platformlevel1 - 6)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (fposY > platformlevel2-32 && fposY < platformlevel2 - 6)
                        {
                            return true;
                        }
                    }
                }
                b++;
            }
            return false;
        }

        public void update()
        {
            if (Inventory.Book)
            {
                Ship.AlienMultiplier = 2;
            }
            if ((int)oxygen == 0)
            {
                Game.ss = new Scenes.staticScreens(7);
                
                int available = (Inventory.StorageSpace - Inventory.CurrentStorageSpace);
                if (score > available) 
                { 
                    score = available; 
                    Inventory.CurrentStorageSpace = Inventory.StorageSpace;
                    Inventory.Food += available; 
                }
                else 
                { 
                    Inventory.CurrentStorageSpace += score * 2; 
                    Inventory.Food += score * 2; 
                }
                
                Ship.Scene = 9;
            }
            if (startingVars)
            {
                score = 0;
                posX = 10;
                posY = 685;
                impposX = 400;
                impposY = 685;
                velY = 0;
                knightFaceLeft = false;
                startingVars = false;
                impdead = false;
                
                showOxygen = 30;
                second = 70;
                curtime = 0;

                if (Inventory.Book)
                {
                    oxygen = 60;
                }

                Random rnd = new Random();
                numplats1st = rnd.Next(2, 3);
                numplats2nd = rnd.Next(3, 4);
                for (int i = 0; i < numplats1st; i++)
                {
                    platlist.Add(rnd.Next(0, 1280-182));
                }
                for (int i = 0; i < numplats2nd; i++)
                {
                    platlist.Add(rnd.Next(0, 1280-182));
                }
            }
            
            Engine.DrawTexture(huntBackground, new Vector2(0.0f, 0.0f));

            if (impdead)
            {
                impdead = false;
            }
            if (oxygen == 0 || Engine.GetKeyDown(Key.Space))
            {
                text = "6" + text;
            }
            if (curtime == second)
            {
                curtime = 0;
                System.Console.WriteLine("Oxygen lost");
                oxygen -= 1;//Ship.OxygenMultiplier;
                if (Inventory.Book)
                {
                    if (switcher)
                    {
                        showOxygen--;
                        switcher = false;
                    }
                    else
                    {
                        switcher = true;
                    }
                }
                else
                {
                    showOxygen--;
                }
            }
            else
            {
                curtime++;
            }

            //maximum and minimum velocity cap. Ensures flappy bird isn't too dramatic
            if (velY > maxSpeed)
            {
                velY = maxSpeed;
            }
            if (velY < -maxSpeed)
            {
                velY = -maxSpeed;
            }

            //Flappies velocity and position changes
            if (PlatformCollision(posY += velY) == false)
            {
                posY += velY;
                velY += gravity;
            }
            else 
            {
                if (velY > 0)
                {
                    velY = 0;
                    isjumping = false;
                }
            }

            if (posY > 684)
            {
                posY = 685;
                velY = 0;
                isjumping = false;
            }

            //clicking mouse increases velocity
            if (Engine.GetKeyHeld(Key.Up) && isjumping==false)
            {
                velY += flapping;

                if (Inventory.RocketBoots)
                {
                    if (rbJumpCount < 10)
                    {
                        rbJumpCount++;
                    }
                    else
                    {
                        isjumping = true;
                        rbJumpCount = 0;
                    }
                }
                else isjumping = true;

            }

            if (Engine.GetKeyHeld(Key.Down) && ispunching == false)
            {
                ispunching = true;
            }
            if (Engine.GetKeyHeld(Key.Left))
            {
                knightFaceLeft = true;
                if (posX > 0)
                    posX = posX - 6;
            }
            if (Engine.GetKeyHeld(Key.Right))
            {
                knightFaceLeft = false;
                if (posX < 1280)
                {
                    posX = posX + 6;
                }
            }
            if (Engine.GetKeyHeld(Key.Space))
            {
                Console.WriteLine("Game Over");
                text = "6" + text;
            }


            if (ispunching == true)
            {
                if ((impposX - posX) < 50 && (posX - impposX) < 50 && (impposY - posY) < 10 && (posY - impposY) < 10)
                {
                    int newimpposX = impposX;
                    impdead = true;
                    score += Ship.AlienMultiplier;
                    Console.WriteLine("killed alien");
                    while (Math.Abs(newimpposX - impposX) < 180)
                    {
                        Random rnd = new Random();
                        int platcode = rnd.Next(0, numplats1st + numplats2nd);
                        if (platcode < numplats1st+1)
                        {
                            impposY = platformlevel1 - 26;
                        }
                        else
                        {
                            impposY = platformlevel2 - 26;
                        }
                        newimpposX = (int)platlist[platcode] + rnd.Next(0, 175);
                    }
                    impposX = newimpposX;
                }
            }

            //platform placement

            punchAnim += 1;
            if (punchAnim > 40)
            {
                punchAnim = 1;
                ispunching = false;
            }

            Bounds2 punch1 = new Bounds2(new Vector2(0.0f, 0.0f), new Vector2(32.0f, 32.0f));
            Bounds2 punch2 = new Bounds2(new Vector2(32.0f, 0.0f), new Vector2(32.0f, 32.0f));
            Bounds2 punch3 = new Bounds2(new Vector2(64.0f, 0.0f), new Vector2(32.0f, 32.0f));
            Bounds2 punch4 = new Bounds2(new Vector2(96.0f, 0.0f), new Vector2(32.0f, 32.0f));

            Bounds2 player = punch1;

            if (ispunching == true)
            {
                if (punchAnim > 0)
                    player = punch1; 
                if (punchAnim > 10)
                    player = punch2;
                if (impAnim > 20)
                    player = punch3;
                if (impAnim > 30)
                    player = punch4;
            }

            impAnim += 1;
            if (impAnim > 60)
                impAnim = 1;

            Bounds2 impIdle1 = new Bounds2(new Vector2(0.0f, 0.0f), new Vector2(32.0f, 32.0f));
            Bounds2 impIdle2 = new Bounds2(new Vector2(32.0f, 0.0f), new Vector2(32.0f, 32.0f));
            Bounds2 impIdle3 = new Bounds2(new Vector2(64.0f, 0.0f), new Vector2(32.0f, 32.0f));
            Bounds2 impIdle4 = new Bounds2(new Vector2(96.0f, 0.0f), new Vector2(32.0f, 32.0f));
            Bounds2 impIdle5 = new Bounds2(new Vector2(128.0f, 0.0f), new Vector2(32.0f, 32.0f));
            Bounds2 impIdle6 = new Bounds2(new Vector2(160.0f, 0.0f), new Vector2(32.0f, 32.0f));

            Bounds2 impIdle = impIdle1;

            if (impAnim > 0)
                impIdle = impIdle1;
            if (impAnim > 10)
                impIdle = impIdle2;
            if (impAnim > 20)
                impIdle = impIdle3;
            if (impAnim > 30)
                impIdle = impIdle4;
            if (impAnim > 40)
                impIdle = impIdle5;
            if (impAnim > 50)
                impIdle = impIdle6;

            int firstscoredigit = score / 10;
            int secondscoredigit = score % 10;
            int firstO2digit = (int)(showOxygen / 10);
            int secondO2digit = (int)(showOxygen % 10);
            //System.Console.WriteLine("this should work");
            Bounds2 digit1 = new Bounds2(new Vector2((firstscoredigit * 50f), 0.0f), new Vector2((50f), 50f));
            Bounds2 digit2 = new Bounds2(new Vector2((secondscoredigit * 50f), 0.0f), new Vector2((50f), 50f));
            Bounds2 O2digit1 = new Bounds2(new Vector2((firstO2digit * 50f), 0.0f), new Vector2((50f), 50f));
            Bounds2 O2digit2 = new Bounds2(new Vector2((secondO2digit * 50f), 0.0f), new Vector2((50f), 50f));

            Bounds2 plat = new Bounds2(new Vector2(0.0f, 0.0f), new Vector2(512.0f, 512.0f));

            // Draw the player:

            TextureMirror knightMirror = knightFaceLeft ? TextureMirror.Horizontal : TextureMirror.None;
            Engine.DrawTexture(texKnight, new Vector2(posX * 1.0f, posY * 1.0f), source: player, mirror: knightMirror);

            //Draw the enemy:
            TextureMirror impMirror = false ? TextureMirror.Horizontal : TextureMirror.None;
            Engine.DrawTexture(imp, new Vector2(impposX * 1.0f, impposY * 1.0f), source: impIdle, mirror: impMirror);

            
            for (int i = 0; i < numplats1st + numplats2nd; i++)
            {
                int xposplat = (int) platlist[i];
                if (i < numplats1st + 1)
                {
                    Engine.DrawTexture(platform, new Vector2(xposplat, platformlevel1));
                }
                else
                {
                    Engine.DrawTexture(platform, new Vector2(xposplat, platformlevel2));
                }
            }
            

            //Draw the score:
            TextureMirror digitMirror = false ? TextureMirror.Horizontal : TextureMirror.None;
            Engine.DrawTexture(digitMap, new Vector2(940, 0), source: digit1, mirror: digitMirror);
            Engine.DrawTexture(digitMap, new Vector2(1000, 0), source: digit2, mirror: digitMirror);
            Engine.DrawTexture(digitMap, new Vector2(0, 0), source: O2digit1, mirror: digitMirror);
            Engine.DrawTexture(digitMap, new Vector2(60, 0), source: O2digit2, mirror: digitMirror);
        }
    }
}