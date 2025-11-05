using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP = 10;
    int hp;

    void Awake() => hp = maxHP;

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0) Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}