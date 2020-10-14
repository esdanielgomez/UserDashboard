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
    public class DetailViewModel : UserDashboard.ViewModels.MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }

		private readonly UserService UserService;
		public UserDetailModel User { get; set; }
		public int IdSearch { get; set; }

		public DetailViewModel(UserService UserService)
		{
			Title = "Search user";
			Subtitle = "In this section you can find a user according to their ID.";

			this.UserService = UserService;
		}

		public override async Task PreRender()
		{
			IdSearch = Convert.ToInt32(Context.Parameters["Id"]);
			User = await UserService.GetUserByIdAsync(IdSearch);

            if (User!=null)
            {
				Context.ResourceManager.AddStartupScript("document.getElementById('Results').style.display = 'block'");
			}
			
			await base.PreRender();
			
		
		}

		public async Task DeleteUser()
		{
			await UserService.DeleteUserAsync(User.Id);
			Context.RedirectToRoutePermanent("Default", replaceInHistory: true);
		}
	}
}

