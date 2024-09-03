using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace maui_todo_list.ViewModel
{
  public partial class MainViewModel : ObservableObject
  {
    IConnectivity connectivity;

    public MainViewModel(IConnectivity connectivity)
    {
      //items = new ObservableCollection<string>();
      items = [];
      text = string.Empty;
      this.connectivity = connectivity;
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;

    [RelayCommand]
    async Task Add()
    {
      if (string.IsNullOrWhiteSpace(Text))
      {
        return;
      }

      if (connectivity.NetworkAccess != NetworkAccess.Internet)
      {
        await Shell.Current.DisplayAlert("Uh Oh!", "No Internet", "OK");
        return;
      }

      // Add our item
      Items.Add(Text);

      Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
      // 'Items'은(는) 여기에서 null이 아닙니다.
      // CA1868:'Collection.Contains(string)'(으)로 'Collection.Remove(string)'을(를) 보호하지 마세요.
      //if (Items.Contains(s))
      //{
      //  Items.Remove(s);
      //}

      Items.Remove(s);
    }

    [RelayCommand]
    async Task Tap(string s)
    {
      //await Shell.Current.GoToAsync(nameof(DetailPage));

      await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");

      //await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}",
      //  new Dictionary<string, object>
      //  {
      //    { nameof(DetailPage), new object()}
      //  }
      // );
    }
  }
}
