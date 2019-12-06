using System.ComponentModel.DataAnnotations.Schema;
using Webnovel.Models;

namespace Webnovel.Entities
{
    public class NovelRating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public int NovelId
        {
            get;
            set;
        }

        public int RatingTypeId { get; set; }

        [ForeignKey("RatingTypeId")]
        public RatingType RatingType { get; set; }
        public string UserId
        {
            get;
            set;
        }

        public double Value
        {
            get;
            set;
        }

        public string Description { get; set; }

        [ForeignKey("NovelId")]
        public Novel Novel
        {
            get;
            set;
        }

        [ForeignKey("UserId")]
        public ApplicationUser User
        {
            get;
            set;
        }
    }
    public class RatingType
    {

        //THE PURPOSE OF THIS IS TO CREATE DIFFERENT SECTION OF RATING SUCH AS
        //Simplicty
        //Readably
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
