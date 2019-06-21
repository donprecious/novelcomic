using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Webnovel.Models;

namespace Webnovel.Entities
{
    public class Chapter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string Content { get; set; }

        public int NovelId { get; set; }
        [ForeignKey("NovelId")]
        public Novel Novel { get; set; }

       
        public int NovelSectionId { get; set; }
        [ForeignKey("NovelSectionId")]
        public NovelSection NovelSection{ get; set; }



    }
}
