using System;
namespace Minigame
{

    public class FlappyBird
    {
        Texture digitMap = Engine.LoadTexture("digit.png");
        Texture ship = Engine.LoadTexture("Ship 1clone.png");
        Texture pipe = Engine.LoadTexture("lazer Emitter (1).png");
        Texture texBackground = Engine.LoadTexture("background.png");

        #region Variables
        //variables:
        int gapheight = 300;
        float gravity = 0.08f;   // constant downward acceleration
        float flapping = -4f;   // upward acceleration whenever isFlapping is true
        float maxSpeed = 6;
        float velY = 0;
        int posX = 50;
        float posY = 200;
        int impposX = 1280;
        int impVelX = -8;
        int bgScroll = 0;
        float shipFrameIndex = 0;
        int lengthbotpipe = 210;
        int lengthtoppipe = 210;
        int score = 0;
        string text = "";
        #endregion

        public FlappyBird()
        {
            
        }

        private void endGame()
        {
            if (score < 5)
            {
                Ship.Armor --;
                if (Ship.Armor <= 0)
                {
                    if (Inventory.ArmorKit > 0)
                    {
                        Inventory.ArmorKit--;
                        Ship.Armor++;
                    }
                    else
                    {
                        Game.ss = new Scenes.staticScreens(1);
                        Ship.Scene = 9;
                    }
                }
                else
                {
                    Game.ss = new Scenes.staticScreens(9);
                    Ship.Scene = 9;
                }
            }
            else
            {
                Game.ss = new Scenes.staticScreens(10);
                Ship.Scene = 9;
            }
            
        }

        public void update()
        {
            int pipeWestX = impposX;

            int toppipeSouthY = lengthtoppipe;
            int botpipeNorthY = 720 - lengthbotpipe;

            int shipEastX = posX + 256;
            float shipNorthY = posY + 50;
            float shipSouthY = posY + 156;

            // Draw the background:
            Engine.DrawTexture(texBackground, new Vector2((0 - bgScroll) * 1.0f, 0.0f));

            //pipe movement
            impposX += impVelX;

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
            posY += velY;
            velY += gravity;


            //pressing space increases velocity
            if (Engine.GetKeyDown(Key.Up))
            {
                velY += flapping;
            }

            //colition with pipe
            if (pipeWestX < shipEastX)
            {
                if (botpipeNorthY < shipSouthY)
                {
                    Console.WriteLine("Game Over");
                    endGame();
                    text = "6" + text;
                }
                if (toppipeSouthY > shipNorthY)
                {
                    Console.WriteLine("Game Over");
                    endGame();
                    text = "6" + text;
                }
            }

            //colition with ground and ceiling
            if (posY > 720)
            {
                Console.WriteLine("Game Over");
                endGame();
                text = "6" + text;
            }
            else if (posY < -50)
            {
                posY = -50;
                velY = 0;
            }

            if (impposX < 0)
            {
                Random rnd = new Random();
                lengthbotpipe = rnd.Next(0, 720 - gapheight);
                lengthtoppipe = (720 - gapheight) - lengthbotpipe;
                impposX = 1280;
                score++;
                Console.WriteLine("your score is " + score);
            }

            shipFrameIndex = (shipFrameIndex + Engine.TimeDelta * 13) % 13.0f;
            Bounds2 shipBounds = new Bounds2(0, ((int)shipFrameIndex) * 256, 256, 256);

            Bounds2 pipeBottom = new Bounds2(new Vector2(500f, 1024f), new Vector2(550.0f, lengthbotpipe));
            Bounds2 pipeTop = new Bounds2(new Vector2(500f, 1024f), new Vector2(550.0f, lengthtoppipe));

            int firstscoredigit = score / 10;
            int secondscoredigit = score % 10;
            Bounds2 digit1 = new Bounds2(new Vector2((firstscoredigit * 50f), 0.0f), new Vector2((50f), 50f));
            Bounds2 digit2 = new Bounds2(new Vector2((secondscoredigit * 50f), 0.0f), new Vector2((50f), 50f));

            // Draw the player:
            Engine.DrawTexture(ship, new Vector2(posX * 1.0f, posY * 1.0f), source: shipBounds);

            //Draw the pipe:
            TextureMirror pipeMirror = false ? TextureMirror.Horizontal : TextureMirror.None;
            Engine.DrawTexture(pipe, new Vector2(impposX * 1.0f, 0 * 1.0f), source: pipeTop, mirror: pipeMirror);
            Engine.DrawTexture(pipe, new Vector2(impposX * 1.0f, ((720) - lengthbotpipe) * 1.0f), source: pipeBottom, mirror: pipeMirror);

            //Draw the score:
            TextureMirror digitMirror = false ? TextureMirror.Horizontal : TextureMirror.None;
            Engine.DrawTexture(digitMap, new Vector2(940, 0), source: digit1, mirror: digitMirror);
            Engine.DrawTexture(digitMap, new Vector2(1000, 0), source: digit2, mirror: digitMirror);

        }
    }
}