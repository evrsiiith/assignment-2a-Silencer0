// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class InitializeGame_player : MonoBehaviour
    {
        void Update()
        {
            if (UserAlgorithms.NeedsInitialization())
            {
                UserAlgorithms.SetupUI();
            }
        }
    }
}
