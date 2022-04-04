using UnityEngine;
using UnityEngine.UI;


public class ScoreTipPanel12 : ScoreTipPanel
{
#pragma warning disable CS0649 // 从未对字段“ScoreTipPanel12.scoreText”赋值，字段将一直保持其默认值 null
    [SerializeField] Text scoreText;
#pragma warning restore CS0649 // 从未对字段“ScoreTipPanel12.scoreText”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“ScoreTipPanel12.timeStepText”赋值，字段将一直保持其默认值 null
    [SerializeField] Text timeStepText;
#pragma warning restore CS0649 // 从未对字段“ScoreTipPanel12.timeStepText”赋值，字段将一直保持其默认值 null

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

    }

    public override void SetTarget2Icon(string name)
    {

    }
}
