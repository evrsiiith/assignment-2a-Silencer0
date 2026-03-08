// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_2
{
    public class CaptureCheck_pokeball : MonoBehaviour
    {
        void Update()
        {
            if ((pokeballStateStorage.Get(GameObject.Find("pokeball")) == pokeballStateEnum.Thrown && UserAlgorithms.DidPokeballHitMonster()))
            {
                UserAlgorithms.ResolveCapture();
            }
        }
    }
}
