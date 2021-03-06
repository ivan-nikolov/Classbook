﻿namespace Classbook.App.Components.Common.ToastNotifications
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components;

    public partial class BlazoredToast
    {
        [CascadingParameter]
        public BlazoredToasts ToastContainer { get; set; }

        [Parameter]
        public string ToastId { get; set; }

        [Parameter]
        public ToastSettings ToastSettings { get; set; }

        private async Task Close()
        {
            await this.ToastContainer.RemoveToast(this.ToastId);
        }
    }
}
