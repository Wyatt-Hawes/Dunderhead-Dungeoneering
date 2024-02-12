using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;
using UnityEngine.UI;

namespace GDL_Tutorial{
    public abstract class CustomUIComponent : MonoBehaviour{
        
        private void Awake(){
            Init();
        }
        public abstract void Setup();
        public abstract void Configure();
        //[Button("Reconfigure Now")]
        public void Init(){
            Setup();
            Configure();
        }

        private void OnValidate(){
            Init();
        }
    }
}
