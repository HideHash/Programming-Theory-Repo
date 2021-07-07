using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public enum ColorNumber
    {
        red, green, blue
    }

    public static Color[] ColorArray = new Color[]
    {
        Color.red,
        Color.green,
        Color.blue,
    };

    
    public static Color GetRandomColor()
    {
        return ColorArray[Random.Range(0, ColorArray.Length)];
    }

    public static int[] ShuffleArray(int[] src)
    {
        int[] dest = new int[src.Length];
        src.CopyTo(dest,0);
        for(int i=0; i < dest.Length-1; ++i)
        {
            int r = Random.Range(i+1, dest.Length);
            int temp = dest[i];
            dest[i] = dest[r];
            dest[r] = temp;
        }

        return dest;
    }
}
