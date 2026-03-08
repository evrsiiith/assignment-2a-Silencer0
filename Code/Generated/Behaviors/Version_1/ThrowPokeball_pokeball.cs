// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class ThrowPokeball_pokeball : MonoBehaviour
    {
        void Update()
        {
            if ((pokeballStateStorage.Get(GameObject.Find("pokeball")) == pokeballStateEnum.Ready && EncounterManagerStateStorage.Get(GameObject.Find("EncounterManager")) == EncounterManagerStateEnum.Active && UserAlgorithms.IsThrowKeyPressed()))
            {
                UserAlgorithms.ThrowPokeball();
            }
        }
    }
}
