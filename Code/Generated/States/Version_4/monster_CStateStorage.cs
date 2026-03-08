// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class monster_CStateStorage
    {
        private static Dictionary<GameObject, monster_CStateEnum> stateTable = new();

        public static event Action<GameObject, monster_CStateEnum> OnStateChanged;

        public static void Register(GameObject obj, monster_CStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static monster_CStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsHidden(GameObject obj) => stateTable[obj] == monster_CStateEnum.Hidden;
        public static bool IsSpawned(GameObject obj) => stateTable[obj] == monster_CStateEnum.Spawned;

        public static void SetHidden(GameObject obj) => SetState(obj, monster_CStateEnum.Hidden);
        public static void SetSpawned(GameObject obj) => SetState(obj, monster_CStateEnum.Spawned);

        private static void SetState(GameObject obj, monster_CStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
