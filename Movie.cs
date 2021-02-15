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
        public List<string> movieTitles;
        public List<string> movieIds;

        //constructor for our movie object
        public Movie(List<string> titles, List<string> movieID)
        {
            this.movieTitles = titles;
            this.movieIds = movieID;
        }

        //when we set the title check to see if there is a comma in the movie title
        //if there is wrap the title in quotes
        public string title
        {
            get
            {
                return this.title;
            }
            set
            {
                //if the index of the comma = -1 there is no comma in the string
                //so we can set the title of our movie to the string entered
                string movieTitle = title.IndexOf(",") != -1 ? $"\"{title}\"" : title;
                //check to see if the movie title is unique
                if (movieTitles.Contains(movieTitle))
                {
                    Console.WriteLine("This title is already in the list.");
                }
                else
                {
                    this.title = movieTitle;
                }
            }

        }
    }
}
