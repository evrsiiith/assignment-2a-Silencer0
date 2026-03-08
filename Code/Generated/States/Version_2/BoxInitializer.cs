// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_2
{
    public class BoxInitializer : MonoBehaviour
    {
        public BoxStateEnum initialState = BoxStateEnum.Idle;

        void Awake()
        {
            BoxStateStorage.Register(gameObject, initialState);
        }
    }
}
