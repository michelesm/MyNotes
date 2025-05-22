using MyNotes.App.Views;

namespace MyNotes.App;

public partial class App : Application {
    public App() {
        InitializeComponent();
        MainPage = new NavigationPage(new NotesPage());
    }
}
