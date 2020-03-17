using System.IO;
using System.Collections.Generic;
using System;

namespace CensusAnalyserLibrary
{
    public class USCensusCsv
    {
        public static string USCensus(string path)
        {
            string[] lines = File.ReadAllLines(path);
            string x = Utility.ConvertCSVFileToJsonObject(lines);
            return x;
        }
    }
}
