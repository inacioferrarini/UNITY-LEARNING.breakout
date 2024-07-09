using UnityEngine;

namespace Breakout.Managers.Settings
{

    [CreateAssetMenu(fileName = "GridSettings", menuName = "Breakout/New Grid Settings", order = 1)]
    public class GridSettings : ScriptableObject
    {
        #region Serialized Properties

        [field: SerializeField] public GameObject BlockPrefab { get; private set; }
        [field: SerializeField] public Vector2 GridPosition { get; private set; }
        [field: SerializeField] public Vector2 GridSize { get; private set; }
        [field: SerializeField] public Vector2 BlockSize { get; private set; }
        [field: SerializeField] public Vector2 BlockGap { get; private set; }
        [field: SerializeField] public Color[] RowColors { get; private set; }

        #endregion
    }

}
