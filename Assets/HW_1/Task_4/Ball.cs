using UnityEngine;

namespace HW_1.Task4
{
    [SelectionBase]
    public class Ball : MonoBehaviour
    {
        [field: SerializeField] public BallType Type { get; private set; }
    }
}
