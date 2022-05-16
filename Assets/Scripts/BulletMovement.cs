using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector3 Direction { get => _direction; set => _direction = value; }
    private Vector3 _direction;
    [SerializeField] private float _speed;
    [SerializeField] private float _removeTime;

    private void Update()
    {
        if(gameObject.activeInHierarchy)
            transform.position = Vector3.MoveTowards(transform.position, _direction, _speed * Time.deltaTime);
    }

    private void RemoveBullet()
    {
        PullObjects.ReturnToBulletPull(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        RemoveBullet();
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.GetDamage();
        }
    }

    private void OnEnable()
    {
        Invoke("RemoveBullet", _removeTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
