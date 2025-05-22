using MyNotes.App.Models;
using MyNotes.App.Services;

namespace MyNotes.App.Views;

public partial class NotesPage : ContentPage {
    private NoteService _service = new();
    public NotesPage() {
        InitializeComponent();
        LoadNotes();
    }

    async void LoadNotes() {
        NotesList.ItemsSource = await _service.GetNotesAsync();
    }
}
