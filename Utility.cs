// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MoodAnalyserException.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Janardan Das"/>
// --------------------------------------------------------------------------------------------------------------------
namespace CensusAnalyserLibrary
{
    using System.IO;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// This is Utility Class 
    /// Where we can write the logical code to minimize the length of the main class
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// Sort Algorithm 
        /// </summary>
        /// <param name="line"></param>    
        public static string[] sortAlphabatic(string[] line, int placeHolder)
        {
            /// <summary>
            /// Sort Algorithm
            /// </summary>
            /// <param name="line"></param>

            for (int i = 1; i < line.Length - 1; i++)
            {
                var min = i;
                var Key1 = line[i].Split(',')[placeHolder];
                for (int j = i + 1; j < line.Length; j++)
                {
                    var key2 = line[j].Split(',')[placeHolder];
                    if (Key1.CompareTo(key2) > 0)
                    {
                        Key1 = key2;
                        min = j;
                    }
                }
                var temp = line[i];
                line[i] = line[min];
                line[min] = temp;
            }
            return line;
        }

        /// <summary>
        /// Convert CSV file Into Json object
        /// </summary>
        /// <param name="path"></param>
        /// <returns>it return JSON file</returns>        
        public static string ConvertCSVFileToJsonObject(string[] lines)
        {
            var csv = new List<string[]>();

            foreach (string line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (int j = 0; j < lines[i].Split(',').Length; j++)
                    objResult.Add(properties[j], csv[i][j]);

                listObjResult.Add(objResult);
            }
            return JsonConvert.SerializeObject(listObjResult);
        }

        /// <summary>
        /// Sort Algorithm 
        /// </summary>
        /// <param name="line"></param>    
        public static string[] SortingInt(string[] line, int placeHolder)
        {

            /// <summary>
            /// Sort Algorithm
            /// </summary>
            /// <param name="line"></param>

            for (int i = 1; i < line.Length - 1; i++)
            {
                var min = i;
                var Key1 = int.Parse(line[i].Split(',')[placeHolder]);
                for (int j = i + 1; j < line.Length; j++)
                {
                    var key2 = int.Parse(line[j].Split(',')[placeHolder]);
                    if (Key1 < key2)
                    {
                        Key1 = key2;
                        min = j;
                    }
                }
                var temp = line[i];
                line[i] = line[min];
                line[min] = temp;
            }
            return line;
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

    /// <summary>
    /// this is a class for stateCensus
    /// </summary>
    public class StateCensusClass
    {
        public string State { get; set; }
        public int Population { get; set; }
        public int AreaInSqKm { get; set; }
        public int DensityPerSqKm { get; set; }
    }

    /// <summary>
    /// This is the StateCode Class
    /// </summary>
    public class StateCodeClass
    {
        public int SrNo { get; set; }
        public string StateName { get; set; }
        public int TIN { get; set; }
        public string StateCode { get; set; }
    }

    /// <summary>
    /// CSV Us Data is reading from this class
    /// </summary>
    public class USCsvDataClass
    {
        public string StateId { get; set; }
        public string State { get; set; }
        public int Population { get; set; }
        public int Housingunits { get; set; }
        public double TotalArea { get; set; }
        public double WaterArea { get; set; }
        public double LandArea { get; set; }
        public double PopulationDensity { get; set; }
        public double HousingDensity { get; set; }
    }


}
