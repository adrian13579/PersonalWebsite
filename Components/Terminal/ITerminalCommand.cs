using Microsoft.AspNetCore.Components;

namespace PersonalWebsite.Components.Terminal
{
    public interface ITerminalCommand
    {
        void Execute(string[] args);
        RenderFragment Render();
    }
}
