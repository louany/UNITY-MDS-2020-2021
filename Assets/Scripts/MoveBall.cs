using System;
using System.Collections;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
  public float Speed = 3;
  private DateTime _nextChangeTime = DateTime.Now;
  private SpriteRenderer sprite;
  public GameObject fx;
  private Color initialColor;
  private Vector3 initialPosition;
  void Start()
  {
    sprite = GetComponent<SpriteRenderer>();
    initialColor = sprite.color;
    initialPosition = transform.position;
  }
  void FixedUpdate()
  {
    if (_nextChangeTime < DateTime.Now)
    {
      sprite.color = Color.Lerp(sprite.color, initialColor, Time.deltaTime / .5f);
    }
    transform.localEulerAngles = new Vector3(0, 0, 0);
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Girl"))
    {
      sprite.color = new Color(2, 0, 0);
      _nextChangeTime = DateTime.Now.AddMilliseconds(150);
      StartCoroutine(instantiateFx());
    }
  }
  IEnumerator instantiateFx()
  {
      GameObject temporaryFx = Instantiate(fx,transform.position, Quaternion.identity);
      yield return new WaitForSeconds(0.2f);
      Destroy(temporaryFx);
  }
  public Vector3 getInitialPosition() {
    return this.initialPosition;
  }
}