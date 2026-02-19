using AEAssist.CombatRoutine.Module;
using AEAssist.Helper;
using FireIV.src.Data;

namespace FireIV.src.SlotResolvers.oGCD
{
    public class SlotResolver_oGCD_坠星冲 : DragoonSlotResolver
    {
        protected override int CheckInner()
        {
            // 单插独占窗口
            if (!DragoonSpells.坠星冲.GetSpell().IsReadyWithCanCast())
                return -1;
            if (AI.Instance.BattleData.CurrGcdAbilityCount != 2)
                return -1;
            return 0;
        }
        public override void Build(Slot slot)
        {
            AI.Instance.BattleData.CurrGcdAbilityCount = 1;
            slot.Add(DragoonSpells.坠星冲.GetSpell());
        }
    }
}
