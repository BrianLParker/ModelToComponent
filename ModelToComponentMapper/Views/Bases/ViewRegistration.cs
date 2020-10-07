namespace ModelToComponentMapper
{
    using System;
    using Microsoft.AspNetCore.Components;
    using ModelToComponentMapper.Models;

    public class ViewRegistration<TModel, TComponent> : ComponentBase where TComponent : ComponentBase
    {
        [CascadingParameter]
        public ModelView ModelView { get; set; }

        [Parameter]
        public string PropertyName { get; set; }

        protected override void OnInitialized()
        {
            if (ModelView is null) throw new Exception("ViewDefinition should be defined within a <ModelView>...</ModelView> ");
            if (ModelView.ViewSelector is ViewModelComponentSelector modelViewSelector)
            {
                if (string.IsNullOrWhiteSpace(PropertyName))
                {
                    ModelView.RegisterView<TModel, TComponent>();
                }
                else
                {
                    ModelView.RegisterView<TModel, TComponent>(PropertyName);
                }

            }
            else
            {
                throw new Exception("ViewDefinition's are only valid using a ModelViewSelector");
            }
            base.OnInitialized();
        }
    }
  
}
