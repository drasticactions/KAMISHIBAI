﻿using Kamishibai.Wpf.Demo.App;
using Kamishibai.Wpf.Demo.View;
using Kamishibai.Wpf.Demo.ViewModel;
using Kamishibai.Wpf.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = KamishibaiApplication<App, MainWindow>.CreateBuilder();
builder.Services.AddTransient<MainWindowViewModel>();

builder.Services.AddPresentation<ContentPage, ContentPageViewModel>(true);

builder.Services.AddPresentation<SafeContentPage, SafeContentPageViewModel>();
builder.Services.AddTransient<ISafeContentPageViewModelProvider, SafeContentPageViewModelProvider>();

var app = builder.Build();
app.RunAsync();
