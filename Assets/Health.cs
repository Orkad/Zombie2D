using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Health : NetworkBehaviour,IDamageable,IHealable,IKillable
{
    [SyncVar] public float MaxHealth;
    [SyncVar] public float CurrentHealth;
    [SyncVar] public float RegenerationPercent;
    [SyncVar] public bool IsDead;

    public ProgressBar healthBar;

    void Start()
    {
        CurrentHealth = MaxHealth;
        UpdateHealthBar();
    }

    public void Damage(float amount)
    {
        if (IsDead)
            return;
        if (amount >= CurrentHealth)
            Die();
        else
            CurrentHealth -= amount;
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        if (IsDead)
            return;
        if (amount + CurrentHealth >= MaxHealth)
            CurrentHealth = MaxHealth;
        else
            CurrentHealth += amount;
        UpdateHealthBar();
    }

    public void Die()
    {
        IsDead = true;
    }

    void UpdateHealthBar()
    {
        if (healthBar)
        {
            healthBar.maxValue = MaxHealth;
            healthBar.minValue = 0;
            healthBar.value = CurrentHealth;
        }
    }
}
