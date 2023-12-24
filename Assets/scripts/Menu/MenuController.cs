using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject m_Setting;
    public enum GameState
    {
        Setting,
        Menu
    }
    private GameState m_GameState;

    // Start is called before the first frame update
    void Start()
    {
        // Ban đầu, chúng ta đặt trạng thái là "Menu"
        SetGameState(GameState.Menu);
    }

    // Update is called once per frame
    void Update()
    {
        // Nếu bạn muốn thực hiện một số xử lý trong Update, bạn có thể thêm code ở đây
    }

    public void SetGameState(GameState state)
    {
        m_GameState = state;

        // Tắt GameObject "Setting" nếu trạng thái là "Menu"
        m_Setting.SetActive(m_GameState == GameState.Setting);

    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void BtnSetting_Pressed()
    {
        SetGameState(GameState.Setting);
    }

    public void BtnBacktoMenu_Pressed()
    {
        // Khi ấn nút "BacktoMenu", chúng ta chuyển trạng thái về "Menu"
        SetGameState(GameState.Menu);
    }
}
