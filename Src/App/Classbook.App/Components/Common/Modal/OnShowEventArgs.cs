namespace Classbook.App.Components.Common.Modal
{
    using System;

    using Microsoft.AspNetCore.Components;

    public class OnShowEventArgs : EventArgs
    {
        public string Title { get; set; }

        public RenderFragment Content { get; set; }

        public ModalParameters Parameters { get; set; }

        public ModalOptions Options { get; set; }
    }
}
