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
        public static void Sorted(string[] line)
        {
            for (int i = 1; i < line.Length - 1; i++)
            {
                var min = i;
                var Key1 = line[i].Split(',')[0];
                for (int j = i + 1; j < line.Length; j++)
                {
                    var key2 = line[j].Split(',')[0];
                    if (Key1.CompareTo(key2) > 0)
                    {
                        Key1 = key2;
                        min = j;
                    }
                }
                var temp = line[i];
                line[i] = line[min];
                line[min] = temp;
                File.WriteAllLines(@"C:\Users\Bridge Labz\Desktop\censusdata\Statea.csv", line);
                //var sorted = data.Select(line => new { SortKey = line.Split(',')[0],Line = line }).OrderBy(x => x.SortKey).Select(x => x.Line);
            }
        }

        public static string[] sort(string[] line)
        {

            /// <summary>
            /// Sort Algorithm
            /// </summary>
            /// <param name="line"></param>

            for (int i = 1; i < line.Length - 1; i++)
            {
                var min = i;
                var Key1 = line[i].Split(',')[3];
                for (int j = i + 1; j < line.Length; j++)
                {
                    var key2 = line[j].Split(',')[3];
                    if (Key1.CompareTo(key2) > 0)
                    {
                        Key1 = key2;
                        min = j;
                    }
                }
                var temp = line[i];
                line[i] = line[min];
                line[min] = temp;
               // File.WriteAllLines(@"C:\Users\Bridge Labz\Desktop\censusdata\Statea.csv", line);
            }
            return line;
        }

        /// <summary>
        /// Convert CSV file Into Json object
        /// </summary>
        /// <param name="path"></param>
        /// <returns>it return JSON file</returns>
        public static string ConvertCsvFileToJsonObject(string path)
        {
            var csv = new List<string[]>();
            var lines = File.ReadAllLines(path);

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
    }
    //public class RootObject
    //{
    //    public string State { get; set; }
    //    public int Population { get; set; }
    //    public object AreaInSqKm { get; set; }
    //    public object DensityPerSqKm { get; set; }
    //}
    //public static void ff()
    //{
    //    List<RootObject> _data = new List<RootObject>();
    //    _data.Add(new RootObject()
    //    {
    //        State = "message",
    //        Population = 1,
    //        AreaInSqKm = 2,
    //        DensityPerSqKm = 3
    //    });
    //    string json = JsonConvert.SerializeObject(_data.ToArray());

    //    //write string to file
    //    File.WriteAllText(@"C:\Users\Bridge Labz\Desktop\censusdata\xx.json", json);
    // }
}
