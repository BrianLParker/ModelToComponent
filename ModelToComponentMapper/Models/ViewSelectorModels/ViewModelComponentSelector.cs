// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponentMapper.Models.ViewSelectorModels
{
    using System;
    using System.Collections.Generic;
    using ModelToComponentMapper.Models.Elements;
    using ModelToComponentMapper.Views.Components;

    public class ViewModelComponentSelector : IViewSelector
    {
        public void RegisterView<TModel, TComponent>(bool defaultView = false)
            => RegisterView(typeof(TModel), typeof(TComponent), string.Empty);

        public void RegisterView<TModel, TComponent>(string propertyName, bool defaultView = false)
            => RegisterView(typeof(TModel), typeof(TComponent), propertyName, defaultView);

        public (Type componentType, string propertyName) GetModelViewComponentInfo(object model)
        {
            string assemblyQualifiedName = model.GetType().AssemblyQualifiedName;
            return this.modelViewComponents.ContainsKey(assemblyQualifiedName) ?
                (Type.GetType(this.modelViewComponents[assemblyQualifiedName].assemblyQualifiedName), this.modelViewComponents[assemblyQualifiedName].propertyName) :
                (null, null);
        }

        public void RegisterDefaults()
        {
            RegisterView<Division, DivisionView>();
            RegisterView<Paragraph, ParagraphView>();
            RegisterView<Heading, HeadingView>();
            RegisterView<ImageSource, ImageSourceView>();
            RegisterView<Anchor, AnchorView>();
            RegisterView<Markup, MarkupView>();
            RegisterView<Break, BreakView>();
        }

        private void RegisterView(Type modelType, Type componentType, string propertyName, bool defaultView = false)
        {
            this.modelViewComponents[modelType.AssemblyQualifiedName] = (componentType.AssemblyQualifiedName, propertyName);
        }

        private readonly Dictionary<string, (string assemblyQualifiedName, string propertyName)> modelViewComponents = new Dictionary<string, (string assemblyQualifiedName, string propertyName)>();
    }
}
