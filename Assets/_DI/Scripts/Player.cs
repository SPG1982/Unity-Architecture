using UnityEngine;


namespace DI
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField]
        private float speed = 2.0f;

        public void Move(Vector3 direction)
        {
            this.transform.position += direction * this.speed * Time.deltaTime;
        }
    }
}
