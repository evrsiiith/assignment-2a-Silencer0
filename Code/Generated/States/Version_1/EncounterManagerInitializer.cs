// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class EncounterManagerInitializer : MonoBehaviour
    {
        public EncounterManagerStateEnum initialState = EncounterManagerStateEnum.Idle;

        void Awake()
        {
            EncounterManagerStateStorage.Register(gameObject, initialState);
        }
    }
}
