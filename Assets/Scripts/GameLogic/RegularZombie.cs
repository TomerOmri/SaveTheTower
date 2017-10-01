﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularZombie : Enemy {
	private const int lives = 2;
	private const int speed = 2;
	private const int power = 5;
    private const int points = 80;

    void Start(){
		Lives = lives;
		Speed = speed;
		Power = power;
        Points = points;
	}
}