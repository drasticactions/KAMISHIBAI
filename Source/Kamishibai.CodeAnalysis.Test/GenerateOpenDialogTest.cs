using System.Threading.Tasks;
using Xunit;

namespace Kamishibai.CodeAnalysis.Test;

public class GenerateOpenDialogTest
{
    [Fact]
    public async Task When_constructor_missing()
    {
        var code = @"
using Kamishibai;

[OpenDialogAttribute]
public class Foo
{
}";

        await code.GenerateSource().Should().BeAsync(
            @"#nullable enable
using System;
using System.Threading.Tasks;
using Kamishibai;

namespace TestProject
{
    public partial interface IPresentationService : IPresentationServiceBase
    {
        Task OpenFooDialogAsync(object? owner = null, OpenDialogOptions? options = null);
    }

    public class PresentationService : PresentationServiceBase, IPresentationService
    {
        private readonly IServiceProvider _serviceProvider;

        public PresentationService(IServiceProvider serviceProvider, INavigationFrameProvider navigationFrameProvider, IWindowService windowService)
            : base (serviceProvider, navigationFrameProvider, windowService)
        {
            _serviceProvider = serviceProvider;
        }

        public Task OpenFooDialogAsync(object? owner = null, OpenDialogOptions? options = null)
        {
            return OpenDialogAsync(
                new Foo(
                    
                ), 
                owner,
                options);
        }
    }
}");
    }


    [Fact]
    public async Task When_OpenDialog_specified()
    {
        var code = @"
using Kamishibai;

[OpenDialog]
public class Foo
{
    public Foo()
    {
    }
}";

        await code.GenerateSource().Should().BeAsync(
            @"#nullable enable
using System;
using System.Threading.Tasks;
using Kamishibai;

namespace TestProject
{
    public partial interface IPresentationService : IPresentationServiceBase
    {
        Task OpenFooDialogAsync(object? owner = null, OpenDialogOptions? options = null);
    }

    public class PresentationService : PresentationServiceBase, IPresentationService
    {
        private readonly IServiceProvider _serviceProvider;

        public PresentationService(IServiceProvider serviceProvider, INavigationFrameProvider navigationFrameProvider, IWindowService windowService)
            : base (serviceProvider, navigationFrameProvider, windowService)
        {
            _serviceProvider = serviceProvider;
        }

        public Task OpenFooDialogAsync(object? owner = null, OpenDialogOptions? options = null)
        {
            return OpenDialogAsync(
                new Foo(
                    
                ), 
                owner,
                options);
        }
    }
}");

    }

    [Fact]
    public async Task When_OpenDialogAttribute_specified()
    {
        var code = @"
using Kamishibai;

[OpenDialogAttribute]
public class Foo
{
    public Foo()
    {
    }
}";

        await code.GenerateSource().Should().BeAsync(
            @"#nullable enable
using System;
using System.Threading.Tasks;
using Kamishibai;

namespace TestProject
{
    public partial interface IPresentationService : IPresentationServiceBase
    {
        Task OpenFooDialogAsync(object? owner = null, OpenDialogOptions? options = null);
    }

    public class PresentationService : PresentationServiceBase, IPresentationService
    {
        private readonly IServiceProvider _serviceProvider;

        public PresentationService(IServiceProvider serviceProvider, INavigationFrameProvider navigationFrameProvider, IWindowService windowService)
            : base (serviceProvider, navigationFrameProvider, windowService)
        {
            _serviceProvider = serviceProvider;
        }

        public Task OpenFooDialogAsync(object? owner = null, OpenDialogOptions? options = null)
        {
            return OpenDialogAsync(
                new Foo(
                    
                ), 
                owner,
                options);
        }
    }
}");
    }

    [Fact]
    public async Task When_open_window_with_arguments()
    {
        var code = @"
using Kamishibai;

namespace Foo
{
    public class Argument
    {
    }

    [OpenDialog]
    public class Bar
    {
        public Bar(int number, Argument argument)
        {
        }
    }
}
";

        await code.GenerateSource().Should().BeAsync(
            @"#nullable enable
using System;
using System.Threading.Tasks;
using Kamishibai;

namespace TestProject
{
    public partial interface IPresentationService : IPresentationServiceBase
    {
        Task OpenBarDialogAsync(int number, Foo.Argument argument, object? owner = null, OpenDialogOptions? options = null);
    }

    public class PresentationService : PresentationServiceBase, IPresentationService
    {
        private readonly IServiceProvider _serviceProvider;

        public PresentationService(IServiceProvider serviceProvider, INavigationFrameProvider navigationFrameProvider, IWindowService windowService)
            : base (serviceProvider, navigationFrameProvider, windowService)
        {
            _serviceProvider = serviceProvider;
        }

        public Task OpenBarDialogAsync(int number, Foo.Argument argument, object? owner = null, OpenDialogOptions? options = null)
        {
            return OpenDialogAsync(
                new Foo.Bar(
                    number,
                    argument
                ), 
                owner,
                options);
        }
    }
}");
    }

    [Fact]
    public async Task When_open_window_with_arguments_include_Inject()
    {
        var code = @"
using System.Collections.Generic;
using Kamishibai;

namespace Foo
{
    public class Argument
    {
    }

    [OpenDialog]
    public class Bar
    {
        public Bar(int number, [Inject]IList<string> items, Argument argument)
        {
        }
    }
}
";

        await code.GenerateSource().Should().BeAsync(
            @"#nullable enable
using System;
using System.Threading.Tasks;
using Kamishibai;

namespace TestProject
{
    public partial interface IPresentationService : IPresentationServiceBase
    {
        Task OpenBarDialogAsync(int number, Foo.Argument argument, object? owner = null, OpenDialogOptions? options = null);
    }

    public class PresentationService : PresentationServiceBase, IPresentationService
    {
        private readonly IServiceProvider _serviceProvider;

        public PresentationService(IServiceProvider serviceProvider, INavigationFrameProvider navigationFrameProvider, IWindowService windowService)
            : base (serviceProvider, navigationFrameProvider, windowService)
        {
            _serviceProvider = serviceProvider;
        }

        public Task OpenBarDialogAsync(int number, Foo.Argument argument, object? owner = null, OpenDialogOptions? options = null)
        {
            return OpenDialogAsync(
                new Foo.Bar(
                    number,
                    (System.Collections.Generic.IList<string>)_serviceProvider.GetService(typeof(System.Collections.Generic.IList<string>))!,
                    argument
                ), 
                owner,
                options);
        }
    }
}");
    }

    [Fact]
    public async Task When_open_window_with_nullable_arguments()
    {
        var code = @"
using Kamishibai;

namespace Foo
{
    public class Argument
    {
    }

    [OpenDialog]
    public class Bar
    {
        public Bar(int? number, Argument argument)
        {
        }
    }
}
";

        await code.GenerateSource().Should().BeAsync(
            @"#nullable enable
using System;
using System.Threading.Tasks;
using Kamishibai;

namespace TestProject
{
    public partial interface IPresentationService : IPresentationServiceBase
    {
        Task OpenBarDialogAsync(int? number, Foo.Argument argument, object? owner = null, OpenDialogOptions? options = null);
    }

    public class PresentationService : PresentationServiceBase, IPresentationService
    {
        private readonly IServiceProvider _serviceProvider;

        public PresentationService(IServiceProvider serviceProvider, INavigationFrameProvider navigationFrameProvider, IWindowService windowService)
            : base (serviceProvider, navigationFrameProvider, windowService)
        {
            _serviceProvider = serviceProvider;
        }

        public Task OpenBarDialogAsync(int? number, Foo.Argument argument, object? owner = null, OpenDialogOptions? options = null)
        {
            return OpenDialogAsync(
                new Foo.Bar(
                    number,
                    argument
                ), 
                owner,
                options);
        }
    }
}");

    }
}