// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Windows.UI.Xaml.Controls;
using Hue.ViewModels.Pages;
using MASACore.Core.LifeCycle;
using MASACore.Core.Views;

namespace Hue.Views.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StoryPage : BaseViewModelPage
    {
        public StoryPage()
        {
            this.InitializeComponent();
        }

        protected override void LoadState(LoadStateEventArgs e)
        {
            
        }

        protected override void SaveState(SaveStateEventArgs e)
        {

        }
    }
}
