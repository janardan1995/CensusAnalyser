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
        public static object CSVDataUsingIEnumerator(string FilePath, char delimeter=',')
        {            
            try
            {               
                if (!File.Exists(FilePath))
                   throw new CensusAnalyseException("ERROR_IN_FILE_READING");
                
                ////This line reads the CSV file and store it into the strings of array
                string[] Lines = File.ReadAllLines(FilePath);
                
                ////create a list to store the data in the file
                List<string> myList = new List<string>();           
                             
           
                foreach (var line in Lines)
                {
                    ////to add the data in the list that hve created in the above
                    myList.Add(line);
                   
                    ////For delimeter
                    string[] LineCount= line.Split(delimeter);
                    if (LineCount.Length !=4 && LineCount.Length !=2)
                        throw new CensusAnalyseException("Invalide_Delimeter");                                      
                }

                int count = 0;

                ////store the list into iterator(IEnumerable)
                IEnumerable<string> iterator = myList;
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

