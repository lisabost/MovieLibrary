using System;
using System.Collections.Generic;

namespace MovieLibrary
{

    class Movie
    {
        // private string movieID;

        public List<string> genre { get; set; }

        //constructor for our movie object
        public Movie() { }

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

        //check to see if the movie title is unique
        public isTitleUnique 

    }
}