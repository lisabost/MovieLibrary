using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using NLog.Web;

namespace MovieLibrary
{

    class Movie
    {
        public List<string> genres { get; set; }
        public UInt64 movieID { get; set;}
        string _title;

        //constructor for our movie object
        public Movie()
        {
            genres = new List<string>();
        }

        //when we set the title check to see if there is a comma in the movie title
        //if there is wrap the title in quotes
        public string title
        {
            get
            {
                return this._title;
            }
            set
            {
                //if the index of the comma = -1 there is no comma in the string
                //so we can set the title of our movie to the string entered
                this._title = value.IndexOf(",") != -1 ? $"\"{value}\"" : value;
            }
        }
        public bool isTitleUnique(string title, List<string> titles)
        {
            if (titles.ConvertAll(m => m.ToLower()).Contains(title))
            {
                return false;
            }
            return true;
        }
    }
}
