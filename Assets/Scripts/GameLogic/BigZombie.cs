using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigZombie : Enemy
{
    private const int lives = 4;
    private const int speed = 2;
    private const int power = 15;
    private const int points = 200;


    // Use this for initialization
    void Start()
    {
        Lives = lives;
        Speed = speed;
        Power = power;
        Points = points;
    }
}
