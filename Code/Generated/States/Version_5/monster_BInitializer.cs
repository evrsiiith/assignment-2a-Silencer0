// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_5
{
    public class monster_BInitializer : MonoBehaviour
    {
        public monster_BStateEnum initialState = monster_BStateEnum.Hidden;

        void Awake()
        {
            monster_BStateStorage.Register(gameObject, initialState);
        }
    }
}
