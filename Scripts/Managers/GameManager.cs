using Breakout.Managers.Settings;
using System;
using TMPro;
using UnityEngine;

namespace Breakout.Managers
{

    public class GameManager : MonoBehaviour
    {
        #region Constants

        private const string m_resetGameMethodName = "ResetGame";
        private const float m_resetGameDelay = 3.0f;

        #endregion

        #region Serialized Properties

        [SerializeField] private TextMeshProUGUI m_playerLivesText, m_playerScoreText;
        [SerializeField] private GridSettings m_gridSettings;
        [SerializeField] private PlayerSettings m_playerSettings;
        [SerializeField] private Rigidbody2D m_ball;
        [SerializeField] private Transform m_paddle;
        [SerializeField] private int m_maxLives = 3;

        #endregion

        #region Private Properties

        private int m_playerLives, m_playerScore;

        #endregion

        #region Unity Lifecycle

        void Start()
        {
            m_ball.gameObject.SetActive(false);
            CreateBlockGrid(m_gridSettings);
            UpdateScoreInHUD();
            Invoke(m_resetGameMethodName, m_resetGameDelay);
        }

        #endregion

        #region Game State

        public void ResetPaddleAndBall()
        {
            m_paddle.transform.position = m_playerSettings.InitialPaddlePosition;
            m_paddle.localScale = m_playerSettings.InitialPaddleSize;
            m_ball.transform.position = m_playerSettings.InitialBallPosition;
        }

        private void CreateBlockGrid(GridSettings p_gridSettings)
        {
            for (int r = 0; r < p_gridSettings.GridSize.y; r++)
            {
                for (int c = 0; c < p_gridSettings.GridSize.x; c++)
                {
                    float xPosition = p_gridSettings.GridPosition.x + (p_gridSettings.BlockSize.x * c) + (p_gridSettings.BlockGap.x * (c -1));
                    float yPosition = p_gridSettings.GridPosition.y - (p_gridSettings.BlockSize.y * r) - (p_gridSettings.BlockGap.y * (r -1));
                    Vector3 blockPosition = new Vector3(xPosition, yPosition, 0);
                    
                    GameObject block = Instantiate(p_gridSettings.BlockPrefab, blockPosition, Quaternion.identity);
                    block.GetComponent<SpriteRenderer>().color = p_gridSettings.RowColors[r];
                    block.transform.localScale = p_gridSettings.BlockSize;
                }
            }
        }

        private void ResetGame()
        {
            m_ball.gameObject.SetActive(true);
            ResetPaddleAndBall();

            m_playerScore = 0;
            m_playerLives = m_maxLives;
            UpdateScoreInHUD();
        }

        #endregion

        #region UI Logic

        private void UpdateScoreInHUD()
        {
            m_playerLivesText.text = m_playerLives.ToString();
            m_playerScoreText.text = m_playerScore.ToString();
        }

        #endregion
    }

}
