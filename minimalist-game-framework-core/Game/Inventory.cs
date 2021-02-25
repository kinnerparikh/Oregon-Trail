using System;
/*
--Types of Inventory--
- Rocket Boots
- Oxygen
- Food */
public class Inventory
{
    
    private static int m_oxygen;
    private static int m_armor;
    private static int m_food;
    private static int m_storageSpace;
    private static int m_currentStorageSpace;
    private static int m_stationsLeft;
    private static int m_credits;

    private static int[] m_crew;
    //Each crew will have a health 0-4
    //0 is dead
    //1 is very poor
    //2 is poor
    //3 is fair
    //4 is good

    //This is where we track special items
    private static bool m_rocketBoots;
    private static bool m_juicer;
    private static bool m_knife; // change alien mult to 2
    private static bool m_riskyFuel;
    private static bool m_book; // change oxygen mult

    private static string[] m_crewNames;


    private Inventory() { }

    public static int Credits
    {
        get { return m_credits; }
        set { m_credits = value; }
    }

    
    public static int Oxygen
    {
        get { return m_oxygen; }
        set { m_oxygen = value; }
    }
    public static int Armor
    {
        get { return m_armor; }
        set { m_armor = value; }
    }
    public static int Food
    {
        get { return m_food; }
        set { m_food = value; }
    }
    public static int StorageSpace
    {
        get { return m_storageSpace; }
        set { m_storageSpace = value; }
    }
    public static int CurrentStorageSpace
    {
        get { return m_currentStorageSpace; }
        set { m_currentStorageSpace = value; }
    }
    
    public static int StationsLeft
    {
        get { return m_stationsLeft; }
        set { m_stationsLeft = value; }
    }
    public static int[] Crew
    {
        get { return m_crew; }
        set { m_crew = value; }
    }
    public static string[] CrewNames
    {
        get { return m_crewNames; }
        set { m_crewNames = value; }
    }
    public static bool RocketBoots
    {
        get { return m_rocketBoots; }
        set { m_rocketBoots = value; }
    }
    public static bool Juicer
    {
        get { return m_juicer; }
        set { m_juicer = value; }
    }
    public static bool Book
    {
        get { return m_book; }
        set { m_book = value; }
    }
    public static bool Knife
    {
        get { return m_knife; }
        set { m_knife = value; }
    }
    public static bool RiskyFuel
    {
        get { return m_riskyFuel; }
        set { m_riskyFuel = value; }
    }



    private static int m_armorKit;
    private static int m_specialty1;
    private static int m_specialty2;

    public static int ArmorKit
    {
        get { return m_armorKit; }
        set { m_armorKit = value; }
    }
    

}