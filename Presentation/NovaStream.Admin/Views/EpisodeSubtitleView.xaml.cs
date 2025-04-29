using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NovaStream.Admin.Views;

public partial class EpisodeSubtitleView : UserControl
{
    public EpisodeSubtitleView()
    {
        InitializeComponent();

        DataContext = App.ServiceProvider.GetService<EpisodeSubtitleViewModel>();
    }



    private void MovieSubtitleView_ButtonClicked(object sender, RoutedEventArgs e)
    {
        App.ServiceProvider.GetService<MainViewModel>().MovieSubtitleViewCommand.Execute(null);
    }

   
}
