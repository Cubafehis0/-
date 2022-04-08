using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework;
using Singleton;
public class StartCanvas : BaseView
{
    private void Start()
    {
    }
    public void Click2NewGame()
    {
        SoundManager.instance.PlayMusic("BtnClick");
        PlayerDataMgr.Instance.NewGame();
        SceneJump.instance.Jump(SceneType.Game);
    }
    public void Click2MusicSetting()
    {
        SoundManager.instance.PlayMusic("BtnClick");
        Singleton<ContextManager>.Instance.Push(new BaseContext(UIType.MusicSettingPanel));
    }
}
