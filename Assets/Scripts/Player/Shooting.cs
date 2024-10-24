using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public enum FireMode { blackHole, charging }

    public FireMode fireMode;

    [SerializeField] private int weaponMode;

    public int chargPower;

    private int maxCharge;


    PlayerControler playerControler;

    //maken een variable voor het punt van schieten en het object
    public Transform attackPoint;

    public GameObject projectile;


    private void Awake()
    {
        playerControler = new PlayerControler();

        playerControler.PCInputmanager.Switch.Enable();
        playerControler.PCInputmanager.Switch.performed += Switch_performed;
        playerControler.PCInputmanager.Shooting.Enable();
        playerControler.PCInputmanager.Shooting.performed += Shooting_performed;
    }

    private void Shooting_performed(InputAction.CallbackContext obj)
    {

        chargPower++;
        Instantiate(projectile, attackPoint.position, Quaternion.identity);
    }


    private void Switch_performed(InputAction.CallbackContext obj)
    {
        if (chargPower == maxCharge)
        {
            if(weaponMode >= System.Enum.GetValues(typeof(FireMode)).Length - 1)
            {
                weaponMode = 0;
            }
            else
            {
                weaponMode++;
            }
            Debug.Log(System.Enum.GetValues(typeof(FireMode)).Length);

            switch (weaponMode)
            {
                
                case 0:
                    fireMode = FireMode.blackHole;
                    break;
                case 1:
                    fireMode = FireMode.charging;
                    break;
                default:
                    fireMode = FireMode.charging;
                    break;
                    
            }
        }
    }

    private void Start()
    {
        fireMode = FireMode.charging;
        maxCharge = 2;
    }


    private void Update()
    {
        if (chargPower >= maxCharge)
        {
            chargPower = maxCharge;
        }
        if(chargPower <= maxCharge)
        {
            fireMode = FireMode.charging;
        }
    }
}
