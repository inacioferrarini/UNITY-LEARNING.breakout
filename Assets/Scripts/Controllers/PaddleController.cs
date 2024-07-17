using Breakout.Managers;
using UnityEngine;

namespace Breakout.Controllers
{

    public class PaddleController : MonoBehaviour
    {
        #region Serialized Properties

        [SerializeField] private GameManager m_gameManager;
        [SerializeField] private float m_speed = 4;
        [SerializeField] private float m_horizontalLimitMax = 4.5f, m_horizontalLimitMin = -4.5f;
        [SerializeField] private string m_axisName;

        #endregion

        #region Unity Lifecycle

        void Update()
        {
            if (!m_gameManager.IsUserInteractionEnabled)
            {
                return;
            }

            float move = Input.GetAxis(m_axisName) * m_speed;

            float nextPlayerPosition = transform.position.x + (move * Time.deltaTime);
            float clampedPositionX = Mathf.Clamp(nextPlayerPosition, m_horizontalLimitMin, m_horizontalLimitMax);

            transform.position = new Vector3(clampedPositionX, transform.position.y, transform.position.z);
        }

        #endregion
    }

}
