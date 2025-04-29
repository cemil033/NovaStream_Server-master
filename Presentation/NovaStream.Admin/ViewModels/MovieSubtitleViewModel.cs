using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovaStream.Admin.ViewModels;

public class MovieSubtitleViewModel : ViewModelBase
{
    private readonly AppDbContext _dbContext;

    private int _movieSubtitleCount;
    public int MovieSubtitleCount
    {
        get => _movieSubtitleCount;
        set { _movieSubtitleCount = value; RaisePropertyChanged(); }
    }

    private ObservableCollection<Subtitle> _movieSubtitles;
    public ObservableCollection<Subtitle> MovieSubtitles
    {
        get => _movieSubtitles;
        set { _movieSubtitles = value; RaisePropertyChanged(); }
    }

    public Movie Movie { get; set; }


    public RelayCommand<Subtitle> DeleteCommand { get; set; }
    public RelayCommand RefreshCommand { get; set; }

    public RelayCommand OpenAddDialogHostCommand { get; set; }


    public MovieSubtitleViewModel(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        MovieSubtitles = new ObservableCollection<Subtitle>(_dbContext.Subtitles.Include(ma => ma.Movie).Where(e => e.Movie.Id != null));
        DeleteCommand = new RelayCommand<Subtitle>(movieSubtitle => Delete(movieSubtitle));
        RefreshCommand = new RelayCommand(() => Initialize());
        OpenAddDialogHostCommand = new RelayCommand(() => OpenAddDialogHost());
    }


    public async Task Initialize()
    {
        await Task.CompletedTask;

        if (!InternetService.CheckInternet()) { await MessageBoxService.Show("You are not connected to the Internet!", MessageBoxType.Error); return; }

        _ = MessageBoxService.Show($"Loading movie subtitles...", MessageBoxType.Progress);
        await Task.Delay(1000);

        try
        {
            MovieSubtitles = new ObservableCollection<Subtitle>(_dbContext.Subtitles.Include(ma => ma.Movie).Where(e => e.Movie.Id != null));
            MovieSubtitleCount = MovieSubtitles.Count;
           
            MovieSubtitles.CollectionChanged += MovieSubtitleCountChanged;

            MessageBoxService.Close();
        }
        catch
        {
            await MessageBoxService.Show("Server not responding please try again later!", MessageBoxType.Error);
        }
    }

    private async Task Delete(Subtitle movieSubtitle)
    {
        await Task.CompletedTask;

        if (!InternetService.CheckInternet()) { await MessageBoxService.Show("You are not connected to the Internet!", MessageBoxType.Error); return; }

        ArgumentNullException.ThrowIfNull(movieSubtitle);

        _ = MessageBoxService.Show($"Delete <{movieSubtitle.Language} language subtitle from {movieSubtitle.Movie.Name}>...", MessageBoxType.Progress);
        await Task.Delay(1000);

        try
        {
            _dbContext.Subtitles.Remove(movieSubtitle);
            await _dbContext.SaveChangesAsync();

            MovieSubtitles.Remove(movieSubtitle);

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

        var model = App.ServiceProvider.GetService<AddMovieSubtitleViewModel>();
        model.Movies = _dbContext.Movies.ToList();


        await DialogHost.Show(model, "RootDialog");
    }

    private void MovieSubtitleCountChanged(object? sender, NotifyCollectionChangedEventArgs e) => MovieSubtitleCount = MovieSubtitles.Count;
}