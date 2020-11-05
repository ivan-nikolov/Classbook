namespace Classbook.App.Components.Common.Modal
{
    using System;

    using Microsoft.AspNetCore.Components;

    public class ModalService : IModalService
    {
        private Type modalType;

        public event EventHandler<ModalResult> OnClose;

        public event EventHandler<EventArgs> CloseModal;

        public event EventHandler<OnShowEventArgs> OnShow;

        public void Cancel()
        {
            CloseModal?.Invoke(this, EventArgs.Empty);
            OnClose?.Invoke(this, ModalResult.Cancel(this.modalType));
        }

        public void Close(ModalResult modalResult)
        {
            modalResult.ModalType = this.modalType;
            CloseModal?.Invoke(this, EventArgs.Empty);
            OnClose?.Invoke(this, modalResult);
        }

        public void Show<T>(string title, ModalParameters parameters)
            where T : ComponentBase
        {
            this.Show<T>(title, parameters, new ModalOptions());
        }

        public void Show<T>(string title, ModalParameters parameters = null, ModalOptions options = null)
             where T : ComponentBase
        {
            this.Show(typeof(T), title, parameters, options);
        }

        public void Show(Type contentComponent, string title, ModalParameters parameters, ModalOptions options)
        {
            if (!typeof(ComponentBase).IsAssignableFrom(contentComponent))
            {
                throw new ArgumentException("Must be a Blazor Component!");
            }

            var content = new RenderFragment(x =>
            {
                x.OpenComponent(1, contentComponent);
                x.CloseComponent();
            });

            var onShowEventArgs = new OnShowEventArgs()
            {
                Title = title,
                Content = content,
                Parameters = parameters,
                Options = options,
            };

            this.modalType = contentComponent;
            OnShow?.Invoke(this, onShowEventArgs);
        }
    }
}
