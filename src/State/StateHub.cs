namespace FireIV.src.State
{
    public static class StateHub
    {
        /// <summary>
        /// 提供统一接口更新所有状态，避免重复调用
        /// </summary>
        public static void Update()
        {
            DragoonState.Instance.Update();
            BuffState.Instance.Update();
            //CooldownState.Instance.Update();
        }
    }
}
