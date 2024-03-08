using UnityEngine;

namespace HW_3.Task_3
{
    public class Rotator : MonoBehaviour
    {
        private static Vector3 RotationAxis = new Vector3(0f, 1f, 0f);

        [SerializeField] private float _rotationSpeed;

        private void Update() => transform.Rotate(RotationAxis, _rotationSpeed);
    }
}