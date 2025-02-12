#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
namespace GenericMathConsoleApp.Models
{
    public class MenuItem
    {
        /// <summary>
        /// Identifier
        /// </summary>
        /// <remarks>
        /// Create a menu item with an Id of -1 for exiting
        /// </remarks>
        public int Id { get; set; }
        /// <summary>
        /// Menu text to display
        /// </summary>
        public required string Text { get; set; }
        /// <summary>
        /// Place to store something about the menu item
        /// </summary>
        public string Information { get; set; }
        /// <summary>
        /// Defines the action to execute when selected.
        /// Each selection triggers this action.
        /// </summary>
        public required Action Action;
        public override string ToString() => Text;
    }
}
