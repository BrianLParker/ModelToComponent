// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponentMapper.Services
{
    using System;
    using System.Collections.Generic;

    public class ViewModelService
    {
        public void RegisterView<TModel, TComponent>() where TComponent : ViewComponentBase<TModel>
            => RegisterView(typeof(TModel), typeof(TComponent));

        internal void RegisterView(Type modelType, Type componentType)
            => this.views[modelType.FullName] = componentType.FullName;

        private readonly Dictionary<string, string> views = new Dictionary<string, string>();
    }
}
