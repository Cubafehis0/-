using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFlowText : MonoBehaviour
{
#pragma warning disable CS0649 // 从未对字段“ScoreFlowText.flowText”赋值，字段将一直保持其默认值 null
    [SerializeField] Text flowText;
#pragma warning restore CS0649 // 从未对字段“ScoreFlowText.flowText”赋值，字段将一直保持其默认值 null

    public void Show(Vector3 startPos, string text, float height, float duration)
    {
        transform.position = startPos;
        flowText.text = text;
        transform.DOLocalMoveY(height, duration)
                 .SetRelative()
                 .OnComplete(() => GameObject.Destroy(gameObject));
    }
}
