using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models.Abstract
{
    public interface IUser
    {
        int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public DateTime DateOfBirth { get; }
        bool IsAdmin { get; }

    }
}
