using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace F0.Talks.SourceGenerators.Demo.WpfApp;

[INotifyPropertyChanged]
internal sealed partial class MainViewModel
{
    [ObservableProperty]
    private int number = 0;


    [ICommand]
    void Increment()
    {
        Number++;
    }

    [ICommand]
    void Decrement()
    {
        Number--;
    }
}
