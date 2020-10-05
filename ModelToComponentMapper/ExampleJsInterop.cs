namespace ModelToComponentMapper
{
    using System.Threading.Tasks;
    using Microsoft.JSInterop;

    public class ExampleJsInterop
    {
        public static ValueTask<string> Prompt(IJSRuntime jsRuntime, string message)
        {
            // Implemented in exampleJsInterop.js
            return jsRuntime.InvokeAsync<string>(
                "exampleJsFunctions.showPrompt",
                message);
        }
    }
}
