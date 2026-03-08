// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class pokeballStateStorage
    {
        private static Dictionary<GameObject, pokeballStateEnum> stateTable = new();

        public static event Action<GameObject, pokeballStateEnum> OnStateChanged;

        public static void Register(GameObject obj, pokeballStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static pokeballStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == pokeballStateEnum.Ready;
        public static bool IsThrown(GameObject obj) => stateTable[obj] == pokeballStateEnum.Thrown;

        public static void SetReady(GameObject obj) => SetState(obj, pokeballStateEnum.Ready);
        public static void SetThrown(GameObject obj) => SetState(obj, pokeballStateEnum.Thrown);

        private static void SetState(GameObject obj, pokeballStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
