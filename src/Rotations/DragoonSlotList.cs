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
            // Off-GCD
            // ===============================
            //new (new SlotResolver_oGCD_猛枪(),SlotMode.OffGcd),
            //new (new SlotResolver_oGCD_战斗连祷(),SlotMode.OffGcd),
            //new (new SlotResolver_oGCD_武神枪(),SlotMode.OffGcd),
            //new (new SlotResolver_oGCD_高跳(),SlotMode.OffGcd),
            //new (new SlotResolver_oGCD_龙剑(),SlotMode.OffGcd),
            //new (new SlotResolver_oGCD_龙炎冲(),SlotMode.OffGcd),
            //new (new SlotResolver_oGCD_渡星冲(),SlotMode.OffGcd),
            //new (new SlotResolver_oGCD_死者之岸(),SlotMode.OffGcd),
            //new (new SlotResolver_oGCD_龙炎升(),SlotMode.OffGcd),
            //new (new SlotResolver_oGCD_幻象冲(),SlotMode.OffGcd),
        ];
    }
}
