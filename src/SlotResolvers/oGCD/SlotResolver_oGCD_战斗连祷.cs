using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using FireIV.src.Data;

namespace FireIV.src.SlotResolvers.oGCD
{
    public class SlotResolver_oGCD_战斗连祷 : DragoonSlotResolver
    {
        protected override int CheckInner()
        {
            if (!DragoonSpells.战斗连祷.GetSpell().IsReadyWithCanCast())
                return -1;
            return 0;
        }
        public override void Build(Slot slot)
        {
            slot.Add(DragoonSpells.战斗连祷.GetSpell());
        }
    }
}
