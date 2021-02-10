using System;
using System.IO;
using System.Collections.Generic;
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
            Console.WriteLine("2. Display Movies.");
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

                //make a file reader object and have it parse the file
                FileReader fr = new FileReader(movieFile);
                fr.parseFile();

                //get our values in three parallel array lists
                List<string> movieID = fr.getIDs();
                List<string> movieTitles = fr.getTitles();
                List<string> genres = fr.getGenres();

                for (var i = 0; i < movieID.Count; i++)
                {
                    Console.WriteLine($"Movie ID: {movieID[i]}, Movie Title: {movieTitles[i]}, Genres: {genres[i]}");
                }

            }
            logger.Info("Program ended");


        }
    }
}
