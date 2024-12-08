using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;

    private float m_DistanceTravelled;

    private void Update()
    {
        if (MainManager.Instance.GameInProgress)
        {
            Move();
        }
    }

    protected virtual void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

        if (transform.position.z < -10f)
        {
            Destroy(gameObject);
        }
    }
}
