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
        public enum CheckResult
        {
            Ok = 0,
            // ======================
            // 通用失败（-1 ~ -9）
            // ======================
            NotReady = -1,                 // 技能不可用
            OutOfRange = -2,               // 不在施法距离
            GcdWindowPassed = -3,          // 超过可插窗口
            DurationTooLong = -4,          // 不在即将过期阈值内
            TargetCountMismatch = -5,      // 目标数量不符合要求
            OGcdNotAligned = -6,           // oGCD不符合单插条件
            BuffAlreadyExists = -7,        // Buff 已存在
            QtRequirementNotMet = -8,      // QT条件不满足
            // ======================
            // 龙骑特有（-10 ~ -19）
            // ======================
            NotInLanceCharge = -10,        
            // ======================
            // 龙剑特有（-20 ~ -29）
            // ======================
            InvalidComboState = -20,        
        }
        public abstract void Build(Slot slot);
    }
}
