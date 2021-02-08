using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;
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

            Console.WriteLine("1. Add a Movie.");
            Console.WriteLine("2 Display Movies.");
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
                TextFieldParser parser = new TextFieldParser(movieFile);

                parser.HasFieldsEnclosedInQuotes = true;
                parser.SetDelimiters(",");

                string[] arr;
                
                while (!parser.EndOfData){
                    arr = parser.ReadFields();
                    Console.WriteLine("Movie ID: {0}, Movie Title: {1}, Genre(s): {2}", arr[0], arr[1], arr[2]);
                }
                
            }
            logger.Info("Program ended");


        }
    }
}
