using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] widmillsArr;
    public TMP_Text keyInput;
     [SerializeField] private Light[] lampLight; // Assign in Inspector
    [SerializeField] private float maxLightIntensity = 1f; // Maximum lamp brightness
    [SerializeField] private Slider[] sliders;
    [SerializeField] private GameObject colorBoard;

    private int currentWindmill = 0;
    private float[] speeds = new float[3];
    private bool[] isLocked = new bool[3];
    private float maxSpeed = 255f;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyInput.text = "Space pressed";
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            keyInput.text = "";
        }
        if (currentWindmill < widmillsArr.Length && !isLocked[currentWindmill])
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Increase(Time.deltaTime);
            }
            else
            {
                Decrease(Time.deltaTime);
            }
        }
        Rotate();
    }

    private void Increase(float deltaTime)
    {
        float newSpeed = Mathf.Clamp(speeds[currentWindmill] + (deltaTime * 100f), 0, maxSpeed);
        speeds[currentWindmill] = newSpeed;
        sliders[currentWindmill].value = newSpeed;
    }

    private void Decrease(float deltaTime)
    {
        if (!isLocked[currentWindmill])
        {
            float newSpeed = Mathf.Clamp(speeds[currentWindmill] - (deltaTime * 100), 0, maxSpeed);
            speeds[currentWindmill] = newSpeed;
            sliders[currentWindmill].value = newSpeed;
        }
    }

    private void Rotate()
    {
        for (int i = 0; i < widmillsArr.Length; i++)
        {
            if (speeds[i] > 0)
            {
                widmillsArr[i].transform.Rotate(Vector3.forward * speeds[i] * Time.deltaTime);
            }
        }
    }
    

    public void Lock(int index)
    {
        if (!isLocked[index])
        {
            isLocked[index] = true;
            currentWindmill++;
        }
    }

}

