using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [HideInInspector] public bool isDead = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("WaterFlood"))
        {
            isDead = true;
            Debug.Log("Player is Dead!");
        }
    }
}
