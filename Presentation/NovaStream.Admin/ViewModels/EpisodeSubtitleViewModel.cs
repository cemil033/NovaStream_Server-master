
namespace NovaStream.Admin.ViewModels;

public class EpisodeSubtitleViewModel : ViewModelBase
{
    private readonly AppDbContext _dbContext;

    private int _episodeSubtitleCount;
    public int EpisodeSubtitleCount
    {
        get => _episodeSubtitleCount;
        set { _episodeSubtitleCount = value; RaisePropertyChanged(); }
    }

    private ObservableCollection<Subtitle> _episodeSubtitles;
    public ObservableCollection<Subtitle> EpisodeSubtitles
    {
        get => _episodeSubtitles;
        set { _episodeSubtitles = value; RaisePropertyChanged(); }
    }

    public Episode Episode { get; set; }


    public RelayCommand<Subtitle> DeleteCommand { get; set; }
    public RelayCommand RefreshCommand { get; set; }

    public RelayCommand OpenAddDialogHostCommand { get; set; }


    public EpisodeSubtitleViewModel(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        EpisodeSubtitles = new ObservableCollection<Subtitle>(_dbContext.Subtitles.Include(ma => ma.Episode).Where(e => e.Episode.Id != null));
        DeleteCommand = new RelayCommand<Subtitle>(async episodeSubtitle =>await Delete(episodeSubtitle));
        RefreshCommand = new RelayCommand(async () =>await Initialize());
        OpenAddDialogHostCommand = new RelayCommand(async () =>await OpenAddDialogHost());
    }


    public async Task Initialize()
    {
        await Task.CompletedTask;

        if (!InternetService.CheckInternet()) { await MessageBoxService.Show("You are not connected to the Internet!", MessageBoxType.Error); return; }

        _ = MessageBoxService.Show($"Loading episode subtitles...", MessageBoxType.Progress);

        await Task.Delay(1000);

        try
        {
            EpisodeSubtitles = new ObservableCollection<Subtitle>(_dbContext.Subtitles.Include(ma => ma.Episode).Where(e=>e.Episode.Id!=null));
            EpisodeSubtitleCount = EpisodeSubtitles.Count;

            EpisodeSubtitles.CollectionChanged += EpisodeSubtitleCountChanged;

            MessageBoxService.Close();
        }
        catch
        {
            await MessageBoxService.Show("Server not responding please try again later!", MessageBoxType.Error);
        }
    }

    private async Task Delete(Subtitle episodeSubtitle)
    {
        await Task.CompletedTask;

        if (!InternetService.CheckInternet()) { await MessageBoxService.Show("You are not connected to the Internet!", MessageBoxType.Error); return; }

        ArgumentNullException.ThrowIfNull(episodeSubtitle);

        _ = MessageBoxService.Show($"Delete <{episodeSubtitle.Language} language subtitle from {episodeSubtitle.Episode.Name}>...", MessageBoxType.Progress);

        await Task.Delay(1000);

        try
        {
            _dbContext.Subtitles.Remove(episodeSubtitle);
            await _dbContext.SaveChangesAsync();

            EpisodeSubtitles.Remove(episodeSubtitle);

            MessageBoxService.Close();
        }
        catch
        {
            await MessageBoxService.Show("Server not responding please try again later!", MessageBoxType.Error);
        }
    }

    private async Task OpenAddDialogHost()
    {
        if (!InternetService.CheckInternet()) { await MessageBoxService.Show("You are not connected to the Internet!", MessageBoxType.Error); return; }

        var model = App.ServiceProvider.GetService<AddEpisodeSubtitleViewModel>();
        model.Episodes=_dbContext.Episodes.ToList();
        

        await DialogHost.Show(model, "RootDialog");
    }

    private void EpisodeSubtitleCountChanged(object? sender, NotifyCollectionChangedEventArgs e) => EpisodeSubtitleCount = EpisodeSubtitles.Count;
}
