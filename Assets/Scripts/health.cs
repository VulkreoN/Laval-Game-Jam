using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public Slider slider;
    public int health_max = 100;
    public int current_health = 100;

    void Start()
    {
        slider.maxValue = health_max;
        slider.value = current_health;
    }
    public void SetMaxHealth(int value)
    {
        slider.maxValue = value;
        health_max = value;
    }

    public void SetHealth(int value)
    {
        slider.value = value;
        current_health = value;
        if (current_health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
