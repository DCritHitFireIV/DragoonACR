using AEAssist;
using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.Module;
using AEAssist.CombatRoutine.Module.Opener;
using AEAssist.Helper;
using AEAssist.MemoryApi;
using FireIV.src.Data;
using FireIV.src.Entry;

namespace FireIV.src.Opener
{
    /// <summary>
    /// 龙骑默认起手
    /// 支持自动精准刺，手动开怪精准刺，或者贯穿尖
    /// 1GCD猛枪爆发药，2GCD战斗连祷武神枪
    /// </summary>
    public sealed class Opener_Dragoon_100_1Potion2RaidBuff_Default : IOpener
    {
        public List<Action<Slot>> Sequence { get; } = new()
        {
            Gcd1,
            Gcd2
        };
        public void InitCountDown(CountDownHandler countDownHandler)
        {
        }
        private static void Gcd1(Slot slot)
        {
            // ===============================
            // GCD 
            // ===============================
            //if (Core.Resolve<MemApiSpellCastSuccess>().LastGcd == 0)
                slot.Add(DragoonSpells.精准刺.GetSpell());
            // ===============================
            // Off-GCD
            // ===============================
            slot.Add(DragoonSpells.猛枪.GetSpell());
            if (DragoonRotationEntry.QT.GetQt("爆发药"))
                slot.Add(Spell.CreatePotion());
            else
                AI.Instance.BattleData.CurrGcdAbilityCount = 1;
        }
        private static void Gcd2(Slot slot)
        {
            // ===============================
            // GCD 
            // ===============================
            if (Core.Resolve<MemApiSpellCastSuccess>().LastGcd == DragoonSpells.精准刺)
                slot.Add(DragoonSpells.螺旋击.GetSpell());
            else
                slot.Add(DragoonSpells.精准刺.GetSpell());
            // ===============================
            // Off-GCD
            // ===============================
            slot.Add(DragoonSpells.战斗连祷.GetSpell());
            slot.Add(DragoonSpells.武神枪.GetSpell());
        }
    }
}
