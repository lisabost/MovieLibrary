using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
using NLog.Web;

namespace MovieLibrary
{

    class Movie
    {
        public List<string> genre { get; set; }

        //constructor for our movie object
        public Movie(){ }

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
                this.title = title.IndexOf(",") != -1 ? $"\"{title}\"" : title;
            }
        }
        // public string movieID
        // {
        //     get
        //     {
        //         return this.movieID;
        //     }
        //     set
        //     {
        //         //find the largest number used as a movie ID and add 1 to it
                
        //     }
        // }
    }
}