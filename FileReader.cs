using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using NLog.Web;

namespace MovieLibrary
{
    class FileReader
    {
        private static NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        //fields
        private string _filePath;

        public List<string> movieIDs;
        public List<string> movieTitles;
        public List<string> genres;

        //constructor
        public FileReader(string filePath)
        {
            this._filePath = filePath;
            movieIDs = new List<string>();
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
            try
            {
                while (!parser.EndOfData)
                {
                    arr = parser.ReadFields();
                    movieIDs.Add(arr[0]);
                    movieTitles.Add(arr[1]);
                    genres.Add(arr[2]);
                }
            }
            catch
            {
                logger.Info("No file found");
            }
        }

        //make the values public
        public List<string> getIDs()
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
    }
}