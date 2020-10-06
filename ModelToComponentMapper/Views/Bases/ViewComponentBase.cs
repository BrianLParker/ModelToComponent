namespace ModelToComponentMapper
{
    using Microsoft.AspNetCore.Components;

    public class ViewComponentBase<TModel> : ComponentBase
    {
        [Parameter]
        public TModel Model { get; set; }
    }
}
