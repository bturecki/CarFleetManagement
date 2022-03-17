using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models.Abstract
{
    public interface ICar
    {
        string Make { get; }
        string Model { get; }
        int YearOfProduction { get; }
        int Milage { get; }
        int Id { get; }
    }
}
