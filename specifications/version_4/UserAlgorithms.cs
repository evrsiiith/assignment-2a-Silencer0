using UnityEngine;
using UnityEngine.UI; 
using VReqDV;

namespace Version_4
{
    public static class UserAlgorithms
    {
        public static int caughtCount = 0;
        public static GameObject activeMonster = null;
        public static bool isEncounterActive = false;
        public static bool isInitialized = false;
        public static Text uiText = null;

        // --- 0. INITIALIZATION & UI ---
        public static bool NeedsInitialization() { return !isInitialized; }
        
        public static void SetupUI()
        {
            isInitialized = true;

            GameObject player = GameObject.Find("player");
            if (player != null)
            {
                Rigidbody playerRb = player.GetComponent<Rigidbody>();
                if (playerRb != null)
                {
                    playerRb.constraints = RigidbodyConstraints.FreezeRotation;
                }
            }
            
            GameObject canvasObj = new GameObject("ScoreCanvas");
            Canvas canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
            
            GameObject textObj = new GameObject("ScoreText");
            textObj.transform.SetParent(canvasObj.transform, false);
            uiText = textObj.AddComponent<Text>();
            
            uiText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            uiText.fontSize = 28;
            uiText.color = Color.white;
            uiText.alignment = TextAnchor.UpperLeft;
            
            Shadow shadow = textObj.AddComponent<Shadow>();
            shadow.effectColor = Color.black;
            
            uiText.text = "Pokemon Caught: 0\nStatus: Exploring...";
            
            RectTransform rect = uiText.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0, 1);
            rect.anchorMax = new Vector2(0, 1);
            rect.pivot = new Vector2(0, 1);
            rect.anchoredPosition = new Vector2(20, -20);
            rect.sizeDelta = new Vector2(600, 100);
        }

        public static void UpdateUI(string status)
        {
            if (uiText != null)
            {
                uiText.text = $"Pokemon Caught: {caughtCount}\nStatus: {status}";
            }
        }

        public static bool AlwaysTrue() { return true; }

        public static void UpdateCameraPosition()
        {
            GameObject player = GameObject.Find("player");
            if (player != null && Camera.main != null)
            {
                Camera.main.transform.position = player.transform.position + new Vector3(0, 12f, -10f);
                Camera.main.transform.rotation = Quaternion.Euler(50f, 0f, 0f);
            }
        }

        // --- 1. MOVEMENT & SPAWNING ---
        public static bool IsPlayerMovingInGrass()
        {
            GameObject player = GameObject.Find("player");
            GameObject grass = GameObject.Find("tall_grass");
            if (player == null || grass == null) return false;

            float speed = 10f * Time.deltaTime;
            bool isMoving = false;
            
            Vector3 moveDir = Vector3.zero;
            if (Input.GetKey(KeyCode.W)) moveDir += Vector3.forward;
            if (Input.GetKey(KeyCode.S)) moveDir += Vector3.back;
            if (Input.GetKey(KeyCode.A)) moveDir += Vector3.left;
            if (Input.GetKey(KeyCode.D)) moveDir += Vector3.right;

            if (moveDir != Vector3.zero)
            {
                isMoving = true;
                player.transform.Translate(moveDir.normalized * speed, Space.World);
                player.transform.rotation = Quaternion.LookRotation(moveDir);
            }

            if (isEncounterActive) return false;

            float distToGrass = Vector3.Distance(player.transform.position, grass.transform.position);
            if (isMoving && distToGrass < 8f) 
            {
                return Random.Range(0f, 100f) < 1.0f;
            }
            return false;
        }

        public static void TriggerRandomEncounter()
        {
            isEncounterActive = true; 
            UpdateUI("A wild Pokemon appeared! Throw Pokeball (Space or Click)");

            string[] monsters = { "monster_A", "monster_B", "monster_C" };
            string chosen = monsters[Random.Range(0, 3)];
            activeMonster = GameObject.Find(chosen);
            GameObject player = GameObject.Find("player");

            if (activeMonster != null && player != null)
            {
                // FIXED: Instantly snap the player to face North (Up the screen) for the encounter
                player.transform.rotation = Quaternion.LookRotation(Vector3.forward);
                
                // FIXED: Always spawn the monster exactly North of the player
                activeMonster.transform.position = player.transform.position + Vector3.forward * 6f;
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
                // FIXED: Force the throw direction to be strict world-forward (North)
                Vector3 throwDir = Vector3.forward;
                
                pokeball.transform.position = player.transform.position + throwDir * 1.5f + Vector3.up;
                var rb = pokeball.GetComponent<Rigidbody>();
                
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.velocity = Vector3.zero;
                    
                    // Launch straight ahead
                    rb.AddForce((throwDir + Vector3.up * 0.4f) * 12f, ForceMode.Impulse);
                }
                StateAccessor.SetState("pokeball", "thrown", pokeball, "Version_4");
            }
        }

        // --- 3. CAPTURE LOGIC ---
        public static bool DidPokeballHitMonster()
        {
            GameObject pokeball = GameObject.Find("pokeball");
            GameObject player = GameObject.Find("player");
            
            if (pokeball != null && activeMonster != null)
            {
                float dist = Vector3.Distance(pokeball.transform.position, activeMonster.transform.position);
                if (dist < 1.5f) return true; 
            }
            
            // FIXED: If the ball hits the ground OR flies too far away, instantly reset it so you can throw again
            if (pokeball != null && player != null)
            {
                float distFromPlayer = Vector3.Distance(pokeball.transform.position, player.transform.position);
                if (pokeball.transform.position.y < 0.2f || distFromPlayer > 15f)
                {
                    ResetPokeball(pokeball);
                }
            }
            return false;
        }

        public static void ResolveCapture()
        {
            bool caught = Random.Range(0f, 100f) < 60f;

            if (caught)
            {
                caughtCount++;
                UpdateUI("Gotcha! Pokemon was caught! (Exploring...)");
            }
            else
            {
                UpdateUI("Oh no! The Pokemon broke free and fled! (Exploring...)");
            }

            if (activeMonster != null)
            {
                activeMonster.transform.position = new Vector3(0, -10, 0); 
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
                StateAccessor.SetState("pokeball", "ready", pokeball, "Version_4");
            }
        }
    }
}