using System;
namespace Scenes
{
    public class Menu
    {
        private ResizableTexture menuBackground;
        public Menu()
        {
            menuBackground = Engine.LoadResizableTexture("background.png", 0, 0, 0, 0);
        }

        public void menuScene()
        {
            float x = 275f;
            float y = 150f;
            Engine.DrawResizableTexture(menuBackground, new Bounds2(0, 0, 1280, 720));
            Engine.DrawString("(1) Shop", new Vector2(x, y + (0f * 75f)), Color.White, Fonts.BackButtonf30());
            Engine.DrawString("(2) Medbay", new Vector2(x, y + (1f * 75f)), Color.White, Fonts.BackButtonf30());
            Engine.DrawString("(3) Garage", new Vector2(x, y + (2f * 75f)), Color.White, Fonts.BackButtonf30());
            Engine.DrawString("(4) Hunt", new Vector2(x, y + (3f * 75f)), Color.White, Fonts.BackButtonf30());
            Engine.DrawString("(5) Flappy Bird", new Vector2(x, y + (4f * 75f)), Color.White, Fonts.BackButtonf30());
        }

        private static string[] arr = { "(1) Shop", "(2) Medbay", "(3) Garage", "(4) Hunt", "(5) Flappy Bird" };
        private MenuPicker m = new MenuPicker(arr);
        public void menuTester()
        {

            Engine.DrawResizableTexture(menuBackground, new Bounds2(0, 0, 1280, 720));
            float x = 275f;
            float y = 150f;
            m.choose(x, y, 75f, Fonts.BackButtonf30(), Color.White);
        }
    }
}