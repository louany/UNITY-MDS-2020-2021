using UnityEngine;

public class Global : MonoBehaviour
{
    
    private GameObject goal;
    private GameObject ball;
    private GameObject player;
    private AnimateGirl animateGirl;
    private Goal goalScript;
    private MoveBall moveBall;
    // Start is called before the first frame update
    void Start()
    {
        goalScript = goal.GetComponent<Goal>();
        moveBall = ball.GetComponent<MoveBall>();
        animateGirl = player.GetComponent<AnimateGirl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetPosition(){
        moveBall.transform.position = moveBall.getInitialPosition();
        animateGirl.transform.position = animateGirl.getInitialPosition();
    } 
}
