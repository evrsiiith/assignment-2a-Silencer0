// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_2
{
    public static class tall_grassStateStorage
    {
        private static Dictionary<GameObject, tall_grassStateEnum> stateTable = new();

        public static event Action<GameObject, tall_grassStateEnum> OnStateChanged;

        public static void Register(GameObject obj, tall_grassStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static tall_grassStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == tall_grassStateEnum.Ready;

        public static void SetReady(GameObject obj) => SetState(obj, tall_grassStateEnum.Ready);

        private static void SetState(GameObject obj, tall_grassStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
