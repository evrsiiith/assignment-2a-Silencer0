// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class monster_AInitializer : MonoBehaviour
    {
        public monster_AStateEnum initialState = monster_AStateEnum.Hidden;

        void Awake()
        {
            monster_AStateStorage.Register(gameObject, initialState);
        }
    }
}
