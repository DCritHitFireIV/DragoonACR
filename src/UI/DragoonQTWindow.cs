using AEAssist.CombatRoutine.View.JobView;

namespace FireIV.src.UI
{
    public class DragoonQTWindow : JobViewWindow
    {
        /// <summary>
        /// 龙骑士QT窗口，方便后续添加职业特有功能
        /// </summary>
        public DragoonQTWindow(
            JobViewSave save,
            Action saveAction,
            string name)
            : base(save, saveAction, name)
        {
        }
    }
}
