using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    // Reference for UI Elements
    public Text CurrentCarText;
    public GameObject Credits;
    public Button Press;

    // Reference for GameObjects
    [SerializeField] private List<GameObject> _cars;
    public GameObject Stage;

    // Constant Values
    private const float RotationSpeed = 5.0f;

    // Current index for car selection
    private int _curIndex = 0;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            // Set Default Language
            PlayerPrefs.SetInt("Language", 0);
        }
    }

    void Start()
    {
        // Added Cars to List
       _cars = new List<GameObject>();
       foreach (Transform car in Stage.transform)
       {
           car.gameObject.SetActive(false);
           _cars.Add(car.gameObject);
       }

       // Active current Car
       _cars[_curIndex].SetActive(true);
       CurrentCarText.text = _cars[_curIndex].name;

        // Set Text
       Press.transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("Language") == 0 ? "Press Screen" : "Ekrana Dokunun";
    }

    void Update()
    {
        // Rotate stage
        Stage.transform.Rotate(Vector3.up, Time.deltaTime * RotationSpeed);
    }


    // Button Events
    public void ChangeCar(bool right)
    {

        // Changing car in UI Right and Left Button

        _cars[_curIndex].SetActive(false);
        if (right)
        {
            _curIndex++;
            if (_curIndex > _cars.Count - 1)
                _curIndex = 0;
        }
        else
        {
            _curIndex--;
            if (_curIndex < 0)
                _curIndex = _cars.Count - 1;
        }
        _cars[_curIndex].SetActive(true);
        CurrentCarText.text = _cars[_curIndex].name;
    }

    public void ChangeToScene()
    {
        // Change to AR scene
        SceneManager.LoadScene("ARScene");

        // Set current car name
        PlayerPrefs.SetInt("CurrentCar", _curIndex);
    }

    public void OpenCredits(bool yes)
    {
        // Open or Close Credits
        if (yes)
        {
            Credits.SetActive(true);
            Button linkedin = Credits.transform.GetChild(1).GetComponent<Button>();
            Button github = Credits.transform.GetChild(2).GetComponent<Button>();   

            // Add Listener
            linkedin.onClick.AddListener(()=> Application.OpenURL("https://www.linkedin.com/in/onurozler/"));
            github.onClick.AddListener(()=> Application.OpenURL("https://github.com/onurozler"));
        }
        else
        {
            Credits.SetActive(false);
        }
    }
    // Change Language
    public void ChangeLanguage(bool eng)
    {
        PlayerPrefs.SetInt("Language", eng ? 0 : 1);
        Press.transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("Language") == 0 ? "Press Screen" : "Ekrana Dokunun";
    }
}
