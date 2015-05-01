using System;
using GalaSoft.MvvmLight.Command;
using Hue.Services;
using MASACore.Core.LifeCycle;
using MASACore.Core.ViewModels;

#if WINDOWS_APP
using Hue.Views.Pages;
#endif

namespace Hue.ViewModels.Pages
{
    public class StoryPageViewModel : BasePageViewModel
    {
        #region Fields

        private readonly IHackerNewsService _hackerNewsService;
        private StoryViewModel _story = null;

        #endregion

        #region Properties

        public StoryViewModel Story
        {
            get
            {
                return _story;
            }

            set
            {
                if (_story == value)
                {
                    return;
                }

                _story = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand<StoryViewModel> NavigateToCommentsCommand { get; set; } 

        #endregion

        public StoryPageViewModel(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;

            NavigateToCommentsCommand = new RelayCommand<StoryViewModel>(ExecuteNavigateToCommentsCommand);
        }

        private void ExecuteNavigateToCommentsCommand(StoryViewModel storyViewModel)
        {
            ViewNavigationService.Navigate(typeof(CommentsPageViewModel), storyViewModel);
        }

        #region Command Methods



        #endregion

        #region Navigation Methods

        protected override void LoadState(LoadStateEventArgs e)
        {
            if (e.NavigationParameter != null && e.NavigationParameter as StoryViewModel != null)
            {
                Story = e.NavigationParameter as StoryViewModel;
            }
            else
            {
                ViewNavigationService.GoBack();
            }
        }

        protected override void SaveState(SaveStateEventArgs e)
        {
            Story = null;
        }


        #endregion

    }
}
