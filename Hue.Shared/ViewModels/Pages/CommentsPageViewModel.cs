using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Hue.DataModels;
using Hue.Services;
using MASACore.Core.LifeCycle;
using MASACore.Core.ViewModels;
using MASACore.Core.ViewModels.Commands;

#if WINDOWS_APP
using Hue.Views.Pages;
#endif

namespace Hue.ViewModels.Pages
{
    public class CommentsPageViewModel : BasePageViewModel
    {
        #region Fields

        private readonly IHackerNewsService _hackerNewsService;
        private ObservableCollection<CommentModel> _comments = new ObservableCollection<CommentModel>();
        private StoryViewModel _story = null;

        #endregion

        #region Properties
        
        public AwaitableDelegateCommand RefreshCommentsCommand { get; set; }
        public RelayCommand<StoryViewModel> NavigateToStoryCommand { get; set; }

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
        public ObservableCollection<CommentModel> Comments
        {
            get
            {
                return _comments;
            }

            set
            {
                if (_comments == value)
                {
                    return;
                }

                _comments = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public CommentsPageViewModel(IHackerNewsService hackerNewsService)
        {
            _hackerNewsService = hackerNewsService;

            RefreshCommentsCommand = new AwaitableDelegateCommand(ExecuteRefreshCommentsAsync, CanExecuteRefreshComments);
            NavigateToStoryCommand = new RelayCommand<StoryViewModel>(ExecuteNavigateToStory);
        }

        private bool CanExecuteRefreshComments()
        {
            return !IsLoading;
        }

        #region Command Methods

        private async Task ExecuteRefreshCommentsAsync()
        {
            await ExecuteWithProgressDialogAsync(async token =>
            {
                var comments = await _hackerNewsService.GetCommentsAsync(Story.StoryModel);
                var orderedComments = comments.Where(comment => !comment.Deleted);

                token.ThrowIfCancellationRequested();
                Comments = new ObservableCollection<CommentModel>(orderedComments);
            });
        }

        private void ExecuteNavigateToStory(StoryViewModel storyModel)
        {
            ViewNavigationService.Navigate(typeof(StoryPageViewModel), storyModel);
        }

        #endregion

        #region Navigation Methods

        protected override async void LoadState(LoadStateEventArgs e)
        {
            if (e.NavigationParameter != null && e.NavigationParameter as StoryViewModel != null)
            {
                Story = e.NavigationParameter as StoryViewModel;

                await RefreshCommentsCommand.ExecuteAsync(null);
            }
            else
            {
                ViewNavigationService.GoBack();
            }
        }

        protected override void SaveState(SaveStateEventArgs e)
        {
            Story = null;
            Comments = null;
        }

        #endregion
    }
}
