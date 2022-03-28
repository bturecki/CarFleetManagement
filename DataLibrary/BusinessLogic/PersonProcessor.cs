using DataLibrary.DataAccess;
using DataLibrary.Models.Abstract;
using DataLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class PersonProcessor
    {
        public static int CreatePerson(string name, string surname, DateTime dateOfBirth, string email, bool isAdmin)
        {
            User data = new User() { Name = name, Surname = surname, DateOfBirth = dateOfBirth, Email = email, IsAdmin = isAdmin };

            string sql = @"insert into dbo.T_User (Name, Surname, DateOfBirth, Email, IsAdmin) values (@Name, @Surname, @DateOfBirth, @Email, @IsAdmin);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<IUser> LoadPeople()
        {
            var returnList = new List<IUser>();
            string sql = "select UserId, Name, Surname, DateOfBirth, Email, IsAdmin from dbo.T_User;";
            foreach (var us in SqlDataAccess.LoadData<User>(sql))
                returnList.Add(us);
            return returnList;
        }

        public static int DeletePerson(int id)
        {
            string sql = $"delete dbo.T_User where UserId = {id};";

            return SqlDataAccess.DeleteData(sql);
        }
    }
}
