// Author: Ajay Rajasekaran
// Description: A class to store variables for the Ship the player uses, and can be accesed through the Player class
using System;
public class Ship
{
    /*
    -- Ship Class--
    - Storage space
    - Speed
    - Armour/ship health
    - Fuel
    - durability - a tracker that can track the random chance the ship breaks 
    */
    private static int m_speed;
    private static int m_armor;
    private static int m_maxArmor;
    private static int m_fuel;
    //private static int m_durability;
    private static int m_scene;
    private static int m_lastVisited;

    private static int m_oxygenMultiplier;
    private static int m_alienMultiplier;


    //public static bool isWorking;

    private Ship() { }

    public static int OxygenMultiplier
    {
        get { return m_oxygenMultiplier; }
        set { m_oxygenMultiplier = value; }
    }

    public static int AlienMultiplier 
    {
        get { return m_alienMultiplier; }
        set { m_alienMultiplier = value; }
    }

    public static int Scene
    {
        get { return m_scene; }
        set { m_scene = value; }
    }
    public static int LastVisited
    {
        get { return m_lastVisited; }
        set { m_lastVisited = value; }
    }
    private static string pathName;
    public static string PathName
    {
        get { return pathName; }
        set { pathName = value; }
    }

    public static int Speed
    {
        get { return m_speed; }
        set { m_speed = value; }
    }

    public static int Armor
    {
        get { return m_armor; }
        set { m_armor = value; }
    }
    public static int MaxArmor
    {
        get { return m_maxArmor; }
        set { m_maxArmor = value; }
    }

    public static int Fuel
    {
        get { return m_fuel; }
        set { m_fuel = value; }
    }

    /*public static int Durability
    {
        get { return m_durability; }
        set { m_durability = value; }
    }*/

    /*public static bool IsWorking
    {
        get { return rngBreakdown(); }
        set { isWorking = value; }
    }*/

    /*private static bool rngBreakdown()
    {
        return new Random().Next(1, 100) > m_durability;
    }*/
}
