using System;
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
        //Массив из методов движения, из которых раз в какой-то период времени будет выбираться и вызываться случайный.
        moving = new Moving[4];
        moving[0] = GoUp;
        moving[1] = GoDown;
        moving[2] = GoLeft;
        moving[3] = GoRight;

        //Случайно выбирается направление, куда пойдет животное сначала.
        //int randomIndex = rand.Next(0, 4);
        //moving[randomIndex].Invoke();
        direction = new Vector3(0.0f, 1.0f, 0.0f);

        waitTime = 2.0f;
        timer =  0.0f;

        rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {

            // Remove the recorded 2 seconds.
            timer -= waitTime;

            //Меняем waitTime на случайное число в каком-то диапазоне

            //Тут надо сделать так, чтобы вызывался случайных метод из GoUp(), GoDown(), GoLeft(), GoRight()
            int randomIndex = rand.Next(0,4);
            moving[randomIndex].Invoke();
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
}


