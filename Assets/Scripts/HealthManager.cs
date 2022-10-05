using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;

     // Likewise, another event is used for health changes. The generic interface
    // to this is a fraction between 0-1 denoting the % health remaining.
    [SerializeField] private UnityEvent<float> onHealthChanged;

    [SerializeField] private UnityEvent onDeath;
    // Start is called before the first frame update

    private int _currentHealth;

    private int CurrentHealth
    {
        get => this._currentHealth;
        set
        {
            // Using a C# property to ensure the onHealthChanged event is
            // consistently fired when the health changes, and also to check if
            // the object has died (<= 0 health). It's not really different to
            // the concept of a "setter" as per OOP good practice, however, we
            // can still treat it like an integer variable (add, subtract, etc).
            this._currentHealth = value;
            var frac = this._currentHealth / (float)this.startingHealth;
            this.onHealthChanged.Invoke(frac);
            if (CurrentHealth <= 0) // Did we die?
            {
                // Let onDeath event listeners know that we died. 
                this.onDeath.Invoke();

                // Destroy ourselves.
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        ResetHealthToStarting();
    }

    public void ResetHealthToStarting()
    {
        CurrentHealth = this.startingHealth;
    }



    public void ApplyDamage(int damage)
    {
        this.CurrentHealth -= damage;
    }

    
}
