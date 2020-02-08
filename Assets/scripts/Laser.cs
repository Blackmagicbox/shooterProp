using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float speed = 10; 

    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.up);

        if (transform.position.y >= 5.347)
        {
            DestroyImmediate(this.gameObject);
        }
    }
}
