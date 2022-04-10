using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework;
using Singleton;
public class StartCanvas : BaseView
{
    public override void OnEnter(BaseContext context)
    {
        base.OnEnter(context);

        MusicManager.Instance.PlayMusic("Home");
    }
    public void Click2NewGame()
    {
        SoundManager.Instance.PlayMusic("BtnClick");
        PlayerDataMgr.Instance.NewGame();
        SceneJump.Instance.Jump(SceneType.Game);
    }
    public void Click2MusicSetting()
    {
        SoundManager.Instance.PlayMusic("BtnClick");
        Singleton<ContextManager>.Instance.Push(new BaseContext(UIType.MusicSettingPanel));
    }
}
