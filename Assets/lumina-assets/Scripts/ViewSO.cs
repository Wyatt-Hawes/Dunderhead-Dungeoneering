using UnityEngine;

namespace GDL_Tutorial{
    [CreateAssetMenu(menuName = "CustomUI/ViewSO", fileName = "ViewSO", order = 0)]
    public class ViewSO : ScriptableObject{
        public ThemeSO theme;
        public RectOffset padding;
        public float spacing;
    }
}