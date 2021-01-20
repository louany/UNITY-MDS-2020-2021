using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator), typeof(Rigidbody2D))]
public class AnimateGirl : MonoBehaviour
{
  [Tooltip("Vitesse max en unités par secondes")]
  public int MaxSpeed = 4;

  [Tooltip("Définir la commande pour se déplacer vers le bas")]
  public KeyCode down;
  [Tooltip("Définir la commande pour se déplacer vers le haut")]
  public KeyCode up;
  [Tooltip("Définir la commande pour se déplacer vers la gauche")]
  public KeyCode left;
  [Tooltip("Définir la commande pour se déplacer vers la droite")]
  public KeyCode right;
  [Tooltip("Définir la commande pour rouler")]
  public KeyCode roll;
  private int points;
  [Tooltip("Nombre de points maximum")]
  public int maxPoints = 3;
  // Référence du sprite
  private SpriteRenderer spriteRenderer;
  // Référence de l'animator, permet de controller les mécaniques d'animation
  private Animator animator;
  // Référence du rigidbody2D
  private Rigidbody2D rigidbody2d;
  private Vector3 speed;
  private Vector3 initialPosition;

  // statics
  private static readonly int Speed = Animator.StringToHash("Speed");
  private static readonly int Roll = Animator.StringToHash("Roll");
  private static readonly int GoingUp = Animator.StringToHash("GoingUp");

  void Awake()
  {
    initialPosition = transform.position;
    spriteRenderer = GetComponent<SpriteRenderer>();
    animator = GetComponent<Animator>();
    rigidbody2d = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    var maxDistancePerFrame = MaxSpeed;
    Vector3 move = Vector3.zero;

    if (Input.GetKey(this.right))
    {
      move += Vector3.right * maxDistancePerFrame;
      spriteRenderer.flipX = false;
    }
    else if (Input.GetKey(this.left))
    {
      move += Vector3.left * maxDistancePerFrame;
      spriteRenderer.flipX = true;
    }

    if (Input.GetKey(this.up))
    {
      move += Vector3.up * maxDistancePerFrame;
    }
    else if (Input.GetKey(this.down))
    {
      move += Vector3.down * maxDistancePerFrame;
    }

    if (animator.GetBool(Roll)) animator.ResetTrigger(Roll);
    // Ici on utilise GetKeyDown, qui ne retourne true que la première frame où la touche est appuyée
    if (Input.GetKeyDown(this.roll))
    {
      animator.SetTrigger(Roll);
    }

    animator.SetBool(GoingUp, Input.GetKey(this.up));

    animator.SetFloat(Speed, move.magnitude * 10f);
    rigidbody2d.velocity = move;
  }
  public int getPoint()
  {
    return this.points;
  }

  public void addPoint()
  {
    this.points++;
    if (this.transform.childCount > this.points - 1)
    {
      this.transform.GetChild(this.points - 1).gameObject.SetActive(true);
    }
  }
    public Vector3 getInitialPosition() {
    return this.initialPosition;
  }
}