using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DefaultNamespace
{
    public class ResourcesTextureLoader : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;

        private async UniTaskVoid Start()
        {
            //асиннхронно - современно, можно
            // var texture = await Resources.LoadAsync<Texture>("Textures/GrassTexture");
            
           // _renderer.material.SetTexture("_MainTex", (Texture)texture);
            
            // древний способ - синхронно
            // var texture = await Resources.LoadAsync<Texture>("Textures/GrassTexture");
            
           // _renderer.material.SetTexture("_MainTex", (Texture)texture);
        }

        private IEnumerator LoadTexture()
        {
            var operation = Resources.LoadAsync<Texture>("Textures/GrassTexture");
            
            //пассивное ожид - класс
            // yield return operation;
            
            // активно ожидание - древность >>>>>>UnityRequest
            while (!operation.isDone)
            {
                // ждать пассивно до слде кадра
                yield return null;
            }
            _renderer.material.SetTexture("_MainText", (Texture)operation.asset);
        }
    }
}