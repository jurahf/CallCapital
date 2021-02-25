using Services.DataClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Services.CrocodileServices
{
    public class CrocodileDataSource
    {
        private static CrocodileDataSource instance;
        private const string csvPath = @"CrocodileServices\Data\Crocodile.txt";
        private static List<Crocodile> allCrocodiles = new List<Crocodile>();

        private CrocodileDataSource()
        {
            Init();
        }

        public static CrocodileDataSource Instance()
        {
            if (instance == null)
                instance = new CrocodileDataSource();

            return instance;
        }

        public List<Crocodile> Get()
        {
            return allCrocodiles;
        }

        private void Init()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(AppContext.BaseDirectory, csvPath)))
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    string[] parts = str.Split('\t');
                    Crocodile crocodile = new Crocodile()
                    {
                        Phrase = parts[1],
                        Theme = parts[0]
                    };

                    allCrocodiles.Add(crocodile);
                }
            }
        }
    }
}
