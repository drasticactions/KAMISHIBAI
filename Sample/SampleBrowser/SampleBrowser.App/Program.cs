﻿using Kamishibai;
using SampleBrowser.View;
using SampleBrowser.View.Page;
using SampleBrowser.ViewModel;
using SampleBrowser.ViewModel.Page;

var builder = KamishibaiApplication<App, MainWindow>.CreateBuilder();

builder.Services.AddPresentation<MainWindow, MainViewModel>();
builder.Services.AddPresentation<ChildWindow, OpenWithArgumentsViewModel>();
builder.Services.AddPresentation<ChildWindow, OpenWithoutArgumentsViewModel>();

builder.Services.AddPresentation<NavigationMenuPage, NavigationMenuViewModel>();
builder.Services.AddPresentation<WithoutArgumentsPage, WithoutArgumentsViewModel>();
builder.Services.AddPresentation<WithArgumentsPage, WithArgumentsViewModel>();

builder.Services.AddPresentation<OpenWindowPage, OpenWindowViewModel>();
builder.Services.AddPresentation<OpenDialogPage, OpenDialogViewModel>();
builder.Services.AddPresentation<ShowMessagePage, ShowMessageViewModel>();
builder.Services.AddPresentation<OpenFilePage, OpenFileViewModel>();
builder.Services.AddPresentation<SaveFilePage, SaveFileViewModel>();


builder.Services.AddTransient<IPresentationService, PresentationService>();

var app = builder.Build();
app.RunAsync();
