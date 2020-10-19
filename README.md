# Model to Component Mapper
Blazor model to component mapper. Maps a class to a blazor component. The component must have a parameter that accepts the model. This can allow an application to be completely data driven.

## Example:


```
@page "/"

<ModelView Source="FakeDataSource.BlogItems" />
```

### Output:

![alt text](https://user-images.githubusercontent.com/8317299/95257997-d94d1900-0870-11eb-99f5-832aba33f2f0.png)


### Input data source:

```DataSource.cs```

```
  public static class FakeDataSource
    {
        public static readonly IReadOnlyList<object> BlogItems = new object[]
        {
            new Heading { Text = "Hello World!", Level= HeadingLevel.One , InputAttributes = new Dictionary<string, object>() { { "class", "text-info" } } },
            new Division { Content =  new Paragraph { Content = "Welcome to my demonstration" } },
            new Paragraph { Text = "All these items are being rendered based on their data type and order from an enumerable object source" },
            new ImageSource { DisplayHeight = 259, DisplayWidth = 241, Source = imageData, InputAttributes = new Dictionary<string, object>() { { "class", "shadow-lg p-3 mb-5 bg-white rounded" } }  },
            new Paragraph { Text = "Pretty cool, huh?" },
            new Anchor { Text = "Brian Parker", Href = "https://brianparker.azurewebsites.net/" },
            new Break { },
            new Markup { RawHtml = stackFlare },
        };

        public static readonly IReadOnlyList<object> NavItems = new object[]
        {
            new NavItem { Text = "Home", Icon ="oi oi-home" , Href ="" , NavLinkMatch = NavLinkMatch.All },
            new NavItem { Text = "By Mark-up", Icon ="oi oi-code" , Href ="byLayout" },
            new NavItem { Text = "By Code", Icon ="oi oi-excerpt" , Href ="byCode" },
            new NavItem { Text = "Non Enumerable", Icon ="oi oi-image" , Href ="nonEnumerable" },
            new NavItem { Text = "Standard Component", Icon ="oi oi-image" , Href ="standardComponent" },
            new NavItem { Text = "Registration Error", Icon ="oi oi-bug" , Href ="registrationError" },            
        };

        private const string imageData = "data:image/jpeg; base64, (truncated)";
        private const string stackFlare = "<a href=\"https://stackoverflow.com/users/1492496/brian-parker\" target=\"_blank\"><img src=\"https://stackoverflow.com/users/flair/1492496.png?theme=dark\" width=\"208\" height=\"58\" alt=\"profile for Brian Parker at Stack Overflow, Q & A for professional and enthusiast programmers\" title=\"profile for Brian Parker at Stack Overflow, Q & A for professional and enthusiast programmers\"></a>";

    }
```


The data source ```Source``` does not have to be enumerable.

```
<ModelView Source="ImageSource" />

@code {
    ImageSource ImageSource = new ImageSource { Source = FakeDataSource.imageData, DisplayHeight = 259, DisplayWidth = 241 };
}

```


## Example Component
```NavItemView.razor```

```
<li class="nav-item px-3">
    <NavLink class="nav-link" href="@NavItem.Href" Match="@NavItem.NavLinkMatch">
        <span class="@NavItem.Icon" aria-hidden="true"></span> @NavItem.Text
    </NavLink>
</li>

@code {
    [Parameter]
    public NavItem NavItem { get; set; }
}
```
### Usage
This is overkill for only one model type it is just an example of view registration using mark-up within a .razor component.
```
<ModelView Source="DataSource.NavItems">
    <ViewRegistration TModel="NavItem" TComponent="NavItemView" PropertyName="NavItem" />
</ModelView>
```

### The library provides a base component
``` ViewComponentBase ``` that can be inherited instead of ``` ComponentBase ``` . This is a convenient way of implementing the required property with the parameter name ``` Model ``` .

```
@inherits ViewComponentBase<NavItem>
<li class="nav-item px-3">
    <NavLink class="nav-link" href="@Model.Href" Match="@Model.NavLinkMatch">
        <span class="@Model.Icon" aria-hidden="true"></span> @Model.Text
    </NavLink>
</li>
```

### Usage
```
<ModelView Source="DataSource.NavItems">
    <ViewRegistration TModel="NavItem" TComponent="NavItemView" />
</ModelView>
```

Note: PropertyName is defaulted to "Model". It does not have to be declared when using ``` ViewComponentBase ```


You can register all your components in ``` program.cs ```. These become the default components. Any components defined within the ``` <ModelView> ``` mark-up override the default components.
In ```program.cs``` 

```
    public class Program
    {
        public static async Task Main(string[] args)
        {
           ...

            ConfigureDefaultViewModelSelector(builder);

            ...
        }

        private static void ConfigureDefaultViewModelSelector(WebAssemblyHostBuilder builder)
        {
            ViewModelComponentSelector viewModelComponentSelector = new ViewModelComponentSelector();
            viewModelComponentSelector.RegisterDefaults();
            viewModelComponentSelector.RegisterView<NavItem, NavItemView>();
            builder.Services.AddScoped<IViewSelector>(sp => viewModelComponentSelector);
        }
    }
 ```

The previous example could then become:

```
<ModelView Source="DataSource.NavItems" />
```
