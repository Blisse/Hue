using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Hue.Services;
using Hue.ViewModels.Pages;
using MASACore.Core.ViewModels;

namespace Hue.Views.Resources
{
    public class HueViewModelLocator : BaseViewModelLocator
    {
        public HueViewModelLocator()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
            }
            else
            {
                
            }

            SimpleIoc.Default.Register<NewsPageViewModel>();
            SimpleIoc.Default.Register<CommentsPageViewModel>();
            SimpleIoc.Default.Register<StoryPageViewModel>();

            SimpleIoc.Default.Register<IHackerNewsService, HackerNewsService>();
        }

        public NewsPageViewModel NewsPage
        {
            get { return SimpleIoc.Default.GetInstance<NewsPageViewModel>(); }
        }

        public CommentsPageViewModel CommentsPage
        {
            get { return SimpleIoc.Default.GetInstance<CommentsPageViewModel>(); }
        }

        public StoryPageViewModel StoryPage
        {
            get { return SimpleIoc.Default.GetInstance<StoryPageViewModel>(); }
        }
    }
}
