using AEAssist.CombatRoutine;
using AEAssist.CombatRoutine.View.JobView;
using FireIV.src.Rotations;
using FireIV.src.UI;

namespace FireIV.src.Entry
{
    /// <summary>
    /// 龙骑士 ACR 入口
    /// QT写在这里，Rotation里只放逻辑
    /// </summary>
    public class DragoonRotationEntry : IRotationEntry
    {
        public string AuthorName { get; set; } = "FireIV";
        public static DragoonQTWindow QT { get; private set; }
        public Rotation Build(string settingFolder)
        {
            QT = new DragoonQTWindow(new JobViewSave(), Save, "Dra");
            QT.AddQt("爆发药", false);
            QT.AddQt("只打直刺连", false, value =>
            {
                if (value) QT.SetQt("只打樱花连", false);
            });
            QT.AddQt("只打樱花连", false, value =>
            {
                if (value) QT.SetQt("只打直刺连", false);

            });
            return DragoonRotation.Build();
        }
        public void Dispose() { }
        public IRotationUI GetRotationUI() => QT;
        public void OnDrawSetting() { }
        private void Save() { }
    }
}
