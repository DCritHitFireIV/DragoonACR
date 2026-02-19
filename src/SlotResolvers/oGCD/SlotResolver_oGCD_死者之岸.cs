using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using FireIV.src.Data;

namespace FireIV.src.SlotResolvers.oGCD
{
    public class SlotResolver_oGCD_死者之岸 : DragoonSlotResolver
    {
        protected override int CheckInner()
        {
            if (!DragoonSpells.死者之岸.GetSpell().IsReadyWithCanCast())
                return -1;
            return 0;
        }
        public override void Build(Slot slot)
        {
            slot.Add(DragoonSpells.死者之岸.GetSpell());
        }
    }
}
