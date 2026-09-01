namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res
{
    using UnityEngine;

    public class Clock
    {
        public delegate void TimeBasedDelegate();

        public static float ThirtyTickDeltaClock;
        public static float SecondDeltaClock;

        public static event TimeBasedDelegate TimeBasedEventSecond = () => { };
        public static event TimeBasedDelegate TimeBasedEventThirtyTick = () => { };

        public static void UpdateClocks()
        {
            SecondDeltaClock += Time.deltaTime;
            ThirtyTickDeltaClock += Time.deltaTime;

            if (SecondDeltaClock >= 1) TimeBasedEventSecond.Invoke();
            if (ThirtyTickDeltaClock >= 1f / 30f) TimeBasedEventThirtyTick.Invoke();

            SecondDeltaClock %= 1;
            ThirtyTickDeltaClock %= 1f / 30f;
        }
    }
}