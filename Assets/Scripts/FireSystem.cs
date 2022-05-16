using System.Collections;
using UnityEngine;

public class FireSystem : MonoBehaviour
{
    [SerializeField] private Transform _createSource;
    [SerializeField] private Camera _playerViewCamera;
    [SerializeField] private PullObjects _bulletsPull;
    [SerializeField] private float _reloadTime;
    private bool _isAbleToFire;

    private void Start()
    {
        _isAbleToFire = true;
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0) && _isAbleToFire && Time.timeScale == 1)
        {
            _isAbleToFire = false;
            StartCoroutine(Reload());
            Ray ray = _playerViewCamera.ScreenPointToRay(Input.mousePosition);
            Vector3 bulletDirection = ray.GetPoint(20);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                bulletDirection = hit.point;
            }

            CreateBullet(bulletDirection);
        }
    }

    private void CreateBullet(Vector3 direction)
    {
        GameObject bulletObject = _bulletsPull.GetBulletFromPull();
        bulletObject.SetActive(true);
        bulletObject.transform.position = _createSource.position;
        BulletMovement bullet = bulletObject.GetComponent<BulletMovement>();
        bullet.Direction = direction;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(_reloadTime);
        _isAbleToFire = true;
    }

    public void RemoveAllCoroutines()
    {
        StopAllCoroutines();
    }
}
