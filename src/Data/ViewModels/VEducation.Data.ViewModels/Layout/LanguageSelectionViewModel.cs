namespace VEducation.Data.ViewModels.Layout
{
    using System.Collections.Generic;

    using Abp.Localization;

    public class LanguageSelectionViewModel
    {
        public LanguageInfo CurrentLanguage { get; set; }

        public IReadOnlyList<LanguageInfo> Languages { get; set; }
    }
}
