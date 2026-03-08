// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_3
{
    public class ThrowPokeball_pokeball : MonoBehaviour
    {
        void Update()
        {
            if ((pokeballStateStorage.Get(GameObject.Find("pokeball")) == pokeballStateEnum.Ready && UserAlgorithms.IsThrowKeyPressed()))
            {
                UserAlgorithms.ThrowPokeball();
            }
        }
    }
}
