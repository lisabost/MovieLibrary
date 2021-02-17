using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using NLog.Web;
using System.Linq;

namespace MovieLibrary
{
    class FileReader
    {
        private static NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        //fields
        private string _filePath;

        public List<Int32> movieIDs;
        public List<string> movieTitles;
        public List<string> genres;
        public List<string> header;

        //constructor
        public FileReader(string filePath)
        {
            this._filePath = filePath;
            movieIDs = new List<Int32>();
            movieTitles = new List<string>();
            genres = new List<string>();

        }

        //methods
        public void parseFile()
        {
            //make a text field parser
            TextFieldParser parser = new TextFieldParser(_filePath);
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");

            string[] arr;
            header = new List<string>();
            bool isFirst = true;
            try
            {
                while (!parser.EndOfData)
                {
                    if (isFirst)
                    {
                        arr = parser.ReadFields();
                        header.Add(arr[0]);
                        header.Add(arr[1]);
                        header.Add(arr[2]);
                        isFirst = false;
                    }
                    arr = parser.ReadFields();
                    movieIDs.Add(Int32.Parse(arr[0]));
                    movieTitles.Add(arr[1]);
                    genres.Add(arr[2]);
                }
            }
            catch (Exception ex)
            {
                logger.Info("Something isn't being parsed correctly");
                logger.Info(ex.StackTrace);
            }
        }

        //check for duplicate titles
        public bool isTitleUnique(string title)
        {
            if (movieTitles.ConvertAll(m => m.ToLower()).Contains(title.ToLower()))
            {
                logger.Info("Duplicate movie title {Title}", title);
                return false;
            }
            return true;
        }
        public void addMovie(Movie movie) 
        {
            //TODO figure out how to find max value of list<string> movieIDs
            //movie.movieID = movieIDs.Max() + 1;
            StreamWriter sw = new StreamWriter(_filePath, true);
            sw.WriteLine($"{movie.movieID}, {movie.title}, {string.Join("|", movie.genres)}");
            sw.Close();
        }

        //make the values public
        public List<Int32> getIDs()
        {
            return movieIDs;
        }

        public List<string> getTitles()
        {
            return movieTitles;
        }

        public List<string> getGenres()
        {
            return genres;
        }
        
        public List<string> getHeader()
        {
            return header;
        }
    }
}