using UnityEngine;
using VReqDV;

namespace Version_2
{
    public static class UserAlgorithms
    {
        public static int caughtCount = 0;
        public static GameObject activeMonster = null;
        public static bool isEncounterActive = false; 

        // --- 1. MOVEMENT & SPAWNING ---
        public static bool IsPlayerMovingInGrass()
        {
            if (isEncounterActive) return false;

            GameObject player = GameObject.Find("player");
            GameObject grass = GameObject.Find("tall_grass");
            if (player == null || grass == null) return false;

            float speed = 10f * Time.deltaTime;
            bool isMoving = false;
            if (Input.GetKey(KeyCode.W)) { player.transform.Translate(Vector3.forward * speed); isMoving = true; }
            if (Input.GetKey(KeyCode.S)) { player.transform.Translate(Vector3.back * speed); isMoving = true; }
            if (Input.GetKey(KeyCode.A)) { player.transform.Translate(Vector3.left * speed); isMoving = true; }
            if (Input.GetKey(KeyCode.D)) { player.transform.Translate(Vector3.right * speed); isMoving = true; }

            float distToGrass = Vector3.Distance(player.transform.position, grass.transform.position);
            
            if (isMoving && distToGrass < 8f) 
            {
                return Random.Range(0f, 100f) < 1.0f;
            }
            return false;
        }

        public static void TriggerRandomEncounter()
        {
            Debug.Log("[PokemonCatcher] A wild Pokemon appeared in the grass!");
            isEncounterActive = true; 

            string[] monsters = { "monster_A", "monster_B", "monster_C" };
            string chosen = monsters[Random.Range(0, 3)];
            activeMonster = GameObject.Find(chosen);
            GameObject player = GameObject.Find("player");

            if (activeMonster != null && player != null)
            {
                activeMonster.transform.position = player.transform.position + player.transform.forward * 4f;
                // Note: Updated the namespace argument to Version_2
               // StateAccessor.SetState(chosen, "spawned", activeMonster, "Version_2");
            }
        }

        // --- 2. THROWING MECHANICS ---
        public static bool IsThrowKeyPressed()
        {
            if (!isEncounterActive) return false;
            return Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
        }

        public static void ThrowPokeball()
        {
            GameObject pokeball = GameObject.Find("pokeball");
            GameObject player = GameObject.Find("player");
            
            if (pokeball != null && player != null)
            {
                pokeball.transform.position = player.transform.position + Vector3.up;
                var rb = pokeball.GetComponent<Rigidbody>();
                
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.velocity = Vector3.zero;
                    
                    Vector3 direction = player.transform.forward;
                    if (activeMonster != null) 
                    {
                        direction = (activeMonster.transform.position - pokeball.transform.position).normalized;
                    }
                    
                    rb.AddForce((direction + Vector3.up * 0.4f) * 12f, ForceMode.Impulse);
                }
                StateAccessor.SetState("pokeball", "thrown", pokeball, "Version_2");
            }
        }

        // --- 3. CAPTURE LOGIC ---
        public static bool DidPokeballHitMonster()
        {
            GameObject pokeball = GameObject.Find("pokeball");
            
            if (pokeball != null && activeMonster != null)
            {
                float dist = Vector3.Distance(pokeball.transform.position, activeMonster.transform.position);
                if (dist < 1.5f) return true; 
            }
            
            if (pokeball != null && pokeball.transform.position.y < 0.2f)
            {
                ResetPokeball(pokeball);
            }
            return false;
        }

        public static void ResolveCapture()
        {
            bool caught = Random.Range(0f, 100f) < 60f;

            if (caught)
            {
                caughtCount++;
                Debug.Log($"[PokemonCatcher] Gotcha! Pokemon was caught! Total Caught: {caughtCount}");
            }
            else
            {
                Debug.Log("[PokemonCatcher] Oh no! The Pokemon broke free and fled!");
            }

            if (activeMonster != null)
            {
                activeMonster.transform.position = new Vector3(0, -10, 0); 
                //StateAccessor.SetState(activeMonster.name, "hidden", activeMonster, "Version_2");
                activeMonster = null;
            }

            GameObject pokeball = GameObject.Find("pokeball");
            ResetPokeball(pokeball);

            isEncounterActive = false; 
        }

        private static void ResetPokeball(GameObject pokeball)
        {
            if (pokeball != null)
            {
                pokeball.GetComponent<Rigidbody>().isKinematic = true;
                pokeball.transform.position = new Vector3(0, -10, 0); 
                StateAccessor.SetState("pokeball", "ready", pokeball, "Version_2");
            }
        }
    }
}