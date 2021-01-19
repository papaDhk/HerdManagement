using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI
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
    }
}
