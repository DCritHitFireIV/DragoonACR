using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using FireIV.src.Data;

namespace FireIV.src.SlotResolvers.oGCD
{
    public class SlotResolver_oGCD_龙炎升 : DragoonSlotResolver
    {
        protected override int CheckInner()
        {
            if (!DragoonSpells.龙炎升.GetSpell().IsReadyWithCanCast())
                return -1;
            return 0;
        }
        public override void Build(Slot slot)
        {
            slot.Add(DragoonSpells.龙炎升.GetSpell());
        }
    }
}
