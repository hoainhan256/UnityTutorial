using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static float point = 0;
    public static string Name;
    public static float volume = 1f;
    public static bool muteBool = true;
    [SerializeField] Slider sliderVolume;
    [SerializeField] TextMeshProUGUI pointText;
    [SerializeField] TextMeshProUGUI textName;
    [SerializeField] Toggle mute;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sliderVolume != null )
        {
            volume = sliderVolume.value;
        }
        if (mute != null )
        {
            muteBool = mute.isOn;
        }
        if (pointText != null)
        {
            pointText.text = point.ToString();
        }
       else
        {
            
        }
        Debug.Log(muteBool);
    }
   
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Đăng ký sự kiện
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Hủy đăng ký khi đối tượng bị xóa
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       
        pointText = GameObject.FindGameObjectWithTag("PointText")?.GetComponent<TextMeshProUGUI>();
        textName = GameObject.FindGameObjectWithTag("NamePlayer")?.GetComponent<TextMeshProUGUI>();
        sliderVolume = GameObject.Find("volume")?.GetComponent<Slider>();
        mute = GameObject.Find("mute")?.GetComponent<Toggle>();
        if (Name != null)
        {
            textName.text = Name;
        }
        
       
    }
}
