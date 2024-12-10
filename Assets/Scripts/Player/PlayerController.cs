using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]

    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxSpeed = 5f;

    [Header("Weapon Positions")]

    [SerializeField] private Transform weaponSlotRight;
    [SerializeField] private Transform weaponSlotCenter;
    [SerializeField] private Transform weaponSlotLeft;

    private Rigidbody2D player_Rb;
    private Vector2 movement;
    private Weapon primaryWeapon;
    private Weapon secundaryWeapon;

    public Transform WeaponSlotRight { get => weaponSlotRight; }
    public Transform WeaponSlotCenter { get => weaponSlotCenter; }
    public Transform WeaponSlotLeft { get => weaponSlotLeft; }
    public Weapon PrimaryWeapon { set => primaryWeapon = value; }
    public Weapon SecundaryWeapon { set => secundaryWeapon = value; }

    private void Awake()
    {
        player_Rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
    }

    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (Input.GetMouseButton(0))
        {
            PrimaryWeaponShot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            SecundaryWeaponShot();
        }       
    }

    void FixedUpdate()
    {
        if (movement.magnitude == 0f)
        {
            player_Rb.velocity = Vector2.zero;
        }
        else if (player_Rb.velocity.magnitude > maxSpeed)
        {
            player_Rb.velocity = player_Rb.velocity.normalized * maxSpeed;
        }
        else
        {
            player_Rb.AddRelativeForce(movement * speed, ForceMode2D.Impulse);
        }
    }

    private void PrimaryWeaponShot()
    {
        if (primaryWeapon != null)
        {
            primaryWeapon.PerformShot();
        }
    }

    private void SecundaryWeaponShot()
    {
        if (secundaryWeapon != null)
        {
            secundaryWeapon.PerformShot();
        }
    }
}