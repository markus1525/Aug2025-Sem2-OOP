namespace SwinAdventure
{
    public class QuitCommand : Command
    {
        public QuitCommand() : base(new string[] { "quit" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            return "quit";
        }
    }
}