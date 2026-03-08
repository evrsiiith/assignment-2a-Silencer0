// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_5
{
    public class tall_grassInitializer : MonoBehaviour
    {
        public tall_grassStateEnum initialState = tall_grassStateEnum.Ready;

        void Awake()
        {
            tall_grassStateStorage.Register(gameObject, initialState);
        }
    }
}
