using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Webnovel.Entities;
using Webnovel.Models;

namespace Webnovel.DtoModels
{
    public class NovelCommentDto
    {
        public int Id
        {
            get;
            set;
        }

        public string UserId
        {
            get;
            set;
        }

     
        public UserDto User
        {
            get;
            set;
        }

        public string Comment
        {
            get;
            set;
        }

        //public int RateId { get; set; }

        //[ForeignKey("RateId")]
        //public NovelRating NovelRating { get; set; }
        public int NovelId
        {
            get;
            set;
        }

      
        public DateTime? DateTime { get; set; }

     
        public ICollection<NovelRating> Ratings { get; set; }
        public decimal RatingAverage { get; set; }
    }
}
