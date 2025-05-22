using System.Text;
using System.Text.Json;
using MyNotes.App.Models;

namespace MyNotes.App.Services;

public class NoteService {
    private HttpClient _client = new() {
        BaseAddress = new Uri("http://192.168.0.10:5000/api/")
    };

    public async Task<List<Note>> GetNotesAsync() {
        var response = await _client.GetStringAsync("notes");
        return JsonSerializer.Deserialize<List<Note>>(response,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task CreateNoteAsync(Note note) {
        var json = JsonSerializer.Serialize(note);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        await _client.PostAsync("notes", content);
    }

    public async Task UpdateNoteAsync(Note note) {
        var json = JsonSerializer.Serialize(note);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        await _client.PutAsync($"notes/{note.Id}", content);
    }

    public async Task DeleteNoteAsync(int id) {
        await _client.DeleteAsync($"notes/{id}");
    }
}
