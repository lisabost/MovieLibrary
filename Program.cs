using System;
using System.IO;
using NLog.Web;

namespace MovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            // create instance of Logger
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            logger.Info("Program started");

            Console.WriteLine("Enter 1 to add a movie.");
            Console.WriteLine("Enter 2 to read movies in the file.");
            Console.WriteLine("Enter anything else to quit.");

            string resp = Console.ReadLine();

            if (resp == "1")
            {
                //TODO: Implement adding movies to the file
                //TODO: Implement checking for existing movie in the file
            }
            else if (resp == "2")
            {
                //path to the CSV file
                string movieFile = "C:/Users/Corey/DotNetDBProjects/MovieLibrary/ml-latest-small/movies.csv";
                //read lines in the file
                StreamReader sr = new StreamReader(movieFile);

                while (!sr.EndOfStream) {
                    string line = sr.ReadLine();

                    string[] arr = line.Split(",");
                    Console.WriteLine("Movie ID: {0}, Movie Title: {1}, Genre(s): {2}", arr[0], arr[1], arr[2]);
                }
                
            }
            logger.Info("Program ended");


        }
    }
}
