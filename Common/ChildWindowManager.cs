using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.ViewModel;

namespace WPF.Common
{
    public class ChildWindowManager : BaseViewModel
    {
        public ChildWindowManager()
        {
            WindowVisibility = Visibility.Collapsed;
            XmlContent = null;
        }

        private static ChildWindowManager instance;
        public static ChildWindowManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChildWindowManager();
                }
                return instance;
            }

        }

        private Visibility windowVisibility;

        public Visibility WindowVisibility
        {
            get { return windowVisibility; }
            set
            {
                windowVisibility = value;
                NotifyPropertyChanged("WindowVisibility");
            }
        }


        private FrameworkElement xmlContent;

        public FrameworkElement XmlContent
        {
            get { return xmlContent; }
            set
            {
                xmlContent = value;
                NotifyPropertyChanged("XmlContent");
            }
        }

        public void ShowChildWindow(FrameworkElement content)
        {
            XmlContent = content;
            NotifyPropertyChanged("XmlContent");
            WindowVisibility = Visibility.Visible;
            NotifyPropertyChanged("WindowVisibility");
        }

        public void CloseChildWindow()
        {
            WindowVisibility = Visibility.Collapsed;
            NotifyPropertyChanged("WindowVisibility");
            XmlContent = null;
            NotifyPropertyChanged("XmlContent");
        }

    }
}
