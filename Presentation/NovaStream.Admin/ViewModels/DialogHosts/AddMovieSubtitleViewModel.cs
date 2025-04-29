using NovaStream.Application.Services;
using NovaStream.Domain.Entities.Concrete;
using NovaStream.Infrastructure.Services;

namespace NovaStream.Admin.ViewModels.DialogHosts;

public class AddMovieSubtitleViewModel : DependencyObject
{
    private readonly AppDbContext _dbContext;
    private readonly IStorageManager _storageManager;
    private readonly IAWSStorageManager _awsStorageManager;
    public List<Movie> Movies { get; set; }
    public Movie Movie { get; set; }
    public Subtitle Subtitle { get; set; }

    public bool ProcessStarted
    {
        get { return (bool)GetValue(ProcessStartedProperty); }
        set { SetValue(ProcessStartedProperty, value); }
    }
    public static readonly DependencyProperty ProcessStartedProperty =
        DependencyProperty.Register("ProcessStarted", typeof(bool), typeof(AddMovieSubtitleViewModel));

    public List<Task> UploadTasks { get; set; }
    public List<CancellationTokenSource> UploadTaskTokens { get; set; }
    public RelayCommand SaveCommand { get; set; }

    public RelayCommand OpenFileDialogCommand { get; set; }


    public AddMovieSubtitleViewModel(AppDbContext dbContext, IStorageManager storageManager, IAWSStorageManager awsStorageManager)
    {
        _dbContext = dbContext;
        _storageManager = storageManager;
        _awsStorageManager = awsStorageManager;

        Subtitle = new Subtitle();
        SaveCommand = new RelayCommand(() => Save());
        UploadTasks = new();
        UploadTaskTokens = new();

        OpenFileDialogCommand = new RelayCommand(() => Subtitle.SubtitlePath = FileDialogService.OpenFile(Subtitle.SubtitlePath));
    }


    private async Task Save()
    {
        await Task.CompletedTask;

        if (!InternetService.CheckInternet()) { await MessageBoxService.Show("You are not connected to the Internet!", MessageBoxType.Error); return; }

        try
        {
            ProcessStarted = true;

            if (Subtitle.SubtitlePath is not null)
            {
                var fileStream = new FileStream(Subtitle.SubtitlePath, FileMode.Open, FileAccess.Read);
                var filename = string.Format("{0}-subtitle-{1}{2}", Path.GetFileNameWithoutExtension(Subtitle.SubtitlePath).ToLower().Replace(' ', '-'), Random.Shared.Next(), Path.GetExtension(Subtitle.SubtitlePath));
                Subtitle.SubtitlePath = string.Format("Subtitle/{0}/{1}", Movie.Name, filename);
                
                var fileToken = new CancellationTokenSource();
                var fileUploadTask = _awsStorageManager.UploadFileAsync(fileStream, Subtitle.SubtitlePath, FileProgressEvent, fileToken.Token);
                
            }
            var movieSubtitle = new Subtitle()
            {
                Movie = this.Movie,
                MovieId = Movie.Id,
                Language = Subtitle.Language,
                SubtitlePath = Subtitle.SubtitlePath
            };

            _dbContext.Subtitles.Add(movieSubtitle);
            _dbContext.SaveChanges();

            App.ServiceProvider.GetService<MovieSubtitleViewModel>()?.MovieSubtitles.Add(movieSubtitle);

            ProcessStarted = false;

            DialogHost.Close("RootDialog");

            await MessageBoxService.Show("Movie Subtitle saved succesfully!", MessageBoxType.Success);
        }
        catch
        {
            if (!InternetService.CheckInternet())
                await MessageBoxService.Show("You are not connected to the Internet!", MessageBoxType.Error);

            else
                await MessageBoxService.Show("Server not responding please try again later!", MessageBoxType.Error);

            ProcessStarted = false;
        }
    }

    private int _fileProgress;
    public int FileProgress
    {
        get => _fileProgress;
        set { _fileProgress = value; }
    }
    public void FileProgressEvent(object sender, UploadProgressArgs e)
    {
        var progress = (int)(e.TransferredBytes * 100 / e.TotalBytes);

        System.Windows.Application.Current.Dispatcher.Invoke(() =>
        {
            FileProgress = progress;
        });
    }
}
