// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponent
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Reflection.Metadata;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using ModelToComponent.Models;
    using ModelToComponent.Views.Components;
    using ModelToComponent.Views.Shared;
    using ModelToComponentMapper.Models.ViewSelectorModels;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            await GetUserView(builder, httpClient);
            builder.Services.AddScoped(sp => httpClient);
            ConfigureDefaultViewModelSelector(builder);
            await builder.Build().RunAsync();
        }
        private static async Task GetUserView(WebAssemblyHostBuilder builder, HttpClient httpClient)
        {
            var apiResponse = await httpClient.GetFromJsonAsync<ApiResponse>("FakeApi/userView.json");
            builder.Services.AddScoped<IApplicationView>(sp => apiResponse.UserView);
        }
        private static void ConfigureDefaultViewModelSelector(WebAssemblyHostBuilder builder)
        {
            ViewModelComponentSelector viewModelComponentSelector = new ViewModelComponentSelector();
            viewModelComponentSelector.RegisterDefaults();
            viewModelComponentSelector.RegisterView<NavItem, NavItemView>();
            viewModelComponentSelector.RegisterView<NavigationView, NavMenu>();
            viewModelComponentSelector.RegisterView<ApplicationView, ApplicationViewLayout>("ApplicationView");
            builder.Services.AddScoped<IViewSelector>(sp => viewModelComponentSelector);
        }
    }
}
