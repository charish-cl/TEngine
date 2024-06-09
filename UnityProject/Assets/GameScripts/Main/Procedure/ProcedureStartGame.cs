using System;
using Cysharp.Threading.Tasks;
using GameLogic;
using TEngine;
using UnityEngine;

namespace GameMain
{
    public class ProcedureStartGame : ProcedureBase
    {
        public override bool UseNativeDialog { get; }

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            StartGame().Forget();
        }

        private async UniTaskVoid StartGame()
        {
            await UniTask.Yield();
            UILoadMgr.HideAll();
            GameEvent.AddEventListener("TEngine很好用",EventTest);
            GameEvent.Send("TEngine很好用");
            // GameModule.UI.ShowUI<UIListWidget<int,int>>();
           // GameModule.UI.ShowUI();
           // await GameModule.Resource.LoadAssetAsync<SkillDisplayData>(location,CancellationToken.None);
        }

        private void EventTest()
        {
            Log.Debug("确实好用");
        }
    }
}