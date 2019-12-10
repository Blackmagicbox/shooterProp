using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,5.95f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Transform transform1 = transform;
        transform1.Translate(Time.deltaTime * speed * Vector3.down);


        if (transform1.position.y <= -6.17)
        {
            transform1.position = new Vector3(Random.Range(-10f, 10f), 5.95f, 0);
        } ;
        
    }
}
