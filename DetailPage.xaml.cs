using maui_todo_list.ViewModel;

namespace maui_todo_list
{
  public partial class DetailPage : ContentPage
  {
    public DetailPage(DetailViewModel vm)
    {
      InitializeComponent();
      BindingContext = vm;
    }
  }
}
