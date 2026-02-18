using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PawMapLoader.Abstractions
{
    public class AbUe
    {
        public static List<T> GetTypeAll<T>() where T : UnityEngine.Object
        {
            return Resources.FindObjectsOfTypeAll<T>().ToList();
        }
    }
}