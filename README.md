# Model to Component Mapper
Blazor Model to Component Mapper. Maps a class to a blazor component. The component must have a parameter that accepts the model.

## Example Component
```NavItemView.razor```

```
@inherits ViewComponentBase<NavItem>
<li class="nav-item px-3">
    <NavLink class="nav-link" href="@Model.Href" Match="@Model.NavLinkMatch">
        <span class="@Model.Icon" aria-hidden="true"></span> @Model.Text
    </NavLink>
</li>
```

The library provides a base component ``` ViewComponentBase ``` that can be inherited instead of ``` ComponentBase ``` . This is a convenient way of implementing the required property with the parameter name ``` Model ``` .

## Usage
This is overkill for only one model type it is just an example of view registration within a .razor component.
```
<ModelView Source="DataSource.NavItems">
    <ViewRegistration TModel="NavItem" TComponent="NavItemView" />
</ModelView>
```

You can register all your components in program.cs (Functionality not complete. Registration here should only be defaults that can be over written not replaced.)
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

A richer example:


```
@using ModelToComponentMapper
@page "/"

<ModelView Source="FakeDataSource.BlogItems" />
```

produced this:

![alt text](https://user-images.githubusercontent.com/8317299/95257997-d94d1900-0870-11eb-99f5-832aba33f2f0.png)


from this:

```DataSource.cs```

```
  public static class FakeDataSource
    {
        public static readonly IReadOnlyList<object> BlogItems = new object[]
        {
            new Heading { Text = "Hello World!", Level= HeadingLevel.One },
            new Division { Text = "Welcome to my" },
            new Anchor { Text = "My Website.", Href ="https://brianparker.azurewebsites.net/" },
            new Division { Text = "All these items are being rendered based on their data type and order from an enumerable object source" },
            new ImageSource { DisplayHeight=259, DisplayWidth=241, Source = imageData },
            new Division { Text = "Pretty cool, huh?" },
            new Markup { Text = stackFlare }
        };

        public static readonly IReadOnlyList<object> NavItems = new object[]
        {
            new NavItem { Text = "Home", Icon ="oi oi-home" , Href ="" , NavLinkMatch = NavLinkMatch.All },
            new NavItem { Text = "By Layout", Icon ="oi oi-code" , Href ="byLayout" },
            new NavItem { Text = "By Code", Icon ="oi oi-excerpt" , Href ="byCode" }
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
