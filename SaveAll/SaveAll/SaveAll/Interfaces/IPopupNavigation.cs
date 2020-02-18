using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Events;
using Rg.Plugins.Popup.Pages;

namespace SaveAll.Interfaces
{
    public interface IPopupNavigation
    {
        // Invokes before adding to PopupStack
        // A page is not visible and animation has not been started at this moment
        event EventHandler<PopupNavigationEventArgs> Pushing;

        // Invokes after animation finished
        // A page is visible and animation has been finished at this moment
        event EventHandler<PopupNavigationEventArgs> Pushed;

        // Invokes before removing from PopupStack
        // A page is visible and animation has not been started at this moment
        event EventHandler<PopupNavigationEventArgs> Popping;

        // Invokes after animation finished and removing from PopupStack
        // A page is not visible and animation has been finished at this moment.
        event EventHandler<PopupNavigationEventArgs> Popped;

        // List of PopupPages which are in the scree
        IReadOnlyList<PopupPage> PopupStack { get; }

        // Open a PopupPage
        Task PushAsync(PopupPage page, bool animate = true);

        // Close the last PopupPage int the PopupStack
        Task PopAsync(bool animate = true);

        // Close all PopupPages in the PopupStack
        Task PopAllAsync(bool animate = true);

        // Close an one PopupPage in the PopupStack even if the page is not the last
        Task RemovePageAsync(PopupPage page, bool animate = true);
    }

}
