// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_2
{
    public static class monster_AStateAPI
    {
        public static bool Hidden(GameObject obj) => monster_AStateStorage.IsHidden(obj);
        public static bool Spawned(GameObject obj) => monster_AStateStorage.IsSpawned(obj);

        public static void SetHidden(GameObject obj) => monster_AStateStorage.SetHidden(obj);
        public static void SetSpawned(GameObject obj) => monster_AStateStorage.SetSpawned(obj);
    }
}
