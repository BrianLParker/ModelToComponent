namespace ModelToComponentMapper
{
    using System;
    using Microsoft.AspNetCore.Components;
    using ModelToComponentMapper.Models;

    public class ViewRegistration<TModel, TComponent> : ComponentBase where TComponent : ViewComponentBase<TModel>
    {
        [CascadingParameter]
        public ModelView ModelView { get; set; }

        protected override void OnInitialized()
        {
            if (ModelView is null) throw new Exception("ViewDefinition should be defined within a <ModelView>...</ModelView> ");
            if (ModelView.ViewSelector is ViewModelComponentSelector modelViewSelector)
            {
                ModelView.RegisterView<TModel,TComponent>();
            }
            else
            {
                throw new Exception("ViewDefinition's are only valid using a ModelViewSelector");
            }
            base.OnInitialized();
        }
    }
}
