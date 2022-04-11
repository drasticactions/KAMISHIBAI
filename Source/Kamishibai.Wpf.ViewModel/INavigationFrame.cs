﻿namespace Kamishibai.Wpf.ViewModel;

public interface INavigationFrame
{
    public const string DefaultFrameName = "";
    public string FrameName { get; }
    public Task<bool> NavigateAsync<TViewModel>(IServiceProvider serviceProvider) where TViewModel : class;
    public Task<bool> NavigateAsync<TViewModel>(TViewModel viewModel, IServiceProvider serviceProvider) where TViewModel : class;
    public Task<bool> NavigateAsync<TViewModel>(Action<TViewModel> init, IServiceProvider serviceProvider) where TViewModel : class;
    public Task<bool> GoBackAsync();

}