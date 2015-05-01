// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

using System;
using Hue.ViewModels.Pages;
using MASACore.Core.LifeCycle;
using MASACore.Core.ViewModels;
using MASACore.Core.Views;

namespace Hue.Views.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewsPage : BaseViewModelPage
    {
        public NewsPage()
        {
            this.InitializeComponent();
            
            var vmtov = new[]
            {
                new { vm = typeof(CommentsPageViewModel), v = typeof(CommentsPage) },
                new { vm = typeof(NewsPageViewModel), v = typeof(NewsPage) },
                new { vm = typeof(StoryPageViewModel), v = typeof(StoryPage) },
            };

            foreach (var vmv in vmtov)
            {
                if (!BasePageViewModel.PageDictionary.TryAdd(
                    vmv.vm,
                    vmv.v
                    ))
                {
                    throw new Exception("Failed to setup page navigation");
                }
            }
        }

        protected override void LoadState(LoadStateEventArgs e)
        {

        }

        protected override void SaveState(SaveStateEventArgs e)
        {

        }
    }
}
