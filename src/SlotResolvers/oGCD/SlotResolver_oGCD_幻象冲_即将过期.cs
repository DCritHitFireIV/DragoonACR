using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using FireIV.src.Data;

namespace FireIV.src.SlotResolvers.oGCD
{
    public class SlotResolver_oGCD_幻象冲_即将过期 : DragoonSlotResolver
    {
        protected override int CheckInner()
        {
            if (!DragoonSpells.幻象冲.GetSpell().IsReadyWithCanCast())
                return -1;
            //if ()
            return 0;
        }
        public override void Build(Slot slot)
        {
            slot.Add(DragoonSpells.幻象冲.GetSpell());
        }
    }
}
