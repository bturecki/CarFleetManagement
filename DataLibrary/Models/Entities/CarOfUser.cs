using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models.Entities
{
    internal class CarOfUser : Abstract.ICarOfUser
    {
        public string Make{ get; internal set; }

        public string Model{ get; internal set; }

        public int YearOfProduction{ get; internal set; }

        public int Milage{ get; internal set; }

        public int CarId{ get; internal set; }
        public int UserId{ get; internal set; }

        public string Name{ get; internal set; }

        public string Surname{ get; internal set; }

        public string Email{ get; internal set; }

        public DateTime DateOfBirth{ get; internal set; }

        public bool IsAdmin{ get; internal set; }

        public int RowId { get; internal set; }
    }
}
