// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_1
{
    public static class EncounterManagerStateStorage
    {
        private static Dictionary<GameObject, EncounterManagerStateEnum> stateTable = new();

        public static event Action<GameObject, EncounterManagerStateEnum> OnStateChanged;

        public static void Register(GameObject obj, EncounterManagerStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static EncounterManagerStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsIdle(GameObject obj) => stateTable[obj] == EncounterManagerStateEnum.Idle;
        public static bool IsActive(GameObject obj) => stateTable[obj] == EncounterManagerStateEnum.Active;

        public static void SetIdle(GameObject obj) => SetState(obj, EncounterManagerStateEnum.Idle);
        public static void SetActive(GameObject obj) => SetState(obj, EncounterManagerStateEnum.Active);

        private static void SetState(GameObject obj, EncounterManagerStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
