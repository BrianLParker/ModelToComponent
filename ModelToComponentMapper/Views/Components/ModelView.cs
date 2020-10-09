// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

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
        [Inject]
        public IViewSelector DefaultViewSelector { get; set; }

        [Parameter]
        public IViewSelector ViewSelector { get; set; } = new ViewModelComponentSelector();

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public object Source { get; set; }

        private (Type componentType, string propertyName) GetModelViewComponentInfo(object model)
        {
            (Type componentType, string propertyName) viewComponentInfo = ViewSelector.GetModelViewComponentInfo(model);
            if (viewComponentInfo == (null, null))
            {
                viewComponentInfo = DefaultViewSelector.GetModelViewComponentInfo(model);
            }

            return viewComponentInfo;

        }

        protected override void OnAfterRender(bool firstRender) => base.OnAfterRender(firstRender);

        public void RegisterView<TModel, TComponentType>(string propertyName = "Model")
        {
            if (ViewSelector is ViewModelComponentSelector viewSelector)
            {
                System.Reflection.PropertyInfo propertyInfo = typeof(TComponentType).GetProperty(propertyName);
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

            builder.OpenComponent<CascadingValue<ModelView>>(0);
            builder.AddAttribute(1, "Value", this);
            builder.AddAttribute(2, "ChildContent", ChildContent);
            builder.CloseComponent();
            int i = 3;
            foreach (object model in models)
            {
                (Type componentType, string propertyName) viewComponentInfo = GetModelViewComponentInfo(model);

                Type componentType = viewComponentInfo.componentType;
                if (componentType is not null)
                {
                    string propertyName = string.IsNullOrWhiteSpace(viewComponentInfo.propertyName) ? "Model" : viewComponentInfo.propertyName;
                    builder.OpenComponent(i++, componentType);
                    builder.AddAttribute(i++, propertyName, model);
                    builder.SetKey(model);
                    builder.CloseComponent();
                }
            }
            base.BuildRenderTree(builder);
        }
    }


}
