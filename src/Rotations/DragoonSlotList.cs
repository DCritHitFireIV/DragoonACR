using AEAssist.CombatRoutine.Module;
using FireIV.src.SlotResolvers.GCD;
using FireIV.src.SlotResolvers.oGCD;

namespace FireIV.src.Rotations
{
    public static class DragoonSlotList
    {
        public static readonly List<SlotResolverData> All = [
            // ===============================
            // GCD 
            // ===============================
            new (new SlotResolver_GCD_樱花连(),SlotMode.Gcd),
            new (new SlotResolver_GCD_直刺连(),SlotMode.Gcd),
            // ===============================
            // Off-GCD 即将过期 0.7s
            // ===============================
            new (new SlotResolver_oGCD_天龙点睛_即将过期(),SlotMode.OffGcd),
            new (new SlotResolver_oGCD_幻象冲_即将过期(),SlotMode.OffGcd),
            // ===============================
            // Off-GCD Buff
            // ===============================
            new (new SlotResolver_oGCD_猛枪(),SlotMode.OffGcd),
            new (new SlotResolver_oGCD_战斗连祷(),SlotMode.OffGcd),
            new (new SlotResolver_oGCD_武神枪(),SlotMode.OffGcd),
            // ===============================
            // Off-GCD 120
            // ===============================

            // ===============================
            // Off-GCD 60
            // ===============================


            //CD类先进循环，防止后续双目标爆发卡CD，剩下跳跃按威力降序打出
            new (new SlotResolver_oGCD_高跳(),SlotMode.OffGcd),
            new (new SlotResolver_oGCD_龙剑(),SlotMode.OffGcd),
            new (new SlotResolver_oGCD_龙炎冲(),SlotMode.OffGcd),
            new (new SlotResolver_oGCD_坠星冲(),SlotMode.OffGcd),
            new (new SlotResolver_oGCD_渡星冲(),SlotMode.OffGcd),
            new (new SlotResolver_oGCD_死者之岸(),SlotMode.OffGcd),
            new (new SlotResolver_oGCD_龙炎升(),SlotMode.OffGcd),
            new (new SlotResolver_oGCD_天龙点睛(),SlotMode.OffGcd),
            new (new SlotResolver_oGCD_幻象冲(),SlotMode.OffGcd),
        ];
    }
}
