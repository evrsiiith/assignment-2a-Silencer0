// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class playerInitializer : MonoBehaviour
    {
        public playerStateEnum initialState = playerStateEnum.Ready;

        void Awake()
        {
            playerStateStorage.Register(gameObject, initialState);
        }
    }
}
