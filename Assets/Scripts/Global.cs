using UnityEngine;
using System.Collections;

public class Global : MonoBehaviour
{
    
    public GameObject goal;
    public GameObject ball;
    public GameObject player1;
    public GameObject player2;
    private AnimateGirl animateGirl1;
    private AnimateGirl animateGirl2;
    private Goal goalScript;
    private MoveBall moveBall;
    private Rigidbody2D moveBallRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        moveBall = ball.GetComponent<MoveBall>();
        moveBallRigidbody = ball.GetComponent<Rigidbody2D>();
        animateGirl1 = player1.GetComponent<AnimateGirl>();
        animateGirl2 = player2.GetComponent<AnimateGirl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetPosition()
    {
        StartCoroutine(resetPositionWithTime(3.0f));
    } 

    IEnumerator resetPositionWithTime(float time)
    {
        moveBallRigidbody.isKinematic = false;
        moveBallRigidbody.velocity = Vector3.zero;
        yield return new WaitForSeconds (time);
        moveBall.transform.position = moveBall.getInitialPosition();
        animateGirl1.transform.position = animateGirl1.getInitialPosition();
        animateGirl2.transform.position = animateGirl2.getInitialPosition();
    }
}
