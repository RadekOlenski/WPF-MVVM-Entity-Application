/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WPF"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WPF.Common;

namespace WPF.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HumanResourcesViewModel>();
            SimpleIoc.Default.Register<AddEmployeeDepartmentHistoryViewModel>();
            SimpleIoc.Default.Register<ChildWindowManager>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public HumanResourcesViewModel HumanResources
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HumanResourcesViewModel>();
            }
        }

        public AddEmployeeDepartmentHistoryViewModel AddEmployeeDepartmentHistory
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddEmployeeDepartmentHistoryViewModel>();
            }
        }

        public ChildWindowManager ChildWindowManager
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ChildWindowManager>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}