using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel;


public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService monkeyService;  // Get access to using MonkeyFinder.Services service
    
    public ObservableCollection<Monkey> Monkeys { get; } = new();

    //public Command GetMonkeysCommand { get; } // MAUI internal implementation command

    public MonkeysViewModel(MonkeyService monkeyService)  // Injecting the service to the View Model
    {
        Title = "Monkey Finder";
        this.monkeyService = monkeyService;
    }

    // Method to call the service above
    
    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys();  // Get the data
            if (Monkeys.Count != 0)
                Monkeys.Clear();

            foreach (var monkey in monkeys)
                Monkeys.Add(monkey);  // Add to the collection, to the Observable

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Error!",
                $"Unable to get data: {ex.Message}", "OK");  // 
        }
        finally
        {
            IsBusy = false;
        }
    }

}
