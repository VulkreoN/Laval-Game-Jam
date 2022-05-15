using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 1;
    public int xp = 0;
    public float strenght = 1.0f;
    public float defense = 1.0f;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void AddXp(int value)
    {
        while (value != 0)
        {
            xp++;
            value--;
            if (xp > level * 100 + 10 * level)
            {
                xp = 0;
                level++;
                strenght = strenght * 1.25f;
                defense = defense * 1.25f;
            }
        }
    }
    
    public int getLevel()
    {
        return level;
    }

    public float getStrenght()
    {
        return strenght;
    }

    public float getDefense()
    {
        return defense;
    }
}
