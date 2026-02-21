using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using FireIV.src.Data;
using FireIV.src.State;

namespace FireIV.src.SlotResolvers.oGCD
{
    public class SlotResolver_oGCD_坠星冲 : DragoonSlotResolver
    {
        protected override int CheckInner()
        {
            // 单插独占窗口
            if (!DragoonSpells.坠星冲.GetSpell().IsReadyWithCanCast())
                return (int)CheckResult.NotReady;
            if (DragoonState.Instance.GetElapsedGCD > 800)
                return (int)CheckResult.OGcdNotAligned;
            return (int)CheckResult.Ok;
        }
        public override void Build(Slot slot)
        {
            AI.Instance.BattleData.CurrGcdAbilityCount = 1;
            slot.Add(DragoonSpells.坠星冲.GetSpell());
        }
    }
}
