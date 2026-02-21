using AEAssist;
using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using FireIV.src.Data;
using FireIV.src.State;
using static FireIV.src.State.DragoonState;


namespace FireIV.src.SlotResolvers.GCD
{
    /// <summary>
    /// 樱花连，切换逻辑在GCDHelper，根据目标樱花 DOT 剩余时间，决定樱花连直刺连
    /// </summary>
    public class SlotResolver_GCD_樱花连 : DragoonSlotResolver
    {
        protected override int CheckInner()
        {
            var state = DragoonState.Instance;
            if (state.CurrentGCDRoute != DragoonGCDRoute.Chaos)
                return -1;
            //if ((state.GetDistanceFromMe > DragoonState.ActionRangeMap[DragoonSpells.精准刺])) 
            //    return -1;
            return 0;
        }
        public override void Build(Slot slot)
        {
            var state = DragoonState.Instance;
            var spell = state.GetLastComboSpellId switch
            {
                DragoonSpells.精准刺 => DragoonSpells.螺旋击,
                DragoonSpells.龙眼雷电 => DragoonSpells.螺旋击,
                DragoonSpells.螺旋击 => DragoonSpells.樱花缭乱,
                DragoonSpells.樱花缭乱 => DragoonSpells.龙尾大回旋,
                DragoonSpells.龙尾大回旋 => DragoonSpells.龙牙龙爪,
                DragoonSpells.云蒸龙变 => DragoonSpells.精准刺,
                _ => DragoonSpells.精准刺
            };
            var realspell = Core.Resolve<MemApiSpell>().CheckActionChange(spell);
            slot.Add(realspell.GetSpell());
        }
    }
}