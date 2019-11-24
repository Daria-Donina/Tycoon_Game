﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Moving();

public class Animal : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 direction;

    private float waitTime;

    private float timer;

    private Moving[] moving;

    private System.Random rand;

    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();

        //Массив из методов движения, из которых раз в какой-то период времени будет выбираться и вызываться случайный.
        moving = new Moving[5];
        moving[0] = GoUp;
        moving[1] = GoDown;
        moving[2] = GoLeft;
        moving[3] = GoRight;
        moving[4] = StandStill;

        //Случайно выбирается направление, куда пойдет животное сначала.
        int randomIndex = rand.Next(0, 5);
        moving[randomIndex].Invoke();

        //Случайно выбирается промежуток времени, в течение которого животное не будет менять направление движения.
        waitTime = rand.Next(1, 6) + (float)rand.NextDouble();
        timer =  0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        timer += Time.deltaTime;

        //Проверяем, не прошло ли время waitTime. Если да, то животное меняет направление движения.
        if (timer > waitTime)
        {
            //Удаляем время waitTime.
            timer -= waitTime;

            //Случайно выбирается направление, куда пойдет животное.
            int randomIndex = rand.Next(0, 5);
            moving[randomIndex].Invoke();

            //Случайно выбирается промежуток времени, в течение которого животное не будет менять направление движения.
            waitTime = rand.Next(1, 6) + (float)rand.NextDouble();
        }
    }

    void GoUp()
    {
        //Меняем направление
        direction = new Vector3(0.0f, 1.0f, 0.0f);

        //Переключаем анимацию
    }

    void GoDown()
    {
        //Меняем направление
        direction = new Vector3(0.0f, -1.0f, 0.0f);

        //Переключаем анимацию
    }

    void GoLeft()
    {
        //Меняем направление
        direction = new Vector3(-1.0f, 0.0f, 0.0f);

        //Переключаем анимацию
    }

    void GoRight()
    {
        //Меняем направление
        direction = new Vector3(1.0f, 0.0f, 0.0f);

        //Переключаем анимацию
    }

    void StandStill()
    {
        //Меняем направление на нулевое.
        direction = new Vector3(0.0f, 0.0f, 0.0f);

        //Приостанавливаем анимацию
    }
}


