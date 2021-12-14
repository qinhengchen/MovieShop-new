using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        
        // fk
        public int UserID { get; set; }


        public Guid PuchaseNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDateTime { get; set; }

        //fk
        public int Movield { get; set; }

        //Navigation Property
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
