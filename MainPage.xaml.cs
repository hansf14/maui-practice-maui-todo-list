using maui_todo_list.ViewModel;

namespace maui_todo_list
{
  public partial class MainPage : ContentPage
  {
    public MainPage(MainViewModel vm)
    {
      InitializeComponent();
      BindingContext = vm;
    }
  }
}
