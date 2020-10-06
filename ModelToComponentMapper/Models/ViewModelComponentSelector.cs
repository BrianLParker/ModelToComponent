// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponentMapper.Models
{
    using System;
    using System.Collections.Generic;
    using ModelToComponentMapper.Views.Components;

    public class ViewModelComponentSelector : IViewSelector
    {
        public void RegisterView<TModel, TComponent>(bool defaultView = false) where TComponent : ViewComponentBase<TModel>
            => RegisterView(typeof(TModel), typeof(TComponent));

        public Type GetModelViewComponentType(object model)
        {
            string assemblyQualifiedName = model.GetType().AssemblyQualifiedName;
            return this.modelViewComponents.ContainsKey(assemblyQualifiedName) ? Type.GetType(this.modelViewComponents[assemblyQualifiedName]) : null;
        }

        public void RegisterDefaults()
        {
            RegisterView<Division, DivisionView>();
            RegisterView<Paragraph, ParagraphView>();
            RegisterView<Heading, HeadingView>();
            RegisterView<ImageSource, ImageSourceView>();
            RegisterView<Anchor, AnchorView>();
            RegisterView<Markup, MarkupView>();
        }

        private void RegisterView(Type modelType, Type componentType)
        {
            this.modelViewComponents[modelType.AssemblyQualifiedName] = componentType.AssemblyQualifiedName;
        }

        private readonly Dictionary<string, string> modelViewComponents = new Dictionary<string, string>();
    }
}
