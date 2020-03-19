using System.IO;
using System.Collections.Generic;
using System;


namespace CensusAnalyserLibrary
{
    public class AdapterClass  : CSVStateANDCode , IAdapter
    {

        public int LoadIndiaData(string Path, char delimiter = ',')
        {
           int a= LoadIndiaCSVData(Path,delimiter);
            return a;
            
        }
        public int LoadUSData(string Path, char delimiter = ',')
        {
            int aa= LoadUSCsvData(Path, delimiter);
            return aa;
        }


        public int LoadUSCsvData(string path, char delimiter = ',')
        {
            FileInfo info = new FileInfo(path);
            string type = info.Extension;
            if (type.ToLower() != ".csv")
            {
                throw new CensusAnalyseException(MyEnum.INCORRECT_TYPE.ToString());
            }

            if (!File.Exists(path))
            {
                throw new CensusAnalyseException(MyEnum.ERROR_IN_FILE_READING.ToString());
            }

            Dictionary<int, USCsvDataClass> USDict = new Dictionary<int, USCsvDataClass>();
            using (StreamReader sr = new StreamReader(path))
            {
                var str = sr.ReadLine();
                if (str != "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density")
                {
                    throw new CensusAnalyseException(MyEnum.HEADER_IS_NOT_FOUND.ToString());
                }
                else if (str.Split(delimiter).Length != 9)
                {
                    throw new CensusAnalyseException(MyEnum.INVALID_DELIMITER.ToString());
                }
                string s = "";
                int k = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s != "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density")
                    {
                        USCsvDataClass us = new USCsvDataClass()
                        {
                            StateId = s.Split(',')[0],
                            State = s.Split(',')[1],
                            Population = int.Parse(s.Split(',')[2]),
                            Housingunits = int.Parse(s.Split(',')[3]),
                            TotalArea = Double.Parse(s.Split(',')[4]),
                            WaterArea = Double.Parse(s.Split(',')[5]),
                            LandArea = Double.Parse(s.Split(',')[6]),
                            PopulationDensity = Double.Parse(s.Split(',')[7]),
                            HousingDensity = Double.Parse(s.Split(',')[8])
                        };
                        USDict.Add(k, us);
                        k++;
                    }
                }
            }
            return USDict.Count;
        }

    }
}
