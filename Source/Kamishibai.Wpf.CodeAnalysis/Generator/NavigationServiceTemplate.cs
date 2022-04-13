﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン: 17.0.0.0
//  
//     このファイルへの変更は、正しくない動作の原因になる可能性があり、
//     コードが再生成されると失われます。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Kamishibai.Wpf.CodeAnalysis.Generator
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class NavigationServiceTemplate : TemplateBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("using Kamishibai.Wpf;\r\n\r\nnamespace ");
            this.Write(this.ToStringHelper.ToStringWithCulture(Namespace));
            this.Write(@";

public partial interface INavigationService
{
    public bool CanGoBack { get; }
    public Task<bool> NavigateAsync(Type viewModelType, string frameName = """");
    public Task<bool> NavigateAsync<TViewModel>(string frameName = """") where TViewModel : class;
    public Task<bool> NavigateAsync<TViewModel>(TViewModel viewModel, string frameName = """") where TViewModel : class;
    public Task<bool> NavigateAsync<TViewModel>(Action<TViewModel> init, string frameName = """") where TViewModel : class;
");

foreach(var navigationInfo in NavigationInfos)
{

            this.Write("    public Task<bool> NavigateTo");
            this.Write(this.ToStringHelper.ToStringWithCulture(navigationInfo.NavigationName));
            this.Write("Async(");
            this.Write(this.ToStringHelper.ToStringWithCulture(navigationInfo.NavigationParameters));
            this.Write(");\r\n");
  
}

            this.Write("    Task<bool> GoBackAsync(string frameName = \"\");\r\n}\r\n\r\npublic class NavigationS" +
                    "ervice : INavigationService\r\n{\r\n    private readonly INavigationFrameProvider _n" +
                    "avigationFrameProvider;\r\n    private readonly IServiceProvider _serviceProvider;" +
                    "\r\n\r\n    public bool CanGoBack { get; } = false;\r\n\r\n    public NavigationService(" +
                    "IServiceProvider serviceProvider, INavigationFrameProvider navigationFrameProvid" +
                    "er)\r\n    {\r\n        _serviceProvider = serviceProvider;\r\n        _navigationFram" +
                    "eProvider = navigationFrameProvider;\r\n    }\r\n\r\n    public Task<bool> NavigateAsy" +
                    "nc(Type viewModelType, string frameName = \"\")\r\n    {\r\n        return _navigation" +
                    "FrameProvider\r\n            .GetNavigationFrame(frameName)\r\n            .Navigate" +
                    "Async(viewModelType, _serviceProvider);\r\n    }\r\n\r\n    public Task<bool> Navigate" +
                    "Async<TViewModel>(string frameName = \"\") where TViewModel : class\r\n    {\r\n      " +
                    "  return _navigationFrameProvider\r\n            .GetNavigationFrame(frameName)\r\n " +
                    "           .NavigateAsync<TViewModel>(_serviceProvider);\r\n    }\r\n\r\n    public Ta" +
                    "sk<bool> NavigateAsync<TViewModel>(TViewModel viewModel, string frameName = \"\") " +
                    "where TViewModel : class\r\n    {\r\n        return _navigationFrameProvider\r\n      " +
                    "      .GetNavigationFrame(frameName)\r\n            .NavigateAsync(viewModel, _ser" +
                    "viceProvider);\r\n    }\r\n\r\n    public Task<bool> NavigateAsync<TViewModel>(Action<" +
                    "TViewModel> init, string frameName = \"\") where TViewModel : class\r\n    {\r\n      " +
                    "  return _navigationFrameProvider\r\n            .GetNavigationFrame(frameName)\r\n " +
                    "           .NavigateAsync(init, _serviceProvider);\r\n    }\r\n\r\n");

foreach(var navigationInfo in NavigationInfos)
{

            this.Write("    public Task<bool> NavigateTo");
            this.Write(this.ToStringHelper.ToStringWithCulture(navigationInfo.NavigationName));
            this.Write("Async(");
            this.Write(this.ToStringHelper.ToStringWithCulture(navigationInfo.NavigationParameters));
            this.Write(")\r\n    {\r\n        return NavigateAsync(\r\n            new ");
            this.Write(this.ToStringHelper.ToStringWithCulture(navigationInfo.ViewModelName));
            this.Write("(\r\n                ");
            this.Write(this.ToStringHelper.ToStringWithCulture(navigationInfo.ConstructorParameters));
            this.Write("\r\n            ), \r\n            frameName);\r\n    }\r\n\r\n");
  
}

            this.Write("    public Task<bool> GoBackAsync(string frameName = \"\")\r\n    {\r\n        return _" +
                    "navigationFrameProvider\r\n            .GetNavigationFrame(frameName)\r\n           " +
                    " .GoBackAsync();\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
}
