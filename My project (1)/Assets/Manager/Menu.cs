using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] TMP_InputField inputName;
    [SerializeField] int Cout;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame(int sceneCout)
    {
        GameManager.Name = inputName.text;
        Cout = sceneCout;
        Invoke("LoadSceneGamePlay", 0.2f);
        
    }
    void LoadSceneGamePlay()
    {
        SceneManager.LoadScene(Cout);
    }

}
