using Breakout.Managers;
using UnityEngine;

namespace Breakout.Controllers
{

    public class BallController : MonoBehaviour
    {
        #region Serialized Properties

        [SerializeField] private GameManager m_gameManager;
        [SerializeField] private string m_upperWallTag, m_SideWallTag, m_paddleTag;
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

        #region Collision Handling

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == m_upperWallTag)
            {
                m_direction = new Vector2(m_direction.x, -m_direction.y);
            }
            if (collision.gameObject.tag == m_SideWallTag)
            {
                m_direction = new Vector2(-m_direction.x, m_direction.y);
            }
            if (collision.gameObject.tag == m_paddleTag)
            {
                m_direction = new Vector2(-m_direction.x, m_direction.y);
            }
            //
            // if dead zone, die
            //
        }

        #endregion
    }

}