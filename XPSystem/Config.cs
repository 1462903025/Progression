using Exiled.API.Features;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace XPSystem
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("如果玩家启用了DNT，则向其显示提示。")]
        public string DNTHint { get; set; } = "当您在游戏选项中启用DNT时，我们无法统计您的等级信息！";
        [Description("已启用DNT的玩家的徽章。")]
        public Badge DNTBadge { get; set; } = new Badge
        {
            Name = "(DNT) 匿名者????",
            Color = "nickel"
        };

        [Description("(您可以添加自己的条目) Role1: Role2: XP player with Role1 gets for killing a person with Role2 ")]
        public Dictionary<RoleType, Dictionary<RoleType, int>> KillXP { get; set; } = new Dictionary<RoleType, Dictionary<RoleType, int>>()
        {
            [RoleType.ClassD] = new Dictionary<RoleType, int>()
            {
                [RoleType.Scientist] = 200,
                [RoleType.FacilityGuard] = 150,
                [RoleType.NtfPrivate] = 200,
                [RoleType.NtfSergeant] = 250,
                [RoleType.NtfCaptain] = 300,
                [RoleType.Scp049] = 500,
                [RoleType.Scp0492] = 100,
                [RoleType.Scp106] = 500,
                [RoleType.Scp173] = 500,
                [RoleType.Scp096] = 500,
                [RoleType.Scp93953] = 500,
                [RoleType.Scp93989] = 500,
            },
            [RoleType.Scientist] = new Dictionary<RoleType, int>()
            {
                [RoleType.ClassD] = 50,
                [RoleType.ChaosConscript] = 200,
                [RoleType.ChaosRifleman] = 200,
                [RoleType.ChaosRepressor] = 250,
                [RoleType.ChaosMarauder] = 300,
                [RoleType.Scp049] = 500,
                [RoleType.Scp0492] = 100,
                [RoleType.Scp106] = 500,
                [RoleType.Scp173] = 500,
                [RoleType.Scp096] = 500,
                [RoleType.Scp93953] = 500,
                [RoleType.Scp93989] = 500,
            }
        };

        [Description("如果一个玩家的团队获胜，他应该获得多少经验值。")]
        public int TeamWinXP { get; set; } = 250;

        [Description("提升一个级别需要多少经验。")]
        public int XPPerLevel { get; set; } = 1000;

        [Description("如果玩家获得XP，则显示一个小提示")]
        public bool ShowAddedXP { get; set; } = true;

        [Description("如果玩家晋级，则向其显示提示。")]
        public bool ShowAddedLVL { get; set; } = true;

        [Description("如果玩家提高了一个等级，需要显示什么提示。 (if ShowAddedLVL = false, 这无关紧要)")]
        public string AddedLVLHint { get; set; } = "新等级: <color=red>%level%</color>";

        [Description("(您可以添加自己的条目) 一个玩家因逃离而获得多少经验值")]
        public Dictionary<RoleType, int> EscapeXP { get; set; } = new Dictionary<RoleType, int>()
        {
            [RoleType.ClassD] = 500,
            [RoleType.Scientist] = 300
        };

        [Description("(您可以添加自己的条目) 等级和徽章。 %color%. 如果控制台中出现标记失败，请更改颜色，或删除括号等特殊字符。")]
        public Dictionary<int, Badge> LevelsBadge { get; set; } = new Dictionary<int, Badge>()
        {
            [0] = new Badge
            {
                Name = "Visitor",
                Color = "cyan"
            },
            [1] = new Badge
            {
                Name = "Junior",
                Color = "orange"
            },
            [5] = new Badge
            {
                Name = "Senior",
                Color = "yellow"
            },
            [10] = new Badge
            {
                Name = "Veteran",
                Color = "red"
            },
            [50] = new Badge
            {
                Name = "Nerd",
                Color = "lime"
            }
        };

        [Description("游戏中显示的徽章结构。 Variables: %lvl% - 这是等级. %badge% 在LevelsBadge中指定的获得的徽章. %oldbadge% - 基本游戏徽章 类似于在config-remoteadmin或全局徽章中指定的。可以为空。")]
        public string BadgeStructure { get; set; } = "(LVL %lvl% | %badge%) %oldbadge%";
        [Description("路径文件保存到。需要在linux上进行更改。")]
        public string SavePath { get; set; } = Path.Combine(Paths.Configs, @"Players.json");
        [Description("覆盖已经拥有等级的人的颜色")]
        public bool OverrideColor { get; set; } = false;
    }
}
