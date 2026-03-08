// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class monster_CInitializer : MonoBehaviour
    {
        public monster_CStateEnum initialState = monster_CStateEnum.Hidden;

        void Awake()
        {
            monster_CStateStorage.Register(gameObject, initialState);
        }
    }
}
