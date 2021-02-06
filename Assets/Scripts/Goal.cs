using UnityEngine;

public class Goal : MonoBehaviour
{
  public GameObject player;
  public GameObject global;
  private AnimateGirl animateGirl;
  private Global globalScript;

  void Start()
  {
    animateGirl = player.GetComponent<AnimateGirl>();
    globalScript = global.GetComponent<Global>();
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Ball"))
    {
      animateGirl.addPoint();
      globalScript.resetPosition();
      if (animateGirl.getPoint() >= animateGirl.maxPoints)
      {
        UnityEditor.EditorApplication.isPlaying = false;
      }

    }
  }
}