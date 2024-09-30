using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;


    public void Awake()
    {
        instance = this;
    }

    public float currentHealth, maxHealth;

    public Slider healthSlider;

    private PlayerFlashEffect flashEffect;

    public AudioSource deathSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;

        flashEffect = GetComponent<PlayerFlashEffect>();

        if (flashEffect != null)
        {
            Debug.Log("PlayerFlashEffect successfully assigned.");
        }
        else
        {
            Debug.LogError("PlayerFlashEffect is missing on this GameObject!");
        }
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.T))
        {
           TakeDamage(10f);
       } */
    }

    public void TakeDamage(float damage) 
    {
        currentHealth -= damage;

        if (flashEffect != null)
        {
            flashEffect.FlashScreen();
        }

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            currentHealth = 0;
            Die();
        }

        healthSlider.value = currentHealth;
    }
    // Function to handle player death
    private void Die()
    {
        Debug.Log("Player died at position: " + transform.position);
        if (deathSound != null) {
            deathSound.Play();
        }
        gameObject.SetActive(false);  
    }
}

