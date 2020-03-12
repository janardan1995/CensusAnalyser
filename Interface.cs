// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Interface.cs" company="Bridgelabz">
//   Copyright © 2020 Company="BridgeLabz"
// </copyright>
// <creator name="Janardan Das"/>
// --------------------------------------------------------------------------------------------------------------------

namespace CensusAnalyserLibrary
{
    /// <summary>
    /// This is the interface class
    /// </summary>
    public interface ICSVStatecensus
    {
     object CSVDataUsingIEnumerator(string FilePath, char delimiter = ',');
    }   
}
