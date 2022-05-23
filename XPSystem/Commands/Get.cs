using CommandSystem;
using Exiled.Permissions.Extensions;
using System;

namespace XPSystem
{
    internal class Get : ICommand
    {
        public string Command => "get";

        public static Get Instance { get; } = new Get();

        public string[] Aliases => new string[] { };

        public string Description => "按用户ID获取玩家的XP和LVL值";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("xps.get"))
            {
                response = "您没有使用此命令的权限（xps.get）。";
                return false;
            }
            if (arguments.Count == 0)
            {
                response = "用法 : XPSystem get (userid)";
                return false;
            }
            PlayerLog log;
            if (!Main.Players.TryGetValue(arguments.At(0), out log))
            {
                response = "用户ID不正确";
                return false;
            }
            response = $"LVL: {log.LVL} | XP: {log.XP}";
            return true;
        }
    }
}
