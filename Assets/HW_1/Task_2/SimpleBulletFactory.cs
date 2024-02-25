using UnityEngine;

namespace HW_1.Task2
{
    /// <summary>
    /// �� ����� ������ ������� � ����������, ������� ����� ���� ������ �����
    /// </summary>
    public class SimpleBulletFactory : IBulletFactory
    {
        public void CreateBullet()
        {
            Debug.Log("Bullet shot!");
        }
    }
}