using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _heal = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.Collect();
            player.ApplyHeal(_heal);

            Destroy(gameObject);
        }
    }
}
