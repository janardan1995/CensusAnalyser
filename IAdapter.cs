using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserLibrary
{
    public interface IAdapter
    {
        int LoadUSData(string Path, char delimiter = ',');

        int LoadIndiaData(string Path, char delimiter = ',');
    }
}
