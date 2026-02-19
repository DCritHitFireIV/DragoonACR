using AEAssist;
using AEAssist.Helper;
using AEAssist.MemoryApi;

namespace FireIV.src.Util
{
    public static class SafeApi
    {
        /// <summary>
        /// 线程安全预留接口
        /// </summary>
        public static bool CanUseAction()
        {
            var condition = Core.Resolve<MemApiCondition>();
            if (condition.IsInCutscene())
                return false;
            return SpellHelper.CanUseAction();
        }
    }
}
