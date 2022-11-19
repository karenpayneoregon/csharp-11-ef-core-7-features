namespace GenericMathConsoleApp.Models
{
    public class MenuItem
    {
        /// <summary>
        /// Identifier
        /// </summary>
        /// <remarks>
        /// Create a menu item with a Id of -1 for exiting
        /// </remarks>
        public int Id { get; set; }
        /// <summary>
        /// Menu text to display
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Place to store something about the menu item
        /// </summary>
        public string Information { get; set; }
        /// <summary>
        /// Action to perform on selection
        /// </summary>
        public Action Action;
        public override string ToString() => Text;
    }
}
