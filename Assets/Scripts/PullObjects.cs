using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullObjects : MonoBehaviour
{
    [SerializeField] private int _bulletsCount;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletParent;
    private List<GameObject> _bullets;

    private void Start()
    {
        CreateBulletsPull();
    }

    public void CreateBulletsPull()
    {
        _bullets = new List<GameObject>();
        for(int i = 0; i < _bulletsCount; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _bulletParent);
            bullet.SetActive(false);
            _bullets.Add(bullet);
        }
    }

    public GameObject GetBulletFromPull()
    {
        for(int i = 0; i < _bullets.Count; i++)
        {
            if(!_bullets[i].activeInHierarchy)
            {
                return _bullets[i];
            }
        }
        return null;
    }
    
    public static void ReturnToBulletPull(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
