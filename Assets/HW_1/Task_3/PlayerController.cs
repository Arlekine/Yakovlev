using UnityEngine;


namespace HW_1.Task3
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController _character;
        [SerializeField] private float _speed;

        private Vector3 _lastMotionVector;

        private void Update()
        {
            var horizontalVector = Input.GetAxis("Horizontal");
            var verticalVector = Input.GetAxis("Vertical");

            if (horizontalVector != 0 || verticalVector != 0)
            {
                _lastMotionVector = new Vector3(horizontalVector, 0f, verticalVector);
                _lastMotionVector *= _speed * Time.deltaTime;

                transform.rotation = Quaternion.LookRotation(_lastMotionVector);
                _character.Move(_lastMotionVector);
            }
        }
    }
}
