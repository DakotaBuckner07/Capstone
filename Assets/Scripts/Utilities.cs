using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    private static float overallLevel = 0.9f;
    public static float OverallLevel { get => overallLevel; }

    public static int newMonsterHealth()
    {
        overallLevel += 0.1f;
        return (int)(overallLevel * 15);
    }

    public static int GetRandNumTimesLevel(int min, int max)
    {
        return (int)(Random.Range(min, max) * overallLevel);
    }

    public static Element GetRandomElement()
    {
        int elementInt = Random.Range(0, 4);
        Element e;
        switch (elementInt)
        {
            case 0:
                e = Element.Air;
                break;
            case 1:
                e = Element.Water;
                break;
            case 2:
                e = Element.Earth;
                break;
            default:
                e = Element.Fire;
                break;
        }
        return e;
    }

    /// <summary>
    /// if A is strong against B, returns 1.
    /// if A is weak to B, returns -1
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int CheckElements(Element a, Element b)
    {
        int weakness = 0;
        switch (a)
        {
            case Element.Air:
                if (b == Element.Earth) weakness = 1;
                if (b == Element.Fire) weakness = -1;
                break;
            case Element.Earth:
                if (b == Element.Water) weakness = 1;
                if (b == Element.Air) weakness = -1;
                break;
            case Element.Water:
                if (b == Element.Earth) weakness = -1;
                if (b == Element.Fire) weakness = 1;
                break;
            case Element.Fire:
                if (b == Element.Water) weakness = -1;
                if (b == Element.Air) weakness = 1;
                break;
            default:
                break;
        }
        return weakness;
    }
}

public enum Element
{
    Air, //Defeats earth
    Earth, //Defeats Water
    Water, //Defeats Fire
    Fire //Defeats Air
}
