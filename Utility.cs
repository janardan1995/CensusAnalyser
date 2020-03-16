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
        public static string[] sort(string[] line, int placeHolder)
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
}
