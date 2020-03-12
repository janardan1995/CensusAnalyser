// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CSVBuilder.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Janardan Das"/>
// --------------------------------------------------------------------------------------------------------------------

namespace CensusAnalyserLibrary
{
    using System;

    /// <summary>
    /// create a delegate for builder class
    /// </summary>
    /// <param name="statecensus">its a interface</param>
    /// <param name="FileName">our original file</param>
    /// <param name="delimiter">optional</param>
    /// <returns>its return object</returns>
    public delegate object DelegateCSVDirector(ICSVStatecensus statecensus, String FileName, char delimiter = ',');

    public class CSVBuilder
    {  
        /// <summary>
        /// this is Director class in builder
        /// </summary>
        /// <param name="statecensus">interface</param>
        /// <param name="FileName">file path</param>
        /// <param name="delimiter">optional</param>
        /// <returns>returns object</returns>
         public object CSVDirector(ICSVStatecensus statecensus, String FileName, char delimiter=',')
         {            
            object obj=statecensus.CSVDataUsingIEnumerator(FileName,delimiter);
            return obj;
         }       
    }
}


