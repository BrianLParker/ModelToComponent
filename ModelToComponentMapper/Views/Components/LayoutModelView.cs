// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponentMapper
{
    using System;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Rendering;

    public class LayoutModelView : ModelView
    {

        [Parameter]
        public RenderFragment Body { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            builder.OpenComponent<CascadingValue<ModelView>>(0);
            builder.AddAttribute(1, "Value", this);
            builder.AddAttribute(2, "ChildContent", ChildContent);
            builder.CloseComponent();
            foreach (object model in models)
            {
                if (model is not null)
                {
                    (Type componentType, string propertyName) viewComponentInfo = GetModelViewComponentInfo(model);
                    builder.OpenComponent(3, viewComponentInfo.componentType);
                    builder.AddAttribute(4, viewComponentInfo.propertyName, model);
                    if (viewComponentInfo.componentType.IsSubclassOf(typeof(LayoutComponentBase)))
                    {
                        builder.AddAttribute(5, "Body", Body);
                    }
                    builder.SetKey(model);
                    builder.CloseComponent();
                }
            }
        }
    }
}
