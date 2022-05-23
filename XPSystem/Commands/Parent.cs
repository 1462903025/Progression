using CommandSystem;
using System;

namespace XPSystem
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    internal class Parent : ParentCommand
    {
        public Parent() => LoadGeneratedCommands();
        public override string Command => "XPSystem";

        public override string[] Aliases => new string[] { "xps" };

        public override string Description => "操纵玩家的XP和LVL值。";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(Leaderboard.Instance);
            RegisterCommand(Set.Instance);
            RegisterCommand(Get.Instance);
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "用法: .xps (leaderboard | set | get)";
            return false;
        }
    }
}
