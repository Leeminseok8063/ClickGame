using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public MainUIModule MainUIPanel;
    public bool isOpenPanel = false;
    public void Init()
    {
        GameObject mainModule = Instantiate(Resources.Load<GameObject>("Prefabs/03.Module/MainUIModule"));
        mainModule.transform.parent = transform;
        MainUIPanel = mainModule.GetComponent<MainUIModule>();
    }

    /// <summary>
    /// 패널을 팝업할때 호출하면 다른 입력을 차단합니다.
    /// </summary>
    /// <param name="state"></param>
    public void OpenPanel(bool state)
    {
        isOpenPanel = state;
    }
}
