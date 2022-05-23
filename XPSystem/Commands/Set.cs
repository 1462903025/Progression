using CommandSystem;
using Exiled.Permissions.Extensions;
using System;

namespace XPSystem
{

    internal class Set : ICommand
    {
        public static Set Instance { get; } = new Set();
        public string Command => "set";
        public string[] Aliases => Array.Empty<string>();
        public string Description => $"在玩家的lvl变量中设置特定值。";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("xps.set"))
            {
                response = "您没有使用此命令的权限（xps.set）。";
                return false;
            }
            if (arguments.Count != 2)
            {
                response = "用法 : XPSystem set (UserId | in-game id) (int amount)";
                return false;
            }
            PlayerLog log;
            if (!Main.Players.TryGetValue(arguments.At(0), out log))
            {
                response = "用户ID不正确";
                return false;
            }
            if (int.TryParse(arguments.At(1), out int lvl) && lvl > 0)
            {
                log.LVL = lvl;
                response = $"{arguments.At(0)}'现在LVL是 {log.LVL}";
                log.ApplyRank();
                return true;
            }
            response = $"LVL amount 无效 : {lvl}";
            return false;
        }
    }
}
