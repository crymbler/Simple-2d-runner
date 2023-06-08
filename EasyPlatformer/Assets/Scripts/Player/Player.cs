using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _coinScore;
    private int _minHealth = 0;

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= _minHealth)
            Die();
    }

    public void Collect() =>
        _coinScore++;

    private void Die() =>
        Destroy(gameObject);
}
