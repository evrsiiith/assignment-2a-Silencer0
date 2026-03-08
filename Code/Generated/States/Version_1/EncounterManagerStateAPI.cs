// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public static class EncounterManagerStateAPI
    {
        public static bool Idle(GameObject obj) => EncounterManagerStateStorage.IsIdle(obj);
        public static bool Active(GameObject obj) => EncounterManagerStateStorage.IsActive(obj);

        public static void SetIdle(GameObject obj) => EncounterManagerStateStorage.SetIdle(obj);
        public static void SetActive(GameObject obj) => EncounterManagerStateStorage.SetActive(obj);
    }
}
