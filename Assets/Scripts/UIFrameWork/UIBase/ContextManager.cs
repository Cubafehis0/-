using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Singleton;
namespace UIFramework
{
    public class ContextManager: Stack<BaseContext>
    {
        private ContextManager()
        {
        }
        public new void Clear()
        {
            while(Count>0)
            {
                Pop();
            }
        }
        public new void Push(BaseContext nextContext)
        {
            if (Count != 0)
            {
                BaseContext curContext = Peek();
                BaseView curView = Singleton<UIManager>.Instance.GetSingleUI(curContext.ViewType).GetComponent<BaseView>();
                curView.OnPause(curContext);
            }

            base.Push(nextContext);
            BaseView nextView = Singleton<UIManager>.Instance.GetSingleUI(nextContext.ViewType).GetComponent<BaseView>();
            Debug.Log(nextView.name);
            nextView.OnEnter(nextContext);
        }

        public new void Pop()
        {
            if (Count != 0)
            {
                BaseContext curContext = base.Pop();
                BaseView curView = Singleton<UIManager>.Instance.GetSingleUI(curContext.ViewType).GetComponent<BaseView>();
                curView.OnExit(curContext);
            }

            if (Count != 0)
            {
                BaseContext lastContext = Peek();
                BaseView curView = Singleton<UIManager>.Instance.GetSingleUI(lastContext.ViewType).GetComponent<BaseView>();
                curView.OnResume(lastContext);
            }
        }

        public BaseContext PeekOrNull()
        {
            if (Count != 0)
            {
                return Peek();
            }
            return null;
        }
    }
}
