using AEAssist;
using AEAssist.Extension;
using AEAssist.MemoryApi;
using FireIV.src.Data;

namespace FireIV.src.State
{
    public sealed class BuffState
    {
        private static BuffState _instance;
        public static BuffState Instance => _instance ??= new();
        private BuffState() { }

        private readonly MemApiBuff _buff = Core.Resolve<MemApiBuff>();
        private long _lastUpdate;
        private const int UpdateInterval = 100; // ms
        /// <summary>
        /// Buff接口，是否拥有以及剩余时间
        /// </summary>
        public int ChaosDotTimeLeftMs { get; private set; }
        public bool HasLanceCharge { get; private set; }
        public bool HasBattleLitany { get; private set; }
        public int LanceChargeTimeLeftMs { get; private set; }
        public int BattleLitanyTimeLeftMs { get; private set; }
        public bool HasLifeSurgeBuff { get; private set; }
        public int MirageDiveTimeLeftMs { get; private set; }

        public void Update()
        {
            var now = Environment.TickCount64;
            if (now - _lastUpdate < UpdateInterval)
                return;
            _lastUpdate = now;
            var me = Core.Me;
            if (me == null)
                return;
            var target = me.GetCurrTarget();
            // ===== 樱花缭乱 =====
            ChaosDotTimeLeftMs = _buff.HasAura(target, DragoonSpells.Buff.樱花缭乱, 0)
                ? _buff.GetAuraTimeleft(target, DragoonSpells.Buff.樱花缭乱, true)
                : 0;
            // ===== 猛枪 =====
            HasLanceCharge = _buff.HasAura(me, DragoonSpells.Buff.猛枪, 0);
            LanceChargeTimeLeftMs = HasLanceCharge
                ? _buff.GetAuraTimeleft(me, DragoonSpells.Buff.猛枪, true)
                : 0;
            // ===== 战斗连祷 =====
            HasBattleLitany = _buff.HasAura(me, DragoonSpells.Buff.战斗连祷, 0);
            BattleLitanyTimeLeftMs = HasBattleLitany
                ? _buff.GetAuraTimeleft(me, DragoonSpells.Buff.战斗连祷, true)
                : 0;
            // ===== 龙剑 =====
            HasLanceCharge = _buff.HasAura(me, DragoonSpells.Buff.龙剑, 0);
            // ===== 幻象冲预备 =====
            MirageDiveTimeLeftMs = _buff.HasAura(me, DragoonSpells.Buff.幻象冲预备, 0)
                ? _buff.GetAuraTimeleft(me, DragoonSpells.Buff.幻象冲预备, true)
                : 0;
        }
    }
}
