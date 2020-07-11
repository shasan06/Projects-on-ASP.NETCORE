using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        //the first prop contains the list of movies
        public List<Movie> Movies { get; set; }

        //A Selectlist containing the list of genres. This allows the user to select a genre from the list.
        public SelectList Genres { get; set; }

        //MovieGenre which contains the selected genre
        public string MovieGenre { get; set; }

        //SearchString which contains the text usrs enter in the search text box
        public string SearchString { get; set; }
    }
}
