using UnityEngine;
using UnityEngine.UI;


public class ScoreTipPanel34 : ScoreTipPanel
{
#pragma warning disable CS0649 // 从未对字段“ScoreTipPanel34.scoreText”赋值，字段将一直保持其默认值 null
    [SerializeField] Text scoreText;
#pragma warning restore CS0649 // 从未对字段“ScoreTipPanel34.scoreText”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“ScoreTipPanel34.timeStepText”赋值，字段将一直保持其默认值 null
    [SerializeField] Text timeStepText;
#pragma warning restore CS0649 // 从未对字段“ScoreTipPanel34.timeStepText”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“ScoreTipPanel34.target2Text”赋值，字段将一直保持其默认值 null
    [SerializeField] Text target2Text;
#pragma warning restore CS0649 // 从未对字段“ScoreTipPanel34.target2Text”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“ScoreTipPanel34.target2Icon”赋值，字段将一直保持其默认值 null
    [SerializeField] Image target2Icon;
#pragma warning restore CS0649 // 从未对字段“ScoreTipPanel34.target2Icon”赋值，字段将一直保持其默认值 null


    public override void SetTimeOrStep(int value)
    {
        timeStepText.text = value.ToString();
    }

    public override void SetScoreText(string text)
    {
        scoreText.text = text;
    }

    public override void SetTarget2Text(string text)
    {
        target2Text.text = text;
    }

    public override void SetTarget2Icon(string name)
    {
        target2Icon.sprite = Resources.Load<Sprite>("Textures/" + name);
    }
}

