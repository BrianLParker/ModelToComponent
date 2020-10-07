// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponent
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using ModelToComponent.Models;
    using ModelToComponent.Views.Components;
    using ModelToComponentMapper.Models.ViewSelectorModels;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var viewModelComponentSelector = new ViewModelComponentSelector();
            viewModelComponentSelector.RegisterDefaults();
            viewModelComponentSelector.RegisterView<NavItem, NavItemView>();
            builder.Services.AddScoped<IViewSelector>(sp => viewModelComponentSelector);

            await builder.Build().RunAsync();
        }
    }
}
