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
                //make a new movie object
                Movie movie = new Movie();

                //get the movie's title
                Console.WriteLine("Enter the movie's title.");
                string title = Console.ReadLine();
                //set our title
                movie.title = title;

                //TODO: Handle when titles have "," in them
                //TODO: Make sure movie title is unique

                string input;
                do
                {
                    Console.WriteLine("Enter the movie's genre (enter done to finish)");
                    input = Console.ReadLine();
                    if (input != "done" && input.Length > 0)
                    {
                        //add genre to our movie only if the user entered a valid string
                        movie.genre.Add(input);
                    }
                } while (input != "done");

                //if there is no genre
                if (movie.genre.Count == 0)
                {
                    movie.genre.Add("(no genres listed");
                }
                
                //TODO: Add movie to file


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

                while (!parser.EndOfData)
                {
                    arr = parser.ReadFields();
                    Console.WriteLine("Movie ID: {0}, Movie Title: {1}, Genre(s): {2}", arr[0], arr[1], arr[2].Replace("|", ", "));
                }

            }
            logger.Info("Program ended");


        }
    }
}
