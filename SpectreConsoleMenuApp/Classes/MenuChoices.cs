using System.Globalization;

namespace SpectreConsoleMenuApp.Classes
{
    public class MenuChoices
    {
        /// <summary>
        /// Retrieves a list of available languages based on specific cultures.
        /// </summary>
        /// <remarks>
        /// The method filters out neutral cultures and ensures that only one culture per language is included.
        /// It also prioritizes "en-US" for the English language.
        /// The resulting list is sorted by the display name of the cultures and includes an additional "Exit" option.
        /// </remarks>
        /// <returns>
        /// A list of <see cref="Language"/> objects, each representing a language with its ID, title, and code.
        /// </returns>
        public static List<Language> GetLanguages()
        {
            // Retrieve all specific cultures, excluding neutral cultures
            var allCultures = CultureInfo
                .GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);

            var uniqueCultures = new Dictionary<string, CultureInfo>(StringComparer.OrdinalIgnoreCase);

            foreach (var culture in allCultures)
            {
                var langCode = culture.TwoLetterISOLanguageName;

                if (langCode.Equals("en", StringComparison.OrdinalIgnoreCase))
                {
                    if (culture.Name.Equals("en-US", StringComparison.OrdinalIgnoreCase))
                    {
                        uniqueCultures["en"] = culture;
                    }
                }
                else
                {
                    // One culture per language
                    uniqueCultures.TryAdd(langCode, culture);
                }
            }

            // Convert to sorted list
            var cultures = uniqueCultures
                .Values
                .OrderBy(c => c.DisplayName)
                .ToList();

            // Map cultures to Language objects
            var languages = cultures
                .Select((culture, index) => new Language
                {
                    Id = index,
                    Title = Markup.Escape(culture.DisplayName ?? string.Empty),
                    Code = culture.Name
                })
                .ToList();


            languages.Add(new Language
            {
                Id = -1,
                Title = "Exit"
            });

            return languages;
        }

        /// <summary>
        /// Gets the user's selected language from a list of available options.
        /// </summary>
        /// <remarks>
        /// The property prompts the user to select a language from a dynamically generated list of languages.
        /// The list is created using the <see cref="GetLanguages"/> method and includes an "Exit" option.
        /// The selection is highlighted with a custom style and allows navigation using up/down arrows.
        /// </remarks>
        /// <value>
        /// A <see cref="Language"/> object representing the user's choice, or an "Exit" option if no language is selected.
        /// </value>
        public static Language LanguageChoice =>
            AnsiConsole.Prompt(
                new SelectionPrompt<Language>()
                    .Title("[cyan]Select a language or last item to cancel by using up/down arrows then press enter[/]")
                    .AddChoices(GetLanguages())
                    .HighlightStyle(
                        new Style(
                            Color.Blue,
                            Color.White,
                            Decoration.Invert)));
    }
}
