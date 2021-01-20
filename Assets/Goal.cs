using UnityEngine;

public class Goal : MonoBehaviour
{
  public GameObject player;
  private AnimateGirl animateGirl;
  private Global globalScript;

  void Start()
  {
    animateGirl = player.GetComponent<AnimateGirl>();
  }

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Ball"))
    {
      animateGirl.addPoint();
      if (animateGirl.getPoint() >= animateGirl.maxPoints)
      {
        UnityEditor.EditorApplication.isPlaying = false;
      }

    }
  }
}