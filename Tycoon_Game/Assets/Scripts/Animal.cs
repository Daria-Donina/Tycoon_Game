using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveRight();
    }

    public void MoveRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
