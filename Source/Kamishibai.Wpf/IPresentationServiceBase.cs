﻿namespace Kamishibai.Wpf;

public interface IPresentationServiceBase
{
    public Task<bool> NavigateAsync(Type viewModelType, string frameName = "");
    public Task<bool> NavigateAsync<TViewModel>(string frameName = "") where TViewModel : class;
    public Task<bool> NavigateAsync<TViewModel>(TViewModel viewModel, string frameName = "") where TViewModel : class;
    public Task<bool> NavigateAsync<TViewModel>(Action<TViewModel> init, string frameName = "") where TViewModel : class;
    Task<bool> GoBackAsync(string frameName = "");
    public bool CanGoBack(string frameName = "");
    INavigationFrame GetNavigationFrame(string frameName = "");

    public Task OpenWindowAsync(Type viewModelType, OpenWindowOptions? options = null);
    public Task OpenWindowAsync<TViewModel>(TViewModel viewModel, OpenWindowOptions? options = null) where TViewModel : notnull;
    public Task OpenWindowAsync<TViewModel>(Action<TViewModel> init, OpenWindowOptions? options = null);
    public Task OpenDialogAsync(Type viewModelType, OpenWindowOptions? options = null);
    public Task OpenDialogAsync<TViewModel>(TViewModel viewModel, OpenWindowOptions? options = null) where TViewModel : notnull;
    public Task OpenDialogAsync<TViewModel>(Action<TViewModel> init, OpenWindowOptions? options = null);
}