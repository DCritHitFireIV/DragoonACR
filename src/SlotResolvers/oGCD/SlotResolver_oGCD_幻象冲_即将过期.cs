using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using FireIV.src.Data;
using FireIV.src.State;

namespace FireIV.src.SlotResolvers.oGCD
{
    public class SlotResolver_oGCD_幻象冲_即将过期 : DragoonSlotResolver
    {
        protected override int CheckInner()
        {
            if (!DragoonSpells.幻象冲.GetSpell().IsReadyWithCanCast())
                return (int)CheckResult.NotReady;
            if (DragoonState.Instance.GetElapsedGCD > 1800)
                return (int)CheckResult.GcdWindowPassed;
            if (BuffState.Instance.MirageDiveTimeLeftMs > 700)
                return (int)CheckResult.DurationTooLong;
            return (int)CheckResult.Ok;
        }
        public override void Build(Slot slot)
        {
            slot.Add(DragoonSpells.幻象冲.GetSpell());
        }
    }
}
