using UnityEngine;
using System.Collections; // Required for IEnumerator
public class SprayCan : MonoBehaviour
{
    public AudioSource shakeAudio;       // Audio source for the bottle shaking sound
    public AudioSource sprayAudio;       // Audio source for the spray sound
    public float shakeDuration = 2f;     // Duration of the shaking sound before spraying
    public GameObject can;
    public GameObject logo;

    private bool isSpraying = false;

    void Update()
    {
        // Check if the left mouse button is clicked and the spray isn't already in progress
        if (Input.GetMouseButtonDown(0) && !isSpraying&&!PauseMenu.isPaused)
        {
            can.SetActive(true);
            StartCoroutine(SpraySequence());
        }
    }

    IEnumerator SpraySequence()
    {
        isSpraying = true;

        // Play the bottle shaking sound
        if (shakeAudio != null)
        {
            shakeAudio.Play();
            yield return new WaitForSeconds(shakeDuration);
        }

        // Play the spray sound
        if (sprayAudio != null)
        {
            sprayAudio.Play();
        }

        // Optional: Wait for the spray sound to finish before allowing another spray
        if (sprayAudio != null)
        {
            yield return new WaitForSeconds(sprayAudio.clip.length);
            logo.SetActive(true);
        }

        isSpraying = false;
    }
}
