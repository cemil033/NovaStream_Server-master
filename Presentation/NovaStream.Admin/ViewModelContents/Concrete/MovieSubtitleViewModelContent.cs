using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaStream.Admin.ViewModelContents.Concrete;

public class MovieSubtitleViewModelContent : ViewModelContentBase
{
    public int Id { get; set; }
    public int MovieId { get; set; }

    private string _language;
    public string Language
    {
        get => _language;
        set
        {
            _language = value;

            OnPropertyChanged();

            ClearErrors(nameof(Language));

            if (string.IsNullOrWhiteSpace(_language)) AddError(nameof(Language), $"{nameof(Language)} cannot be empty!");
        }
    }


    private Movie _movie;
    public Movie Movie
    {
        get => _movie;
        set
        {
            _movie = value;

            ClearErrors(nameof(Movie));

            if (_movie is null) AddError(nameof(Movie), $"{nameof(Movie)} cannot be empty!");
        }
    }

    private string _subtitlePath;
    public string SubtitlePath
    {
        get => _subtitlePath;
        set
        {
            _subtitlePath = value;

            OnPropertyChanged();

            ClearErrors(nameof(SubtitlePath));

            if (string.IsNullOrWhiteSpace(_subtitlePath)) { AddError(nameof(SubtitlePath), $"{nameof(SubtitlePath).Replace("Url", string.Empty)} path cannot be empty!"); return; }
            else if (_subtitlePath[1] != ':') return;
            else if (!File.Exists(_subtitlePath)) { AddError(nameof(SubtitlePath), "File with this path not exists!"); return; }
        }
    }


    private BlobStorageUploadProgress _fileProgress;
    public BlobStorageUploadProgress FileProgress
    {
        get => _fileProgress;
        set { _fileProgress = value; OnPropertyChanged(); }
    }


    public bool ImageUploadSuccess { get; set; }
    public override void Verify()
    {
        Movie = Movie;
        MovieId = MovieId;
        SubtitlePath = SubtitlePath;
        Language = Language;
    }
}
