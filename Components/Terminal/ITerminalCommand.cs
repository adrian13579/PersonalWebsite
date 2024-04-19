using Microsoft.AspNetCore.Components;

namespace PersonalWebsite.Components.Terminal
{
    /// <summary>
    /// Interface for terminal commands
    /// </summary>
    public interface ITerminalCommand
    {
        /// <summary>
        /// The name of the command
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Description of the command
        /// </summary>
        string Description { get; }
        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="args"></param>
        void Execute(string[] args);
        /// <summary>
        /// Render the command
        /// </summary>
        /// <returns></returns>
        RenderFragment Render();
    }
}
