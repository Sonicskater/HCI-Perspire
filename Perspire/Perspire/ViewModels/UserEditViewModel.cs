using Perspire.DataStore;
using Perspire.Models;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Perspire.ViewModels
{
    class UserEditViewModel : BaseViewModel
    {
        private DataRepository data = DependencyService.Resolve<DataRepository>();
        public UserEditViewModel()
        {

        }

        public void Save()
        {
            data.WriteUserData(new UserData
            {
                make_sure_only_1_lol = 1,
            });
        }
    }
}
