using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Labbet.ViewModel
{
    public partial class BasViewModel : ObservableObject
    {
        public BasViewModel() 
        {

        }
        [ObservableProperty] 
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;
        public bool IsNotBusy => !IsBusy;
    }
}
