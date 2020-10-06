# Model to Component Mapper
Blazor Model to Component Mapper

```
@using ModelToComponentMapper
@using ModelToComponentMapper.Models
@using ModelToComponentMapper.Views.Components

<ModelView Source="DataSource.FakeBlogItems">
    <ViewRegistration TModel="Division" TComponent="DivisionView" />
    <ViewRegistration TModel="Paragraph" TComponent="ParagraphView" />
    <ViewRegistration TModel="Heading" TComponent="HeadingView" />
    <ViewRegistration TModel="ImageSource" TComponent="ImageSourceView" />
    <ViewRegistration TModel="Anchor" TComponent="AnchorView" />
    <ViewRegistration TModel="Markup" TComponent="MarkupView" />
</ModelView>
```

```NavItemView.razor```

Note the inheritance of ```ViewComponentBase``` and the use the @Model. Future release will not require the use of a base class but a known property name that is of type TModel

```
@using ModelToComponentMapper
@inherits ViewComponentBase<NavItem>
<li class="nav-item px-3">
    <NavLink class="nav-link" href="@Model.Href" Match="@Model.NavLinkMatch">
        <span class="@Model.Icon" aria-hidden="true"></span> @Model.Text
    </NavLink>
</li>
```


```
<ModelView Source="DataSource.NavItems">
    <ViewRegistration TModel="NavItem" TComponent="NavItemView" />
</ModelView>
```


In ```program.cs``` 

```
    var viewModelComponentSelector = new ViewModelComponentSelector();
    viewModelComponentSelector.RegisterDefaults();
    viewModelComponentSelector.RegisterView<NavItem, NavItemView>();
    builder.Services.AddScoped<IViewSelector>(sp => viewModelComponentSelector);
```

```
@using ModelToComponentMapper
@page "/"

<ModelView Source="FakeDataSource.BlogItems" />
```

produced this:

![alt text](https://user-images.githubusercontent.com/8317299/95257997-d94d1900-0870-11eb-99f5-832aba33f2f0.png)


