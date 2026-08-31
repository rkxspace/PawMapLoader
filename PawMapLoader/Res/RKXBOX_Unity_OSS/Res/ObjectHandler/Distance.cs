namespace PawMapLoader.Res.RKXBOX_Unity_OSS.Res.ObjectHandler
{
    using System;
    using UnityEngine;

    public class Distance
    {
        public static double DistanceBetween(Vector3 a, Vector3 b) =>
            Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.z - a.z, 2) + Math.Pow(b.y - a.y, 2));

        public static double DistanceBetween(Vector2 a, Vector2 b) =>
            Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
    }
}