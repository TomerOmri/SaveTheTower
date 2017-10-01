using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastZombie : Enemy
{
    private const int lives = 2;
    private const int speed = 5;
    private const int power = 8;
    private const int points = 150;


    // Use this for initialization
    void Start()
    {
        Lives = lives;
        Speed = speed;
        Power = power;
        Points = points;
    }
}
