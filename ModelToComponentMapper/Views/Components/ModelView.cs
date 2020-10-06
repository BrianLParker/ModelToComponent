namespace ModelToComponentMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;
    using ModelToComponentMapper.Models;

    public class ModelView : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public IViewSelector ViewSelector { get; set; } = new ViewModelComponentSelector();

        [Parameter]
        public object Source { get; set; }

        private Type GetModelViewComponentType(object obj) => ViewSelector.GetModelViewComponentType(obj);
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }

        public void RegisterView<TModel, TComponentType>() where TComponentType : ViewComponentBase<TModel>
        {
            if (ViewSelector is ViewModelComponentSelector viewSelector)
            {
                viewSelector.RegisterView<TModel, TComponentType>();
                StateHasChanged();
            }
        }

        public void RegisterDefaults()
        {
            if (ViewSelector is ViewModelComponentSelector viewSelector)
            {
                viewSelector.RegisterDefaults();
            }
        }
        private bool IsEnumerable => Source as System.Collections.IEnumerable is not null;

        private IEnumerable<object> models
        {
            get
            {
                if (IsEnumerable)
                {
                    return (Source as System.Collections.IEnumerable).Cast<object>();
                }
                else
                {
                    return new object[] { Source };
                }
            }
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<CascadingValue<ModelView>>(1);
            builder.AddAttribute(2, "Value", this);
            builder.AddAttribute(3, "ChildContent", ChildContent);
            builder.CloseComponent();
            int i = 4;
            foreach (object model in models)
            {
                Type componentType = GetModelViewComponentType(model);
                if (componentType is not null)
                {
                    builder.OpenComponent(i++, componentType);
                    builder.AddAttribute(i++, "Model", model);
                    builder.CloseComponent();
                }
            }
            base.BuildRenderTree(builder);
        }
    }


}
