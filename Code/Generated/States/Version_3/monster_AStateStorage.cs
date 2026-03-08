// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_3
{
    public static class monster_AStateStorage
    {
        private static Dictionary<GameObject, monster_AStateEnum> stateTable = new();

        public static event Action<GameObject, monster_AStateEnum> OnStateChanged;

        public static void Register(GameObject obj, monster_AStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static monster_AStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsHidden(GameObject obj) => stateTable[obj] == monster_AStateEnum.Hidden;
        public static bool IsSpawned(GameObject obj) => stateTable[obj] == monster_AStateEnum.Spawned;

        public static void SetHidden(GameObject obj) => SetState(obj, monster_AStateEnum.Hidden);
        public static void SetSpawned(GameObject obj) => SetState(obj, monster_AStateEnum.Spawned);

        private static void SetState(GameObject obj, monster_AStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
