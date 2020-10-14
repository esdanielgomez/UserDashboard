using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;

namespace UserDashboard.ViewModels
{
    public class AboutViewModel : MasterPageViewModel
    {
		public string Title { get; set; }
		public string Subtitle { get; set; }


		public AboutViewModel()
		{
			Title = "About";
			Subtitle = "In this section you can edit a user determined by their ID";
		}
	}
}

