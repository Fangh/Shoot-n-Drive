using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;

    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed < maxSpeed)
            currentSpeed += acceleration * Time.deltaTime;

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime);
    }
}
