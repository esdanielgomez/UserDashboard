using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using UserDashboard.BL.Models;
using UserDashboard.BL.Services;

namespace UserDashboard.ViewModels.Operations
{
    public class CreateViewModel : UserDashboard.ViewModels.MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

        private readonly UserService UserService;

        public UserDetailModel User { get; set; } = new UserDetailModel { Enrollmentdate = DateTime.UtcNow.Date };

        public CreateViewModel(UserService UserService)
		{
			Title = "Create user";
			Subtitle = "In this section you can create a new user.";

            this.UserService = UserService;
        }

        public async Task AddUser()
        {
            await UserService.InsertUserAsync(User);
            Context.RedirectToRoute("Default");
        }
    }
}

