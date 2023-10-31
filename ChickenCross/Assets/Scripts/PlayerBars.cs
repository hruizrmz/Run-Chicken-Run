// Reference:
//  How to make a HEALTH BAR in Unity! by Brackeys - https://www.youtube.com/watch?v=BLfNP4Sc_iA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBars : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    private int maxHealth = 100;
    private int currentHealth;
    [SerializeField] private int carDamage = 20;

    [SerializeField] private Slider energySlider;
    private int maxEnergy = 1000;
    public int currentEnergy;

    [SerializeField] private Animator animator;
    public UIManager uiControl;

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        currentEnergy = maxEnergy;
        energySlider.maxValue = maxEnergy;
        energySlider.value = maxEnergy;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            uiControl.GameOver();
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }
    }

    public void ChangeHealth(int value)
    {
        currentHealth += value;
        healthSlider.value = currentHealth;

        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    public void ChangeEnergy(int cost) // +cost when gaining, -cost when losing
    {
        currentEnergy += cost;
        energySlider.value = currentEnergy;

        if (currentEnergy > maxEnergy) currentEnergy = maxEnergy;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Coop"))
        {
            uiControl.YouWon();
        }
        else if (collision.gameObject.CompareTag("Car"))
        {
            ChangeHealth(-carDamage);
        }
        else if (collision.gameObject.CompareTag("Food"))
        {
            ChangeEnergy(450);
            ChangeHealth(20);
            Destroy(collision.gameObject);
        }
    }
}
