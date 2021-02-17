using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using NLog.Web;

namespace MovieLibrary
{
    class FileWriter
    {
        private static NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        private string _filePath;
        public List<Movie> Movies { get; set; }

        //constructor
        public FileWriter(string filePath)
        {
            this._filePath = filePath;
            Movies = new List<Movie>();
        }

        //check for duplicate titles
        public bool isTitleUnique(string title)
        {
            if (Movies.ConvertAll(m => m.title.ToLower()).Contains(title.ToLower()))
            {
                logger.Info("Duplicate movie title {Title}", title);
                return false;
            }
            return true;
        }

        //if no duplicate title add movie to list

        //use textfieldparser to parse the lines
        //make an array of the titles
        //convert titles to lowercase
        //compare with user input converted to lowercase

    }
}