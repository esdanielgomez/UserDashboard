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
    public class EditViewModel : UserDashboard.ViewModels.MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }
		private readonly UserService UserService;
		public UserDetailModel User { get; set; }

		public EditViewModel(UserService UserService)
		{
			Title = "Edit user";
			Subtitle = "In this section you can edit a user determined by their ID";

			this.UserService = UserService;
		}

		public override async Task PreRender()
		{
			int id = Convert.ToInt32(Context.Parameters["Id"]);
			User = await UserService.GetUserByIdAsync(id);

			await base.PreRender();
		}

		public async Task EditUser()
		{
			await UserService.UpdateUserAsync(User);
			Context.RedirectToRoute("Detail", new { id = User.Id });
		}
	}
}

