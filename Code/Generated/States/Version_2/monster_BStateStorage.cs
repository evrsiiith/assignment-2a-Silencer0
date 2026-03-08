// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_2
{
    public static class monster_BStateStorage
    {
        private static Dictionary<GameObject, monster_BStateEnum> stateTable = new();

        public static event Action<GameObject, monster_BStateEnum> OnStateChanged;

        public static void Register(GameObject obj, monster_BStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static monster_BStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsHidden(GameObject obj) => stateTable[obj] == monster_BStateEnum.Hidden;
        public static bool IsSpawned(GameObject obj) => stateTable[obj] == monster_BStateEnum.Spawned;

        public static void SetHidden(GameObject obj) => SetState(obj, monster_BStateEnum.Hidden);
        public static void SetSpawned(GameObject obj) => SetState(obj, monster_BStateEnum.Spawned);

        private static void SetState(GameObject obj, monster_BStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
