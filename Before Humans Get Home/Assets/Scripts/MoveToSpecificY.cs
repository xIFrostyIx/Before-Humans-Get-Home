using UnityEngine;

public class MoveToSpecificY : MonoBehaviour
{
    public float targetY = 0f; // The Y position to move the object to
    public float moveSpeed = 2f; // Speed at which the object moves to the target Y
    public float scaleSpeed = 2f; // Speed at which the object scales up
    public float targetScale = 1.5f; // Target scale factor
    public LayerMask groundLayer; // Layer mask for the ground layer

    private bool isTriggered = false;
    private bool isScaling = false;

    // Start is called before the first frame update
    void Start()
    {
        isScaling = false;
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            if (isScaling)
            {
                // Scale the object up smoothly to the target scale (1.2x)
                Vector3 currentScale = transform.localScale;
                Vector3 targetScaleVector = new Vector3(targetScale, targetScale, currentScale.z);

                // Smooth scaling
                transform.localScale = Vector3.MoveTowards(currentScale, targetScaleVector, scaleSpeed * Time.deltaTime);

                // Check if the object has reached the target scale
                if (Mathf.Approximately(transform.localScale.x, targetScale))
                {
                    isScaling = false; // Stop scaling
                    Debug.Log("Reached target scale.");
                }
            }
            else
            {
                // Smoothly move the object to the target Y position
                float currentY = transform.position.y;
                float newY = Mathf.MoveTowards(currentY, targetY, moveSpeed * Time.deltaTime);
                transform.position = new Vector2(transform.position.x, newY);

                // Debugging information
                Debug.Log($"CurrentY: {currentY}, TargetY: {targetY}, NewY: {newY}");

                // Check if the object has reached the target Y position
                if (Mathf.Approximately(newY, targetY))
                {
                    isTriggered = false; // Stop moving once we reach the target Y
                    Debug.Log("Reached target Y position.");
                }
            }
        }
    }

    // This function is called when another collider enters the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that triggered the collider has a specific tag (e.g., "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            // Start scaling first before moving
            isTriggered = true;
            isScaling = true;
        }
    }

    // Detect when the object hits the ground and handle collision logic
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object has been triggered
        if (isTriggered)
        {
            // Check if the object hits the ground
            if (IsGround(collision.gameObject))
            {
                // Stop the object from falling further by setting gravity to 0
                GetComponent<Rigidbody2D>().gravityScale = 0f;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                // Play the landing animation or other actions as needed
                // Example: animator.SetTrigger("Land");

                // Optionally: Set isTriggered to false if you want to reset state
                // isTriggered = false;
            }
            else
            {
                // Ignore collision with other objects while triggered
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
            }
        }
    }

    // Helper method to check if the object is the ground
    private bool IsGround(GameObject obj)
    {
        return ((1 << obj.layer) & groundLayer) != 0;
    }
}
