using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDashboard.BL.Models;
using UserDashboard.DAL;
using UserDashboard.DAL.Entities;

namespace UserDashboard.BL.Services
{
    public class UserService
    {
        private readonly DBContext DbContext;

        public UserService(DBContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<UserListModel>> GetAllUsersAsync()
        {

            return await DbContext.Person.Select(
                s => new UserListModel
                {
                    Id = s.Id,
                    Name = s.Firstname + " " + s.Lastname,
                    City = s.City,
                    Country = s.Country,
                    Enrollmentdate = s.Enrollmentdate
                }
            ).ToListAsync();
        }

        public int GetCountUsers()
        {
            return (from s in DbContext.Person select s).Count();
        }

        public async Task<UserDetailModel> GetUserByIdAsync(int UserId)
        {
            return await DbContext.Person.Select(
                    s => new UserDetailModel
                    {
                        Id = s.Id,
                        Firstname = s.Firstname,
                        Lastname = s.Lastname,
                        Username = s.Username,
                        City = s.City,
                        Country = s.Country,
                        Postalcode = s.Postalcode,
                        Enrollmentdate = s.Enrollmentdate,
                        About = s.About
                    })
                .FirstOrDefaultAsync(s => s.Id == UserId);
        }

        public async Task InsertUserAsync(UserDetailModel User)
        {
            var entity = new Person()
            {
                Firstname = User.Firstname,
                Lastname = User.Lastname,
                Username = User.Username,
                City = User.City,
                Country = User.Country,
                Postalcode = User.Postalcode,
                Enrollmentdate = User.Enrollmentdate,
                About = User.About
            };

            DbContext.Person.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserDetailModel User)
        {
            var entity = await DbContext.Person.FirstOrDefaultAsync(s => s.Id == User.Id);

            entity.Firstname = User.Firstname;
            entity.Lastname = User.Lastname;
            entity.Username = User.Username;
            entity.City = User.City;
            entity.Country = User.Country;
            entity.Postalcode = User.Postalcode;
            entity.Enrollmentdate = User.Enrollmentdate;
            entity.About = User.About;

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int UserId)
        {
            var entity = new Person()
            {
                Id = UserId
            };
            DbContext.Person.Attach(entity);
            DbContext.Person.Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}