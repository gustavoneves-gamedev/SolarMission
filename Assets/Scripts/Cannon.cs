using UnityEngine;

public class Cannon : MonoBehaviour
{

    [SerializeField] private Transform gunPoint;
    [SerializeField] private GameObject dart;

    private float x, y;
    [SerializeField] private float rotationSpeed = 10f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
           // y = y + 1 * Time.deltaTime;
            Vector3 rotate = new Vector3(x, rotationSpeed * Time.deltaTime, 0);
            transform.Rotate(rotate);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //y = y - 1 * Time.deltaTime;
            Vector3 rotate = new Vector3(x, - rotationSpeed * Time.deltaTime, 0);
            transform.Rotate(rotate);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        //Vector3 rotate = new Vector3 (x, y, 0);
        
       // transform.Rotate(rotate);
    }

    public void Fire()
    {
        GameObject cannonBall = Instantiate(dart, gunPoint.position, gunPoint.rotation);
        cannonBall.GetComponent<PBody>().initialForce = new Vector3(0, 20f, 0);
        
    }

}
