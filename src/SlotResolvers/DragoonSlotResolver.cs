using AEAssist.CombatRoutine.Module;
using AEAssist.Extension;
using FireIV.src.State;
using FireIV.src.Util;

namespace FireIV.src.SlotResolvers
{
    public abstract class DragoonSlotResolver : ISlotResolver
    {
        /// <summary>
        /// Resolver 基类，进行统一check以及state状态更新
        /// </summary>
        public int Check()
        {
            if (!SafeApi.CanUseAction())
                return -1;
            StateHub.Update();
            var state = DragoonState.Instance;
            if (!state.InCombat)
                return -1;
            //未来可能在上天情况提前开启猛枪
            if (state.Target?.CanAttack() != true)
                return -1;
            return CheckInner();
        }
        protected abstract int CheckInner();
        public abstract void Build(Slot slot);
    }
}
