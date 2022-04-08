﻿using System.Diagnostics;
using System.Runtime.CompilerServices;
using Kamishibai.Wpf.ViewModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace Kamishibai.Wpf.Demo.ViewModel;

public class ContentPageViewModel :
    IPausingAsyncAware,
    IPausingAware,
    IPausedAsyncAware,
    IPausedAware,
    INavigatingAsyncAware,
    INavigatingAware,
    INavigatedAsyncAware,
    INavigatedAware,
    IResumingAsyncAware,
    IResumingAware,
    IResumedAsyncAware,
    IResumedAware,
    IDisposingAsyncAware,
    IDisposingAware,
    IDisposedAsyncAware,
    IDisposable
{
    private readonly INavigationService _navigationService;

    public ContentPageViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        NavigateNextCommand = new AsyncRelayCommand(OnNavigateNext);
        GoBackCommand = new AsyncRelayCommand(OnGoBack);
    }

    public string FrameName { get; set; } = string.Empty;
    public int Count { get; set; }
    public bool CanNavigateAsync { get; set; } = true;
    public bool CanNavigate { get; set; } = true;
    public bool CanGoBackAsync { get; set; } = true;
    public bool CanGoBack { get; set; } = true;

    public AsyncRelayCommand NavigateNextCommand { get; }
    public AsyncRelayCommand GoBackCommand { get; }

    private Task OnNavigateNext()
    {
        return _navigationService.GetFrame(FrameName).NavigateAsync<ContentPageViewModel>(x =>
        {
            x.FrameName = FrameName;
            x.Count = Count + 1;
        });
    }

    private Task OnGoBack()
    {
        return _navigationService.GetFrame(FrameName).GoBackAsync();
    }

    public async Task<bool> OnPausingAsync()
    {
        await WriteLogAsync();
        return CanNavigateAsync;
    }

    public bool OnPausing()
    {
        WriteLog();
        return CanNavigate;
    }

    public Task OnPausedAsync() => WriteLogAsync();
    public void OnPaused() => WriteLog();
    public Task OnNavigatingAsync() => WriteLogAsync();
    public void OnNavigating() => WriteLog();
    public Task OnNavigatedAsync() => WriteLogAsync();
    public void OnNavigated() => WriteLog();
    public Task OnResumingAsync() => WriteLogAsync();
    public void OnResuming() => WriteLog();
    public Task OnResumedAsync() => WriteLogAsync();
    public void OnResumed() => WriteLog();
    public async Task<bool> OnDisposingAsync()
    {
        await WriteLogAsync();
        return CanGoBackAsync;
    }

    public bool OnDisposing()
    {
        WriteLog();
        return CanGoBack;
    }

    public Task OnDisposedAsync() => WriteLogAsync();
    public void Dispose() => WriteLog();

    private Task WriteLogAsync([CallerMemberName] string member = "")
    {
        Debug.WriteLine($"{member} Frame:{FrameName} Count:{Count}");
        return Task.CompletedTask;
    }

    private void WriteLog([CallerMemberName] string member = "")
    {
        Debug.WriteLine($"{member} Frame:{FrameName} Count:{Count}");
    }
}

public class DesignContentPageViewModel : ContentPageViewModel
{
    public DesignContentPageViewModel() : base(INavigationService.DesignInstance)
    {
    }
}
