using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using NLog.Web;

namespace MovieLibrary
{
    class Program
    {
        private static NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        //path to the CSV file

        static void Main(string[] args)
        {
            string movieFile = "C:/Users/Corey/DotNetDBProjects/MovieLibrary/movies.csv";

            FileReader fr = new FileReader(movieFile);

            fr.parseFile();

            //get our values in three parallel array lists
            List<UInt64> movieID = fr.getIDs();
            List<string> movieTitles = fr.getTitles();
            List<string> genres = fr.getGenres();
            List<string> header = fr.getHeader();

            logger.Info("Program started");

            Console.WriteLine("1. Add a Movie.");
            Console.WriteLine("2. Display Movies.");
            Console.WriteLine("Enter anything else to quit.");

            string resp = Console.ReadLine();

            if (resp == "1")
            {
                Movie movie = new Movie();

                //get the movie's title
                Console.WriteLine("Enter the movie's title.");
                movie.title = Console.ReadLine();

                if (fr.isTitleUnique(movie.title))
                {
                    //get genres from user
                    string input;

                    do
                    {
                        Console.WriteLine("Enter genre (or done to quit)");
                        input = Console.ReadLine();

                        if (input != "done" && input.Length > 0)
                        {
                            movie.genres.Add(input);
                        }
                    } while (input != "done");
                    if (movie.genres.Count == 0)
                    {
                        movie.genres.Add("(no genres listed)");
                    }
                    //Add movie to file
                    fr.addMovie(movie);
                }
            }
            else if (resp == "2")
            {
                Console.WriteLine($"{header[0]},{header[1]}, {header[2]}");

                for (var i = 0; i < movieID.Count; i++)
                {
                    Console.WriteLine($"Movie ID: {movieID[i]}, Movie Title: {movieTitles[i]}, Genres: {genres[i]}");
                }

            }
            logger.Info("Program ended");


        }
    }
}
