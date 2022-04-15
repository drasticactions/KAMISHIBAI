﻿using Kamishibai.Wpf.Extensions.Hosting;
using KamishibaiApp;
using KamishibaiApp.App;
using KamishibaiApp.App.Service;
using KamishibaiApp.Application;
using KamishibaiApp.Repository;
using KamishibaiApp.View;
using KamishibaiApp.View.Service;
using KamishibaiApp.ViewModel;
using MvvmApp.Views;

var builder = KamishibaiApplication<App, ShellWindow>.CreateBuilder();
builder.Services.AddTransient<ShellWindowViewModel>();
builder.Services.AddTransient<INavigationService, NavigationService>();

builder.Services.AddPresentation<MainPage, MainViewModel>();
builder.Services.AddPresentation<ListDetailsPage, ListDetailsViewModel>();
builder.Services.AddPresentation<ContentGridPage, ContentGridViewModel>();
builder.Services.AddPresentation<ContentGridDetailPage, ContentGridDetailViewModel>();
builder.Services.AddPresentation<DataGridPage, DataGridViewModel>();
builder.Services.AddPresentation<SettingsPage, SettingsViewModel>();

builder.Services.AddTransient<IApplicationInfoService, ApplicationInfoService>();
builder.Services.AddTransient<IBrowserService, BrowserService>();
builder.Services.AddTransient<ISampleDataRepository, SampleDataRepository>();
builder.Services.AddTransient<IThemeSelectorService, ThemeSelectorService>();

builder.Services.Configure<AppConfig>(builder.Configuration.GetSection("AppConfig"));


var app = builder.Build();
app.RunAsync();
