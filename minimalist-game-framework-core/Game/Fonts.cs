using System;

public class Fonts
{
    private Fonts() { }

    private static Font StarjediFont(int size)
    {
        return Engine.LoadFont("Starjedi.ttf", size);
    }

    private static Font Pixeboy(int size)
    {
        return Engine.LoadFont("Fonts\\Pixeboy.ttf", size);
    }

    private static Font backButtonFont = null;
    internal static Font BackButtonf30()
    {
        if (backButtonFont == null)
        {
            backButtonFont = StarjediFont(30);
        }
        return backButtonFont;
    }

    private static Font menuFont = null;
    internal static Font Menuf60()
    {
        if (menuFont == null)
        {
            menuFont = StarjediFont(60);
        }
        return menuFont;
    }

    private static Font titleFont = null;
    internal static Font Titlef60()
    {
        if (titleFont == null) titleFont = Pixeboy(90);
        return titleFont;
    }
    private static Font labelFont = null;
    internal static Font Labelf20()
    {
        if (labelFont == null) labelFont = Pixeboy(20);
        return labelFont;
    }
    private static Font labelFont2 = null;
    internal static Font Labelf50()
    {
        if (labelFont2 == null) labelFont2 = Pixeboy(75);
        return labelFont2;
    }
    private static Font labelFont3 = null;
    internal static Font Labelf32()
    {
        if (labelFont3 == null) labelFont3 = Pixeboy(48);
        return labelFont3;
    }
    private static Font dialougeFont = null;
    internal static Font Dialougef24()
    {
        if (dialougeFont == null) dialougeFont = Pixeboy(36);
        return dialougeFont;
    }
}