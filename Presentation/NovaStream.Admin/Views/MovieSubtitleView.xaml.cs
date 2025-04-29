namespace NovaStream.Admin.Views;


public partial class MovieSubtitleView : UserControl
{
    public MovieSubtitleView()
    {
        InitializeComponent();
        DataContext = App.ServiceProvider.GetService<MovieSubtitleViewModel>();
    }


    private void EpisodeSubtitleView_ButtonClicked(object sender, RoutedEventArgs e)
    {
        var model = App.ServiceProvider.GetService<EpisodeSubtitleViewModel>();

        model.Initialize();

        App.ServiceProvider.GetService<MainViewModel>().CurrentViewModel = model;
    }
}
