// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class SpawnEncounter_player : MonoBehaviour
    {
        void Update()
        {
            if ((EncounterManagerStateStorage.Get(GameObject.Find("EncounterManager")) == EncounterManagerStateEnum.Idle && UserAlgorithms.IsPlayerMovingInGrass()))
            {
                UserAlgorithms.TriggerRandomEncounter();
            }
        }
    }
}
