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
            SpawnBlocks(m_gridSettings);
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

        private void SpawnBlocks(GridSettings p_gridSettings)
        {
            for (int r = 0; r < p_gridSettings.GridSize.y; r++)
            {
                for (int c = 0; c < p_gridSettings.GridSize.x; c++)
                {
                    SpawnBlock(p_gridSettings, r, c);
                }
            }
        }

        private void SpawnBlock(GridSettings p_gridSettings, int p_row, int p_column)
        {
            Vector3 blockPosition = GetBlockPosition(p_gridSettings, p_row, p_column);

            GameObject block = Instantiate(p_gridSettings.BlockPrefab, blockPosition, Quaternion.identity);
            block.GetComponent<SpriteRenderer>().color = GetBlockColor(p_gridSettings.RowColors, p_row);
            block.transform.localScale = p_gridSettings.BlockSize;
        }

        private Vector3 GetBlockPosition(GridSettings p_gridSettings, int p_row, int p_column)
        {
            float xPosition = p_gridSettings.GridPosition.x + (p_gridSettings.BlockSize.x * p_column) + (p_gridSettings.BlockGap.x * (p_column - 1));
            float yPosition = p_gridSettings.GridPosition.y - (p_gridSettings.BlockSize.y * p_row) - (p_gridSettings.BlockGap.y * (p_row - 1));
            return new Vector3(xPosition, yPosition, 0);
        }

        private Color GetBlockColor(Color[] p_rowColors, int p_row)
        {
            if (p_row >= p_rowColors.Length)
            {
                return Color.white;
            }
            return p_rowColors[p_row];
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
