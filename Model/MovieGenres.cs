using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Asm02_KhanhHCE150703.Model
{
    public class MovieGenres
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MovieGenreID { get; set; }
        public string MovieGenreName { get; set; }
       

    }
}
