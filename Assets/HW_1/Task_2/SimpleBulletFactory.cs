using UnityEngine;

namespace HW_1.Task2
{
    /// <summary>
    /// Не хотел далеко уходить в реализацию, поэтому спавн пули просто логом
    /// </summary>
    public class SimpleBulletFactory : IBulletFactory
    {
        public void CreateBullet()
        {
            Debug.Log("Bullet shot!");
        }
    }
}