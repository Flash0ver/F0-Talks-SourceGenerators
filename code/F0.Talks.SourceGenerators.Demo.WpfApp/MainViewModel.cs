using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics.CodeAnalysis;

namespace F0.Talks.SourceGenerators.Demo.WpfApp;

[INotifyPropertyChanged]
[SuppressMessage("CommunityToolkit.Mvvm.SourceGenerators.INotifyPropertyChangedGenerator", "MVVMTK0032:Inherit from ObservableObject instead of using [INotifyPropertyChanged]", Justification = "Demo")]
internal sealed partial class MainViewModel
{
    [ObservableProperty]
    public partial int Number { get; set; } = 0x_F0;

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
