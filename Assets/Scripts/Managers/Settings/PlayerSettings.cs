using UnityEngine;

namespace Breakout.Managers.Settings
{

    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Breakout/New Player Settings", order = 2)]
    public class PlayerSettings : ScriptableObject
    {
        #region Serialized Properties

        [field: SerializeField] public Vector2 InitialPaddlePosition { get; private set; }
        [field: SerializeField] public Vector2 InitialPaddleSize { get; private set; }
        [field: SerializeField] public Vector2 InitialBallPosition { get; private set; }
        [field: SerializeField] public float SpeedIncreaseValue { get; private set; }
        [field: SerializeField] public int SpeedIncreasePoints { get; private set; }

        #endregion
    }

}
