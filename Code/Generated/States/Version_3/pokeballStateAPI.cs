// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_3
{
    public static class pokeballStateAPI
    {
        public static bool Ready(GameObject obj) => pokeballStateStorage.IsReady(obj);
        public static bool Thrown(GameObject obj) => pokeballStateStorage.IsThrown(obj);

        public static void SetReady(GameObject obj) => pokeballStateStorage.SetReady(obj);
        public static void SetThrown(GameObject obj) => pokeballStateStorage.SetThrown(obj);
    }
}
