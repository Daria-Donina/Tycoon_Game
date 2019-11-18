using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Vector3 direction;

    private float waitTime;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0.0f, 1.0f, 0.0f);
        waitTime = 2.0f;
        timer =  0.0f;
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

            GoDown(); //Тут надо сделать так, чтобы вызывался случайных метод из GoUp(), GoDown(), GoLeft(), GoRight()
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
        direction = new Vector3(1.0f, 1.0f, 0.0f);

        //Переключаем анимацию
    }
}
