using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using UserDashboard.BL.Services;
using UserDashboard.BL.Models;

namespace UserDashboard.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
		public string Title { get; set;}
		public string Subtitle { get; set;}

		private readonly UserService UserService;

		[Bind(Direction.ServerToClient)]
		public List<UserListModel> Users { get; set; }

		public int ContUsers { get; set; }

		public DefaultViewModel(UserService UserService)
		{
			Title = "User dashboard";
			Subtitle = "In this section you can see the list of users registered in the database.";

			this.UserService = UserService;
		}

		public override async Task PreRender()
		{
			Users = await UserService.GetAllUsersAsync();
			ContUsers = UserService.GetCountUsers();

			await base.PreRender();
		}


	}
}
