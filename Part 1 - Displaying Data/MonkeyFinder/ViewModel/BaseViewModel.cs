using System.Collections.Specialized;

namespace MonkeyFinder.ViewModel;


/* Changed event detector */
public partial class BaseViewModel : ObservableObject
{
    public BaseViewModel()
    {
        
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    string title;

    public bool IsNotBusy => !IsBusy;


    #region Working Codebase Reference
    //public bool IsBusy
    //{
    //    get => isBusy;
    //    set
    //    {
    //        if (isBusy == value)
    //            return;
    //        isBusy = value;
    //        OnPropertyChanged();
    //    }
    //}
    //public string Title
    //{
    //    get => title;
    //    set
    //    {
    //        if (title == value)
    //            return;
    //        title = value;
    //        OnPropertyChanged();
    //        OnPropertyChanged(nameof(IsNotBusy));
    //    }
    //}

    //public bool IsNotBusy => !isBusy;

    //public event PropertyChangedEventHandler PropertyChanged;
    //public void OnPropertyChanged([CallerMemberName]string name = null)
    //{
    //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    //}
    #endregion
}
