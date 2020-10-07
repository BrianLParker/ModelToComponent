namespace ModelToComponentMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;
    using ModelToComponentMapper.Models.ViewSelectorModels;

    public class ModelView : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Inject]
        public IViewSelector ViewSelector { get; set; } = new ViewModelComponentSelector();

        [Parameter]
        public object Source { get; set; }

        private (Type componentType, string propertyName) GetModelViewComponentInfo(object obj) => ViewSelector.GetModelViewComponentInfo(obj);
        protected override void OnAfterRender(bool firstRender) => base.OnAfterRender(firstRender);

        public void RegisterView<TModel, TComponentType>(string propertyName = "Model")
        {
            if (ViewSelector is ViewModelComponentSelector viewSelector)
            {
                var propertyInfo = typeof(TComponentType).GetProperty(propertyName);
                if (propertyInfo is null) throw new ArgumentException("(propertyName) Property Not Found!");
                if (propertyInfo.PropertyType != typeof(TModel)) throw new ArgumentException("Property is not of the correct type (TModel)!");
                viewSelector.RegisterView<TModel, TComponentType>(propertyName);
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
            foreach (object model in models)
            {
                var viewComponentInfo = GetModelViewComponentInfo(model);
                Type componentType = viewComponentInfo.componentType;
                if (componentType is not null)
                {
                    builder.OpenComponent(model.GetHashCode(), componentType);
                    builder.AddAttribute(model.GetHashCode() +1, string.IsNullOrWhiteSpace(viewComponentInfo.propertyName) ? "Model" : viewComponentInfo.propertyName, model);
                    builder.CloseComponent();
                }
            }
            base.BuildRenderTree(builder);
        }
    }


}
