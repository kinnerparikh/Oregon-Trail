using System;
using System.Collections;
using System.Text;

class MenuPicker 
{
    private readonly Texture arrow = Engine.LoadTexture("Images\\Arrow.png");
    private float arrowPosition = 0f;
    private ArrayList items;

    private static float arrowPosX;
    private static float arrowPosY;

    // Constructors
    public MenuPicker()
    {
        items = new ArrayList();
    }
    public MenuPicker(string[] options)
    {
        items = new ArrayList(options);
    }

    // Add items
    public void addOption(String option)
    {
        items.Add(option);
    }
    public void addOption(string[] options)
    {
        items.Add(options);
    }

    public void choose(float x, float y, float spacing, Font font, Color color)
    {
        foreach (string item in items)
        {
            Engine.DrawString(item, new Vector2(x, y), color, font);
            y += spacing;
        }
        if (Engine.GetKeyDown(Key.Down))
        {
            Console.Out.WriteLine("works!");
        }
        //Engine.DrawTexture(arrow, new Vector2(x - 10, arrowPosition));
    }

    // Getters
    public ArrayList getOptions()
    {
        return items;
    }
}
