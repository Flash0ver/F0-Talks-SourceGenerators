using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace F0.Talks.SourceGenerators.Demo.WpfApp;

[INotifyPropertyChanged]
internal sealed partial class MainViewModel
{
    [ObservableProperty]
    private int number = 0;


    [RelayCommand]
    void Increment()
    {
        Number++;
    }

    [RelayCommand]
    void Decrement()
    {
        Number--;
    }
}
