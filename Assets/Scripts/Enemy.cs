using UnityEngine;
using UnityEngine.Events;

//ISP. Разделяем на интерфейсы, чтобы сущность не использовала лишние методы и свойства.
public interface IEnemy
{
    bool Dead { get; }

    void Death();
    void GetDamage();
}

public interface ICalculateble
{
    UnityEvent OnDeath { get; }
}

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour, IEnemy, ICalculateble
{
    public UnityEvent OnDeath => _onDeath;
    public bool Dead => _dead;
    private bool _dead;
    private UnityEvent _onDeath = new UnityEvent();
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

    public void Death()
    {
        _dead = true;
        _onDeath.Invoke();
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
                Death();
        }
    }
}
