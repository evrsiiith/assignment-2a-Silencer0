// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_3
{
    public class SpawnEncounter_player : MonoBehaviour
    {
        void Update()
        {
            if (UserAlgorithms.IsPlayerMovingInGrass())
            {
                UserAlgorithms.TriggerRandomEncounter();
            }
        }
    }
}
