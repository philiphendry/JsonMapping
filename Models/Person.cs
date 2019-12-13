using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JsonMapping.Models
{
    public class Person
    {
        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Range(0, 150)]
        public int Age { get; set; }

        private const Colours DefaultFavouriteColour = Colours.Blue;

        [DefaultValue(DefaultFavouriteColour)] 
        public Colours FavouriteColour { get; set; } = DefaultFavouriteColour;

        public Person Child { get; set; }

        public List<Person> Children { get; set; }

        public ISport FavouriteSport { get; set; }

        [AllowHtml]
        public string Description { get; set; }
    }

    public interface ISport
    {
        string Name { get; }
    }

    public class Squash : ISport
    {
        public string Name => "Squash";
        public string CourtName { get; set; }
    }

    public class Football : ISport
    {
        public string Name => "Football";
        public string PitchName { get; set; }
    }

    public enum Colours
    {
        Red,
        Green, 
        Blue
    }
}