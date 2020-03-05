// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CSVStateCensus.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Janardan Das"/>
// --------------------------------------------------------------------------------------------------------------------


namespace CensusAnalyserLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;

    /// <summary>
    /// This is CSVStateCensus class
    /// </summary>
    public class CSVStateCensus
    {
        /// <summary>
        /// In this method i am using Ienumerable
        /// </summary>
        /// <returns>it returns the string value</returns>
        public static object CSVDataUsingIEnumerator(string FilePath, char delimiter=',')
        {            
            try
            {               
                if (!File.Exists(FilePath))
                   throw new CensusAnalyseException("ERROR_IN_FILE_READING");
                
                ////This line reads the CSV file and store it into the strings of array
                string[] Lines = File.ReadAllLines(FilePath);
                if(Lines[0]!= "State,Population,AreaInSqKm,DensityPerSqKm")
                {
                    throw new CensusAnalyseException("HEADER_IS_NOT_FOUND");
                }                   
                             
           
                foreach (var line in File.ReadLines(FilePath))
                {                  
                   
                    ////For delimeter
                    string[] LineCount= line.Split(delimiter);
                    if (LineCount.Length !=4 && LineCount.Length!=2)
                        throw new CensusAnalyseException("INVALID_DELIMITER");                                      
                }

                int count = 0;

                ////store the list into iterator(IEnumerable)
                IEnumerable<string> iterator = Lines;
                foreach(var item in iterator)
                    count++;              

                return count;
            }
            catch (CensusAnalyseException ex)
            {
                return ex.Message;
            }
        }
    }
}

