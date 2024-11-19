using UnityEngine;

public class BombPlanting : MonoBehaviour
{
    public GameObject bombPrefab;        // Prefab of the bomb to instantiate
    public GameObject locker;            // The locker to be destroyed
    public float bombTimer = 5f;         // Time in seconds before the bomb explodes (changeable)

    public AudioSource beepingAudio;     // Audio source for the beeping sound
    public AudioSource explosionAudio;   // Audio source for the explosion sound

    private bool bombPlanted = false;
    private GameObject plantedBomb;

    void Update()
    {
        // Check if the player presses 'E' to plant the bomb
        if (Input.GetKeyDown(KeyCode.E) && !bombPlanted&&!PauseMenu.isPaused)
        {
            bombPrefab.SetActive(true);
            PlantBomb();
        }
    }

    void PlantBomb()
    {
        // Plant the bomb at the player's position
        plantedBomb = Instantiate(bombPrefab, transform.position, transform.rotation);
        bombPlanted = true;

        // Play the beeping sound
        if (beepingAudio != null)
        {
            beepingAudio.Play();
        }

        // Start the countdown for the bomb to explode
        Invoke("ExplodeBomb", bombTimer);
    }

    void ExplodeBomb()
    {
        // Stop the beeping sound and play the explosion sound
        if (beepingAudio != null)
        {
           beepingAudio.Stop();
        }
        if (explosionAudio != null)
        {
            explosionAudio.Play();
        }

        // Destroy the locker when the bomb explodes
        if (locker != null)
        {
            Destroy(locker);
        }

        // Optionally, you can destroy the bomb itself after it explodes
        if (plantedBomb != null)
        {
            Destroy(plantedBomb);
        }

        bombPlanted = false;
    }
}
