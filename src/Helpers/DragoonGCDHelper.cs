using FireIV.src.Entry;
using FireIV.src.State;
using static FireIV.src.State.DragoonState;

namespace FireIV.src.Helpers
{
    public static class DragoonGCDHelper
    {
        /// <summary>
        /// 根据目标樱花 DOT 剩余时间，决定樱花连直刺连
        /// </summary>
        /// <returns>Thrust or Chaos</returns>
        public static DragoonGCDRoute DecideAfterFirstGcd()
        {
            if (DragoonRotationEntry.QT.GetQt("只打直刺连"))
                return DragoonGCDRoute.Thrust;
            if (DragoonRotationEntry.QT.GetQt("只打樱花连"))
                return DragoonGCDRoute.Chaos;

            var buff = BuffState.Instance;
            const int ChaosRefreshThresholdMs = 14_000;
            if (buff.ChaosDotTimeLeftMs > ChaosRefreshThresholdMs)
            {
                return DragoonGCDRoute.Thrust;
            }
            return DragoonGCDRoute.Chaos;
        }
    }
}
