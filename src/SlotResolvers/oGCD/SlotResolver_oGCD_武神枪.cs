using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using FireIV.src.Data;
using FireIV.src.State;

namespace FireIV.src.SlotResolvers.oGCD
{
    public class SlotResolver_oGCD_武神枪 : DragoonSlotResolver
    {
        protected override int CheckInner()
        {
            if (!DragoonSpells.武神枪.GetSpell().IsReadyWithCanCast())
                return (int)CheckResult.NotReady;
            if (DragoonState.Instance.GetElapsedGCD > 1800)
                return (int)CheckResult.GcdWindowPassed;
            return (int)CheckResult.Ok;
        }
        public override void Build(Slot slot)
        {
            slot.Add(DragoonSpells.武神枪.GetSpell());
        }
    }
}
