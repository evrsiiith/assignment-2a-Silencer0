// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public static class monster_CStateAPI
    {
        public static bool Hidden(GameObject obj) => monster_CStateStorage.IsHidden(obj);
        public static bool Spawned(GameObject obj) => monster_CStateStorage.IsSpawned(obj);

        public static void SetHidden(GameObject obj) => monster_CStateStorage.SetHidden(obj);
        public static void SetSpawned(GameObject obj) => monster_CStateStorage.SetSpawned(obj);
    }
}
