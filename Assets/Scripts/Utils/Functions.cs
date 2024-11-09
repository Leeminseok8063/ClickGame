using System;
using System.Linq;


static public class Functions
{
    static public int GetDigit(string name)
    {
        string numberString = new string(name.Where(char.IsDigit).ToArray());
        return int.TryParse(numberString, out int val) ? val : 0;
    }

    static public void SortObject<T>(T[] target) where T : UnityEngine.Object
    {
        Array.Sort(target, (val1, val2) =>
        {
            int temp01 = Functions.GetDigit(val1.name);
            int temp02 = Functions.GetDigit(val2.name);

            return temp01.CompareTo(temp02);
        });
    }
}



