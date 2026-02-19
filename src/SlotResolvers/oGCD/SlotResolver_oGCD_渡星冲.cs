using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using FireIV.src.Data;

namespace FireIV.src.SlotResolvers.oGCD
{
    public class SlotResolver_oGCD_渡星冲 : DragoonSlotResolver
    {
        protected override int CheckInner()
        {
            if (!DragoonSpells.渡星冲.GetSpell().IsReadyWithCanCast())
                return -1;
            return 0;
        }
        public override void Build(Slot slot)
        {
            slot.Add(DragoonSpells.渡星冲.GetSpell());
        }
    }
}
