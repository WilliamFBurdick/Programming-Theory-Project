using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float xBounds;

    private void Update()
    {
        if (MainManager.Instance.GameInProgress)
        {
            Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            float xPos = transform.position.x + movementInput.x * movementSpeed * Time.deltaTime;
            xPos = Mathf.Clamp(xPos, -xBounds, xBounds);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            MainManager.Instance.GameOver();
        }
    }
}
