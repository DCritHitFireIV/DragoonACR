using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using Dalamud.Game.ClientState.Objects.Types;
using FireIV.src.Data;
using FireIV.src.Helpers;
using System.Reflection;

namespace FireIV.src.State
{
    public sealed class DragoonState
    {
        private static DragoonState _instance;
        public static DragoonState Instance => _instance ??= new();
        private DragoonState() { }

        private readonly MemApiSpell _spell = Core.Resolve<MemApiSpell>();
        private readonly MemApiBuff _buff = Core.Resolve<MemApiBuff>();
        private readonly MemApiSpellCastSuccess _castSuccess = Core.Resolve<MemApiSpellCastSuccess>();

        private long _lastUpdate;
        private const int UpdateInterval = 100; // ms
        /// <summary>
        /// 目标接口，是否存在目标以及目标是否可攻击
        /// SpellId接口，获取最新使用的成功连击技能Id和技能Id
        /// GCD序列状态存储，决定直刺连和樱花连
        /// </summary>
        public IBattleChara? Target { get; private set; }
        public bool InCombat { get; private set; }
        public uint GetLastComboSpellId { get; private set; }
        public uint GetLastSpellId { get; private set; }
        private DragoonGCDRoute _gcdRoute = DragoonGCDRoute.Chaos;
        public DragoonGCDRoute CurrentGCDRoute { get; private set; }

        public void Update()
        {
            var now = Environment.TickCount64;
            if (now - _lastUpdate < UpdateInterval)
                return;
            _lastUpdate = now;
            var me = Core.Me;
            if (me == null)
                return;

            Target = me.GetCurrTarget();
            InCombat = me.InCombat();
            GetLastComboSpellId = _spell.GetLastComboSpellId();
            GetLastSpellId = _castSuccess.LastGcd;
            CurrentGCDRoute = UpdateGCDRoute();
        }

        public enum DragoonGCDRoute
        {
            Thrust,       // 直刺连
            Chaos         // 樱花连
        }

        private DragoonGCDRoute UpdateGCDRoute()
        {
            if (GetLastComboSpellId is DragoonSpells.精准刺 or DragoonSpells.龙眼雷电)
            {
                _gcdRoute = DragoonGCDHelper.DecideAfterFirstGcd();
            }
            return _gcdRoute;
        }

    }
}
