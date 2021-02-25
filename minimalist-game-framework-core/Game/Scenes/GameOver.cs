
using System;
namespace Scenes
{
    public class GameOver
    {
        private int score;
        private Font starjediBack;
        private Font starjediOver;
        private Font starjediMenu;
        private ResizableTexture menuBackground;

        public GameOver(int score)
        {
            this.score = score;
            starjediBack = Engine.LoadFont("Starjedi.ttf", 30);
            starjediOver = Engine.LoadFont("Starjedi.ttf", 100);
            menuBackground = Engine.LoadResizableTexture("background.png", 0, 0, 0, 0);
            starjediMenu = Engine.LoadFont("Starjedi.ttf", 60);
        }
        public void gameOverScene()
        {
            Engine.DrawResizableTexture(menuBackground, new Bounds2(0, 0, 1280, 720));
            Engine.DrawString("Game over", new Vector2(300, 300), Color.White, starjediOver);
            Engine.DrawString("High Score: " + score, new Vector2(300, 424), Color.White, starjediMenu);
            Engine.DrawString("(0) Back", new Vector2(10f, 10f), Color.White, starjediBack);
        }
    }

}
