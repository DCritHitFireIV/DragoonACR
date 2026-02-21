using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using FireIV.src.Data;
using FireIV.src.State;

namespace FireIV.src.SlotResolvers.oGCD
{
    public class SlotResolver_oGCD_龙剑 : DragoonSlotResolver
    {
        protected override int CheckInner()
        {
            if (!DragoonSpells.龙剑.GetSpell().IsReadyWithCanCast())
                return (int)CheckResult.NotReady;
            if (DragoonState.Instance.GetElapsedGCD > 1800)
                return (int)CheckResult.GcdWindowPassed;
            if (DragoonState.Instance.GetLastComboSpellId != DragoonSpells.龙牙龙爪 &&
               DragoonState.Instance.GetLastComboSpellId != DragoonSpells.龙尾大回旋 &&
               DragoonState.Instance.GetLastComboSpellId != DragoonSpells.前冲刺)
                return (int)CheckResult.InvalidComboState;
            if (Core.Resolve<MemApiBuff>().HasAura(Core.Me, DragoonSpells.Buff.龙剑, 0))
                return (int)CheckResult.BuffAlreadyExists;
            return (int)CheckResult.Ok;
        }
        public override void Build(Slot slot)
        {
            slot.Add(DragoonSpells.龙剑.GetSpell());
        }
    }
}
