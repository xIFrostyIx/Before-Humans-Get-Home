using System.Collections;
using UnityEngine;

public class DestroyProp : MonoBehaviour
{
    public ItemCounter counter;
    public float targetYPosition = 2.0f;  // Set the desired y-axis position
    public float scaleUpSpeed = 1.0f;     // Speed of scaling
    public float moveSpeed = 2.0f;        // Speed of movement
    public AudioSource audioSource;       // AudioSource component for playing sound
    public AudioClip destroySound;        // Sound to play before the object is destroyed

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ScaleAndMoveBeforeDestroy());
        }
    }

    private IEnumerator ScaleAndMoveBeforeDestroy()
    {
        // Scale up the object
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * 1.1f;  // Scale up by 1.1 times
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime);
            elapsedTime += Time.deltaTime * scaleUpSpeed;
            yield return null;
        }
        transform.localScale = targetScale; // Ensure it's at the target scale

        // Move the object to the target Y position
        Vector3 targetPosition = new Vector3(transform.position.x, targetYPosition, transform.position.z);
        while (Mathf.Abs(transform.position.y - targetYPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Play the sound
        if (audioSource != null && destroySound != null)
        {
            audioSource.PlayOneShot(destroySound);
            // Wait for the sound to finish playing (you can use destroySound.length to wait the correct time)
            //yield return new WaitForSeconds(destroySound.length);
        }

        // Reduce the counter and update the UI
        counter.itemCount--;
        counter.UpdateCounterText();

        // Destroy the object
        Destroy(this.gameObject);
    }
}
