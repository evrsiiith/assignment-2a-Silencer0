// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_3
{
    public static class playerStateStorage
    {
        private static Dictionary<GameObject, playerStateEnum> stateTable = new();

        public static event Action<GameObject, playerStateEnum> OnStateChanged;

        public static void Register(GameObject obj, playerStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static playerStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == playerStateEnum.Ready;

        public static void SetReady(GameObject obj) => SetState(obj, playerStateEnum.Ready);

        private static void SetState(GameObject obj, playerStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
