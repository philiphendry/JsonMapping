using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace JsonMapping.Models
{
    public class Person : IValidatableObject
    {
        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public Address Address { get; set; }

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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new ValidationResult[]
            {
                new ValidationResult("There is an error", new string[] {"FavouriteSport"})
            };
        }
    }
}