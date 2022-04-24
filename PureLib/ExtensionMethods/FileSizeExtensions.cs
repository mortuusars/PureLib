using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PureLib;

public static class FileSizeExtensions
{
    /// <summary>
    /// Converts number of bytes to the corresponding size in parts of 1024. KB, MB, GB, etc.
    /// </summary>
    /// <param name="bytes">Total number of bytes. Can have negative value.</param>
    /// <param name="bibytes">Specifies whether to use KiB, MiB, etc - instead of KB, MB.</param>
    /// <returns>Human readable size value - 50 KB, 1.4 GB, etc. If result is in B or KB - it will be rounded to whole number. Otherwise - to the 1st decimal number.</returns>
    public static string ToSize(this long bytes, bool bibytes = false)
    {
        decimal size = bytes;
        int numberOfDivisions = 0;

        while (Math.Abs(size) > 1024)
        {
            size /= 1024;
            numberOfDivisions++;
        }

        // No decimal part if KB.
        decimal number = numberOfDivisions == 1 ? Math.Round(size, 0) : Math.Round(size, 1);

        string[] chars = bibytes ?
            new string[] { "B", "KiB", "MiB", "GiB", "TiB", "PiB", "EiB" } :
            new string[] { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
        
        return $"{number} {chars[numberOfDivisions]}";
    }
}
