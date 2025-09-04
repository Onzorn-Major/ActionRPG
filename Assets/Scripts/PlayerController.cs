using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Gameplay gameplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameplay.player.ReceiveDamage(50);
        }

    }

}
