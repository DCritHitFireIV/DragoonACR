using AEAssist.CombatRoutine;
using FireIV.src.Opener;

namespace FireIV.src.Rotations
{
    public static class DragoonRotation
    {
        public static Rotation Build()
        {
            var rot = new Rotation(DragoonSlotList.All)
            {
                TargetJob = Jobs.Dragoon,
                AcrType = AcrType.Both,
                MinLevel = 100,
                MaxLevel = 100,
                Description = "龙骑炒股特化",
            };
            //起手选择
            rot.AddOpener(_ => new Opener_Dragoon_100_1Potion2RaidBuff_Default());
            return rot;
        }
    }
}
