using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Favorite
    {
        public int Id { get; set; }

        //Foreign Keys
        public int MovieId { get; set; }
        public int UserId { get; set; }

        //Navigation Property
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
