using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _coinScore;
    
    private int _minHealth = 0;
    private int _maxHealth = 50;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public event UnityAction<int, int> HealthChanged;

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= _minHealth)
            Die();
    }

    public void ApplyHeal(int heal)
    {
        _currentHealth += heal;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth >= _maxHealth)
            _currentHealth = _maxHealth;
    }

    public void Collect() =>
        _coinScore++;

    private void Die() =>
        Destroy(gameObject);
}
