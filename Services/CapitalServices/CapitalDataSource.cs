using Newtonsoft.Json;
using Services.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Services.CapitalServices
{
    public class CapitalDataSource
    {
        private static CapitalDataSource instance;
        private const string csvPath = @"CapitalServices\Data\Capital.csv";
        private static List<Capital> allCapitals = new List<Capital>();

        private CapitalDataSource()
        {
            Init();
        }

        public static CapitalDataSource Instance()
        {
            if (instance == null)
                instance = new CapitalDataSource();

            return instance;
        }

        public List<Capital> Get()
        {
            return allCapitals;
        }

        private void Init()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(AppContext.BaseDirectory, csvPath)))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    string[] parts = str.Split(';');
                    Capital capital = JsonConvert.DeserializeObject<Capital>(parts[2]);
                    capital.Id = int.Parse(parts[0]);

                    allCapitals.Add(capital);
                }
            }
        }



    }
}
