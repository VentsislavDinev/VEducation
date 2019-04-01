namespace VEducation.Data.ViewModels.Layout
{
    using Abp.Application.Navigation;

    /// <summary>
    /// The top menu view model.
    /// </summary>
    public class TopMenuViewModel
    {
        /// <summary>
        /// Gets or sets the main menu.
        /// </summary>
        public UserMenu MainMenu { get; set; }

        /// <summary>
        /// Gets or sets the active menu item name.
        /// </summary>
        public string ActiveMenuItemName { get; set; }
    }
}
