using UnityEngine;

public class Cannon : MonoBehaviour
{

    [SerializeField] private Transform gunPoint;
    [SerializeField] private GameObject dart;

    private float x, y;
    [SerializeField] private float rotationSpeed = 10f;

    [SerializeField] private float initialSpeed = 50f;

    public bool canFire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameController.gameController.cannon = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
           // y = y + 1 * Time.deltaTime;
            Vector3 rotate = new Vector3(0, rotationSpeed * Time.deltaTime, 0);
            transform.Rotate(rotate);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //y = y - 1 * Time.deltaTime;
            Vector3 rotate = new Vector3(0, - rotationSpeed * Time.deltaTime, 0);
            transform.Rotate(rotate);
        }
        if (Input.GetKey(KeyCode.W))
        {
            // y = y + 1 * Time.deltaTime;
            Vector3 rotate = new Vector3(rotationSpeed * Time.deltaTime,0, 0);
            transform.Rotate(rotate);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //y = y - 1 * Time.deltaTime;
            Vector3 rotate = new Vector3(-rotationSpeed * Time.deltaTime,0, 0);
            transform.Rotate(rotate);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            Fire();
            GameController.gameController.mainCamera.isFollowingDart = true;
            canFire = false;
        }

        //Vector3 rotate = new Vector3 (x, y, 0);
        
       // transform.Rotate(rotate);
    }

    public void Fire()
    {
        GameObject cannonBall = Instantiate(dart, gunPoint.position, gunPoint.rotation);
        PBody ballPBody = cannonBall.GetComponent<PBody>();
        ballPBody.velocity = cannonBall.transform.forward * initialSpeed;
        ballPBody.totalForce = GameController.gameController.windForce;
        GameController.gameController.pController.AddToPhysicsPool(ballPBody);
        GameController.gameController.mainCamera.UpdateTargetToFollow(cannonBall.transform);
    }

}
