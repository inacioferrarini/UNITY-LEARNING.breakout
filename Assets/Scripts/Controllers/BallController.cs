using Breakout.Items;
using Breakout.Managers;
using UnityEngine;

namespace Breakout.Controllers
{

    public class BallController : MonoBehaviour
    {
        #region Serialized Properties

        [SerializeField] private GameManager m_gameManager;
        [SerializeField] private string m_upperWallTag, m_SideWallTag, m_paddleTag, m_blockTag, m_deathZoneTag;
        [SerializeField] private float m_initialBallSpeed = 7f;

        #endregion

        #region Private Properties

        private float m_speed;
        private Vector2 m_direction;

        #endregion

        #region Unity Lifecycle

        void Start()
        {
            m_direction = new Vector2(1, 1);
            m_speed = m_initialBallSpeed;
        }

        void Update()
        {
            transform.Translate(m_direction * m_speed * Time.deltaTime);
        }

        #endregion

        #region State Management

        public void AddSpeed(float speed)
        {
            m_speed += speed;
        }

        #endregion

        #region Collision Handling

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == m_upperWallTag)
            {
                m_direction = new Vector2(m_direction.x, -m_direction.y);
            }
            else if (collision.gameObject.tag == m_SideWallTag)
            {
                m_direction = new Vector2(-m_direction.x, m_direction.y);
            }
            else if (collision.gameObject.tag == m_paddleTag)
            {
                m_direction = new Vector2(m_direction.x, -m_direction.y);
            }
            else if (collision.gameObject.tag == m_blockTag)
            {
                m_direction = new Vector2(-m_direction.x, -m_direction.y); // Add a random angle
                int points = collision.gameObject.GetComponent<Block>().Points;
                m_gameManager.AddPlayerScore(points);
                // Play Particle Effect
                Destroy(collision.gameObject);
            }
            else if (collision.gameObject.tag == m_deathZoneTag)
            {
                m_gameManager.PlayerDied();
            }
        }

        #endregion
    }

}