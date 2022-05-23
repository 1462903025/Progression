using CommandSystem;
using Exiled.Permissions.Extensions;
using System;
using System.Linq;

namespace XPSystem
{
    public class Leaderboard : ICommand
    {
        public string Command => "leaderboard";

        public static Leaderboard Instance { get; } = new Leaderboard();

        public string[] Aliases => new string[] { "lb" };

        public string Description => "按LV排序的玩家 (暴力程度). 用法: XPSystem leaderboard (amount)";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("xps.get"))
            {
                response = "您没有使用此命令的权限（xps.get）。";
                return false;
            }
            if (arguments.Count == 0)
            {
                response = GetTopPlayers(10);
                return true;
            }
            else
            {
                if (int.TryParse(arguments.At(0), out var amount) && amount > 0)
                {
                    response = GetTopPlayers(amount);
                    return true;
                }
                response = "无效的玩家 amount ";
                return false;
            }
        }

        private string GetTopPlayers(int amount)
        {
            var sorted = Main.Players.OrderByDescending(o => o.Value.LVL);
            var players = sorted.Take(amount);
            string str = "";
            int index = 1;
            foreach (var log in players)
            {
                str += $"{index}. ({log.Key}) : LVL{log.Value.LVL}, XP: {log.Value.XP}\n";
                index++;
            }
            return str;
        }
    }
}
