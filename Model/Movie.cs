using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Asm02_KhanhHCE150703.Model
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
    
        public string MovieID { get; set; }
  
        public string MovieName { get; set; }
        
        public int Year { get; set; }

        public int RunningTime { get; set; }
 
        public int Rating { get; set; }
   
        public string MovieGenreID { get; set; }
    }
}
