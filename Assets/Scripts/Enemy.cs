using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    public static UnityEvent OnDeath = new UnityEvent();
    public bool Dead;
    [SerializeField] private int _health;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _hpBar;
    [SerializeField] private Collider[] _ragDollColliders;
    [SerializeField] private Rigidbody[] _ragDollRigidbodyes;
    private Collider _collider;
    private int maxHealth;

    private void Start()
    {
        Initialize();
        maxHealth = _health;
    }

    private void Initialize()
    {
        _collider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
    }

    public void DisactivateAnimator()
    {
        Dead = true;
        OnDeath.Invoke();
        for (int i = 0; i < _ragDollColliders.Length; i++)
        {
            _ragDollColliders[i].enabled = true;
            _ragDollRigidbodyes[i].isKinematic = false;
        }
        _collider.enabled = false;
        _animator.enabled = false;
        _hpBar.parent.gameObject.SetActive(false);
    }

    public void GetDamage()
    {
        if (_health > 0)
        {
            _health--;
            float health = _health;
            _hpBar.localScale = new Vector3(health / maxHealth, 1, 1);
            _hpBar.localPosition = new Vector3((1 - _hpBar.localScale.x) / 2, 0, 0);
            if (_health <= 0)
                DisactivateAnimator();
        }
    }
}
