using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ImageComparer:IComparer<string>
{
	public ImageComparer()
	{
	}

    private int extractFileNumber(string fileName)
    {
        return int.Parse(Regex.Match(Regex.Match(fileName, @"[0-9]+\.jpg").ToString(), @"[0-9]+").ToString());
    }

    public int Compare(string x, string y)
    {
        int numberX = extractFileNumber(x);
        int numberY = extractFileNumber(y);
        if (numberX > numberY)
            return 1;
        else if (numberX < numberY)
            return -1;
        else
            return 0;
    }
}
