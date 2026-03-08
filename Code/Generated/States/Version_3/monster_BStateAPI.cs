// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_3
{
    public static class monster_BStateAPI
    {
        public static bool Hidden(GameObject obj) => monster_BStateStorage.IsHidden(obj);
        public static bool Spawned(GameObject obj) => monster_BStateStorage.IsSpawned(obj);

        public static void SetHidden(GameObject obj) => monster_BStateStorage.SetHidden(obj);
        public static void SetSpawned(GameObject obj) => monster_BStateStorage.SetSpawned(obj);
    }
}
