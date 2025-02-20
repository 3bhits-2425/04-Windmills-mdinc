using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject[]windmillsArr; //Array für all meine Windmühlen
    public TMP_Text keyInput; //space pressed tmp
     private float maxSpeed = 255f; //maximale Gescgwindigkeit
    [SerializeField] private Slider[] sliders;
    private float[] speeds = new float[3]; //geschwindigkeitsarray für farb intensität nötig
    [SerializeField] private GameObject colorBoard;
    private Renderer boardRenderer;
   [SerializeField] private Light[] windmillLights; // Array für die drei Lichter
    private int currentWindmill = 0;
    private bool[] isLocked = new bool[3];

    private void Start()
    {
        boardRenderer = colorBoard.GetComponent<Renderer>();
        speeds[0] = 0f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Space pressed Ausgabe
        {
            keyInput.text = "Space pressed";
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            keyInput.text = "";
        }
        if (currentWindmill <windmillsArr.Length && !isLocked[currentWindmill]) //starten der windmühlen
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
        UpdateLights();
    }
    private void Increase(float deltaTime) //geschwindigkeit steigt / sinkt
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
    private void Rotate() //rotation
    {
        for (int i = 0; i <windmillsArr.Length; i++)
        {
            if (speeds[i] > 0)
            {
               windmillsArr[i].transform.Rotate(Vector3.forward * speeds[i] * Time.deltaTime);
            }
        }
    }
    private void UpdateLights() //licht intensität
    {
        for (int i = 0; i < windmillLights.Length; i++) //schleife mit anzahl der windmills
        {
         if (windmillLights[i] != null)
            {
            // Berechne die neue Intensität (zwischen 0.2 und 3.0, abhängig von der Geschwindigkeit)
            float intensity = Mathf.Lerp(0.2f, 3f, speeds[i] / maxSpeed);
            windmillLights[i].intensity = intensity;
            }
        }
    }

     public void Lock(int index) //locken der windmühle
    {
        if (!isLocked[index])
        {
            isLocked[index] = true;
            currentWindmill++;
        }
    }
    public void ColorBoard() //farbe auf board übertragen
    {
    float redValue = Mathf.Clamp(speeds[0] / 255f, 0, 1);
    float greenValue = Mathf.Clamp(speeds[1] / 255f, 0, 1);
    float blueValue = Mathf.Clamp(speeds[2] / 255f, 0, 1);
    Debug.Log(speeds[0] + "Speeds 0");
    Debug.Log(redValue + "Red");
    
    Color newColor = new Color(redValue, greenValue, blueValue);

    // Ändere die Farbe des Boards
    boardRenderer.material.color = newColor;
    }
}

