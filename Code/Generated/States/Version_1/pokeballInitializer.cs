// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class pokeballInitializer : MonoBehaviour
    {
        public pokeballStateEnum initialState = pokeballStateEnum.Ready;

        void Awake()
        {
            pokeballStateStorage.Register(gameObject, initialState);
        }
    }
}
