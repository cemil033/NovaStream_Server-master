namespace NovaStream.Admin.ViewModelContents.Concrete;

public class EpisodeSubtitleViewModelContent : ViewModelContentBase
{
    public int Id { get; set; }
    public int EpisodeId { get; set; }

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
    

    private Episode _episode;
    public Episode Episode
    {
        get => _episode;
        set
        {
            _episode = value;

            ClearErrors(nameof(Episode));

            if (_episode is null) AddError(nameof(Episode), $"{nameof(Episode)} cannot be empty!");
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
        Episode = Episode;
        EpisodeId = EpisodeId;
        SubtitlePath = SubtitlePath;
        Language = Language;        
    }
}

