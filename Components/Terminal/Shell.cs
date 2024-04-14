using PersonalWebsite.Components.Terminal.Commands;

namespace PersonalWebsite.Components.Terminal
{
    public class Shell
    {
        private readonly IDictionary<string, ITerminalCommand> _commands;
        public Shell(IDictionary<string, ITerminalCommand> commands)
        {
            _commands = commands;
        }

        private ITerminalCommand GetCommand(string commandName)
        {
            return _commands.TryGetValue(commandName, out ITerminalCommand value) ? value : new NotFoundCommand();
        }

        public ITerminalCommand Execute(string command)
        {
            var args = CommandLineParser.Parse(command);
            var commandName = args[0];
            var commandArgs = args.Skip(1).ToArray();
            var commandInstance = GetCommand(commandName);
            commandInstance.Execute(commandArgs);

            return commandInstance;
        }
    }
}
