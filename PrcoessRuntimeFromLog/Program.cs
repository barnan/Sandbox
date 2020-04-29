using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace PrcoessRuntimeFromLog
{
    internal class Program
    {
        private static string csvSeparator = ";";

        /// <summary>
        /// main method of the whole app. The input files are always searched in the current folder of the application
        /// </summary>
        /// <param name="args">
        /// args[0] -> path and filename. The filename must contain the required "search-texts" separated by a new line charachter. The output is stored in "[InputFileName]_output.csv" 
        ///         -> the search text itsef. In this case only one search text can be given. The output is stored in "output.csv" </param>
        static void Main(string[] args)
        {
            string regexPattern = "[\\d]*ms$";
            string currentDirectoryPath = Directory.GetCurrentDirectory(); // Assembly.GetExecutingAssembly().Location;

            #region check input

            // check input parameters
            if (args.Length != 1)
            {
                Console.WriteLine("Number of input argments is not sufficient.");
                return;
            }

            if (string.IsNullOrEmpty(args[0]) || string.IsNullOrWhiteSpace(args[0]))
            {
                Console.WriteLine("The input argument is empty or consists of white spaces");
                return;
            }

            #endregion

            #region define temp variables

            //List<string> listOfInputEntries;
            Dictionary<string, List<double>> elapsedTimeCollection;
            Dictionary<string, ValueTuple<double, double, double, double, double>> timeStatistics;

            string outputFileName = "_";
            if (!File.Exists(args[0])) // the parameter is the search string itself
            {
                outputFileName = "output.csv";
                //listOfInputEntries = new List<string> { args[0] };
                elapsedTimeCollection = new Dictionary<string, List<double>> { { args[0], new List<double>() } };
                timeStatistics = new Dictionary<string, ValueTuple<double, double, double, double, double>>();
            }
            else // the parameter is the name of a file containing the search strings
            {
                outputFileName = $"{Path.GetFileNameWithoutExtension(args[0])}_output.csv";

                string text = File.ReadAllText(args[0]);
                string[] textRows = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

                //listOfInputEntries = new List<string>(textRows);
                elapsedTimeCollection = new Dictionary<string, List<double>>();
                timeStatistics = new Dictionary<string, ValueTuple<double, double, double, double, double>>();
                foreach (string textRow in textRows)
                {
                    elapsedTimeCollection.Add(textRow, new List<double>());
                }

            }

            #endregion

            #region collect files

            // get available files
            string[] fileList = Directory.GetFiles(currentDirectoryPath, "*.log");
            if (fileList.Length == 0)
            {
                Console.WriteLine("No *.log files were found in the given folder");
                return;
            }

            #endregion

            #region read file cntents

            double progressStep = 1d / fileList.Length * 100;
            double currentProgress = 0d;

            // go through files and gather searched entries
            foreach (string file in fileList)
            {
                Console.WriteLine($"Progress: {currentProgress}");

                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string rowText = sr.ReadLine();

                        if (string.IsNullOrWhiteSpace(rowText) || string.IsNullOrEmpty(rowText))
                        {
                            continue;
                        }

                        foreach (string inputEntry in elapsedTimeCollection.Keys)
                        {
                            if (rowText.Contains(inputEntry))
                            {
                                Match match = Regex.Match(rowText, regexPattern);
                                int removeStart = match.Value.Length - 2;
                                int removeLength = 2;

                                if (double.TryParse(match.Value.Remove(removeStart, removeLength), out double eTime_ms))
                                {
                                    elapsedTimeCollection[inputEntry].Add(eTime_ms);
                                }

                                break;
                            }
                        }
                    }
                }

                currentProgress += progressStep;
            }

            #endregion

            CalculateStatistics(elapsedTimeCollection, timeStatistics);

            SaveResult(outputFileName, elapsedTimeCollection, timeStatistics);

            //Console.ReadKey();
        }


        private static void CalculateStatistics(Dictionary<string, List<double>> elapsedTimeCollection, Dictionary<string, ValueTuple<double, double, double, double, double>> timeStatistics)
        {
            foreach (KeyValuePair<string, List<double>> pair in elapsedTimeCollection)
            {
                if (pair.Value.Count < 1)
                {
                    continue;
                }

                double average = pair.Value.Average();
                double min = pair.Value.Min();
                double max = pair.Value.Max();
                double median = pair.Value.OrderBy(p => p).ToArray()[pair.Value.Count / 2];
                double std = pair.Value.StdDev();

                timeStatistics.Add(pair.Key, (min, max, average, median, std));
            }
        }


        private static void SaveResult(string outputFileName, Dictionary<string, List<double>> elapsedTimeCollection, Dictionary<string, ValueTuple<double, double, double, double, double>> timeStatistics)
        {
            using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (KeyValuePair<string, List<double>> pair in elapsedTimeCollection)
                {
                    sw.Write(pair.Key);
                    sw.Write(csvSeparator);

                    if (pair.Value.Count >= 1)
                    {
                        foreach (double number in pair.Value)
                        {
                            sw.Write(number);
                            sw.Write(csvSeparator);
                        }

                        sw.Write(csvSeparator);
                        sw.Write(timeStatistics[pair.Key].Item1);
                        sw.Write(csvSeparator);
                        sw.Write(timeStatistics[pair.Key].Item2);
                        sw.Write(csvSeparator);
                        sw.Write(timeStatistics[pair.Key].Item3);
                        sw.Write(csvSeparator);
                        sw.Write(timeStatistics[pair.Key].Item4);
                        sw.Write(csvSeparator);
                        sw.Write(timeStatistics[pair.Key].Item5);
                    }

                    sw.WriteLine();
                }
            }
        }
    }


    public static class Extensions
    {
        public static double StdDev(this IEnumerable<double> values)
        {
            double ret = 0;
            int count = values.Count();
            if (count > 1)
            {
                //Compute the Average
                double avg = values.Average();

                //Perform the Sum of (value-avg)^2
                double sum = values.Sum(d => (d - avg) * (d - avg));

                //Put it all together
                ret = Math.Sqrt(sum / count);
            }

            return ret;
        }
    }
}
