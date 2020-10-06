# Model to Component Mapper
Blazor Model to Component Mapper

```
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

Note the inheritance of ViewComponentBase<TModel> 

```
@inherits ViewComponentBase<NavItem>

<li class="nav-item px-3">
    <NavLink class="nav-link" href="@Model.Href">
        <span class="@Model.Icon" aria-hidden="true"></span> @Model.Text
    </NavLink>
</li>
```


```
<ModelView Source="DataSource.NavItems">
    <ViewRegistration TModel="NavItem" TComponent="NavItemView" />
</ModelView>
```


