using UnityEngine;

public class MovingObstacle : Obstacle
{
    [SerializeField] private float slideSpeed = 2f;
    [SerializeField] private float xRange = 2f;
    private int m_Direction = 1;

    protected override void Move()
    {
        base.Move();
        if (transform.position.x <= -xRange)
        {
            m_Direction = -1;
        }
        else if (transform.position.x >= xRange)
        {
            m_Direction = 1;
        }
        transform.Translate(Vector3.right * (float)m_Direction * slideSpeed * Time.deltaTime);
    }
}
