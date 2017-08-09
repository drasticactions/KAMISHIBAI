﻿using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kamishibai.Xamarin.Forms.Mvvm
{
    public class InsertPageBefore<TPage, TBefore> : NavigationBehavior<TPage> 
        where TPage : Page
        where TBefore : Page
    {
        public override Task Navigate<TParam>(TParam parameter = default(TParam))
        {
            var beforePage = CurrentPage.Navigation.NavigationStack.FirstOrDefault(x => x.GetType() == typeof(TBefore));
            Navigator.InsertPageBefore(ServiceLocator.GetInstance<TPage>(), beforePage, parameter);
            return Task.FromResult(true);
        }
    }
}
