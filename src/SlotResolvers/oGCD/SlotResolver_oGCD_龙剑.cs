using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using FireIV.src.Data;

namespace FireIV.src.SlotResolvers.oGCD
{
    public class SlotResolver_oGCD_龙剑 : DragoonSlotResolver
    {
        protected override int CheckInner()
        {
            if (!DragoonSpells.龙剑.GetSpell().IsReadyWithCanCast())
                    return -1;
            //if()
            return 0;
        }
        public override void Build(Slot slot)
        {
            slot.Add(DragoonSpells.龙剑.GetSpell());
        }
    }
}
