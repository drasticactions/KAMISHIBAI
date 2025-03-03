﻿namespace Kamishibai;

public interface IWindowService
{
    Task OpenWindowAsync(Type viewModelType, object? owner, OpenWindowOptions options);
    Task OpenWindowAsync<TViewModel>(object? owner, OpenWindowOptions options);
    Task OpenWindowAsync<TViewModel>(TViewModel viewModel, object? owner, OpenWindowOptions options) where TViewModel : notnull;
    Task OpenWindowAsync<TViewModel>(Action<TViewModel> init, object? owner, OpenWindowOptions options);
    Task<bool> OpenDialogAsync(Type viewModelType, object? owner, OpenDialogOptions options);
    Task<bool> OpenDialogAsync<TViewModel>(object? owner, OpenDialogOptions options);
    Task<bool> OpenDialogAsync<TViewModel>(TViewModel viewModel, object? owner, OpenDialogOptions options) where TViewModel : notnull;
    Task<bool> OpenDialogAsync<TViewModel>(Action<TViewModel> init, object? owner, OpenDialogOptions options);
    public Task CloseWindowAsync(object? window);
    public Task CloseDialogAsync(bool dialogResult, object? window);
    public MessageBoxResult ShowMessage(string messageBoxText, string caption, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult, MessageBoxOptions options, object? owner);
    DialogResult OpenFile(OpenFileDialogContext context);
    DialogResult SaveFile(SaveFileDialogContext context);
}