using System.Collections;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 6f;

    [SerializeField] private float direction;
    private int walking;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Walking());
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(direction * speed * Time.deltaTime, 0, 0);
    }

    IEnumerator Walking()
    {
        while (true)
        {
            for (walking = 0; walking < 5; walking++)
            {
                direction = -1;
                yield return new WaitForSeconds(0.1f);
            }
            

            direction = 0;

            for (walking = 0; walking < 5; walking++)
            {
                direction = 1;
                yield return new WaitForSeconds(0.1f);
            }
           

            direction = 0; 
        }
   
    }
}
