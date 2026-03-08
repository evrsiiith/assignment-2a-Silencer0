// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_2
{
    public class GroundInitializer : MonoBehaviour
    {
        public GroundStateEnum initialState = GroundStateEnum.Static;

        void Awake()
        {
            GroundStateStorage.Register(gameObject, initialState);
        }
    }
}
