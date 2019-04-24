﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyHeart;

    void Update()
    {
        if (health > numOfHearts)
            health = numOfHearts;

        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullheart;
            else
                hearts[i].sprite = emptyHeart;

            if (i < numOfHearts)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }

    public void Damaged()
    {
        health --;
        if (health < numOfHearts)
            numOfHearts = health;
    }
}