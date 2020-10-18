namespace ModelToComponent.Views.Shared
{
    using Microsoft.AspNetCore.Components;
    using ModelToComponent.Models;

    public partial class ApplicationViewLayout : MainLayout
    {
        [Parameter]
        public IApplicationView ApplicationView { get; set; }
    }
}