using Microsoft.JSInterop;

namespace SharedComponents.Utils
{
    public class BootstrapService
    {
        private IJSRuntime _js;

        public BootstrapService(IJSRuntime jSRuntime)
        {
            this._js = jSRuntime ?? throw new ArgumentNullException(nameof(jSRuntime));
        }

        public async Task HideModal(string identifier)
        {
            await _js.InvokeVoidAsync("hideModal", identifier);

        }

        public async Task ShowModal(string identifier)
        {
            await _js.InvokeVoidAsync("showModal", identifier);
        }
        
        public async Task Toast(string identifier)
        {
            await _js.InvokeVoidAsync("toast", identifier);
        }
    }
}
