using System;
using UnityEngine;

namespace HW_1.Task4
{
    /// <summary>
    /// ������ ������ ���� ����������� �������, ����� SetActive, ����� �� ���������.
    /// </summary>
    public class BallPopper : MonoBehaviour, IBallPopper
    {
        [SerializeField] private LayerMask _ballsLayer;
        [Min(10)][SerializeField] private float _castDistance = 10f;

        //�� ����� �������, ��� ��� �� ���������� ������� ��� �������, �� ��� ��� ������ �������� + ����� � �������� �����
        public event Action<Ball> BallPopped;

        public void Enable() => enabled = true;
        public void Disable() => enabled = false;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit raycastHit;
                var castRay = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(castRay, out raycastHit, _castDistance, _ballsLayer))
                {
                    var ball = raycastHit.collider.GetComponent<Ball>();

                    if (ball != null)
                    {
                        ball.gameObject.SetActive(false);
                        BallPopped?.Invoke(ball);
                    }
                }
            }
        }
    }
}