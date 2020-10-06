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

```
<ModelView Source="DataSource.NavItems">
    <ViewRegistration TModel="NavItem" TComponent="NavItemView" />
</ModelView>
```
