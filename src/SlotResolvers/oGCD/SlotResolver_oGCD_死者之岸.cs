using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using FireIV.src.Data;
using FireIV.src.State;

namespace FireIV.src.SlotResolvers.oGCD
{
    public class SlotResolver_oGCD_死者之岸 : DragoonSlotResolver
    {
        protected override int CheckInner()
        {
            if (!DragoonSpells.死者之岸.GetSpell().IsReadyWithCanCast())
                return (int)CheckResult.NotReady;
            if (DragoonState.Instance.GetElapsedGCD > 1800)
                return (int)CheckResult.GcdWindowPassed;
            return (int)CheckResult.Ok;
        }
        public override void Build(Slot slot)
        {
            slot.Add(DragoonSpells.死者之岸.GetSpell());
        }
    }
}
