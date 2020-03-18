// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoodAnalyserException.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Janardan Das"/>
// --------------------------------------------------------------------------------------------------------------------

namespace CensusAnalyserLibrary
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    /// <summary>
    /// This is state census Analyser class
    /// </summary>
    /// <summary>
    /// this methods read the csv file and return as a array of strings
    /// </summary>

    public class StateCensusAnalyser
    {
        /// <summary>
        /// sort by alphabate
        /// </summary>
        /// <returns></returns>
        public static string SortStateAlphabatic(int palceholder, string path)
        {
            string[] line = File.ReadAllLines(path);
            var sortedData = Utility.sortAlphabatic(line, palceholder);
            var str = Utility.ConvertCSVFileToJsonObject(sortedData);
            return str;
        }

        /// <summary>
        /// sort bt integer
        /// </summary>
        /// <param name="palceholder"></param>
        /// <returns></returns>
        public static string StateCensusSortByIntegerValue(int palceholder)
        {
            string[] line = File.ReadAllLines(@"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCensusData.CSV");
            var sorted = Utility.SortingInt(line, palceholder);
            var str = Utility.ConvertCSVFileToJsonObject(sorted);
            return str;
        }

        /// <summary>
        /// there are two csv file ie StateCensusData and StateCode
        /// these two csv
        /// </summary>
        /// <returns></returns>
        public static string[] MergingTwoCsvData()
        {
            string[] load1 = File.ReadAllLines(@"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCode.csv");
            string[] load2 = File.ReadAllLines(@"C:\Users\Bridge Labz\source\repos\CensusAnalyserLibrary\StateCensusData.csv");
            
            List<string> list = new List<string>();
            var aa = load1[0].Split(',')[0] + "," + load1[0].Split(',')[1] + "," + load2[0].Split(',')[1] + "," + load1[0].Split(',')[2] + "," + load1[0].Split(',')[3] + "," + load2[0].Split(',')[2] + "," + load2[0].Split(',')[3];
            list.Add(aa);

            var count = 0;
            int slNo = 1;
            for (int i = 1; i < load1.Length; i++)
            {
                string[] CSVCode = load1[i].Split(',');

                int a = 1;
                for (int j = 1; j < load2.Length; j++)
                {
                    string[] CSVData = load2[j].Split(',');
                    if (CSVCode[1] == CSVData[0])
                    {
                        var bb = slNo + "," + CSVCode[1] + "," + CSVData[1] + "," + CSVCode[2] + "," + CSVCode[3] + "," + CSVData[2] + "," + CSVData[3];
                        list.Add(bb);
                        count++;
                        slNo++;
                        a = 0;
                    }
                }
                if (a == 1)
                {
                    var cc = slNo + "," + CSVCode[1] + "," + "0" + "," + CSVCode[2] + "," + CSVCode[3] + "," + "0" + "," + "0";
                    list.Add(cc);
                    count++;
                    slNo++;
                }
            }
            return list.ToArray();
        }
    }
}

