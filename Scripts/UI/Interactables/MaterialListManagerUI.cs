using System.Collections.Generic;
using UnityEngine;

public class MaterialListManagerUI : MonoBehaviour {
    [SerializeField] private MaterialUI _materialUIPrefab;
    [SerializeField] private RectTransform _content;

    private List<MaterialUI> _materialUIList = new List<MaterialUI>();
    private InteractablUI _interactablUI;

    internal void Set(InteractablUI interactablUI) {
        _interactablUI = interactablUI;
    }
    
    internal void GenerateMaterialOptions(List<MaterialsData> listOfMaterials) {        
        ClearContent();
        for (int i = 0; i < listOfMaterials.Count; i++) {
            MaterialsData _materialData = listOfMaterials[i];
            Sprite _materialThumbnail = _materialData.thumbnails;

            MaterialUI _materialUI = Instantiate(_materialUIPrefab, _content);
            _materialUI.Init(this);
            _materialUI.SetIndex(i);
            _materialUI.SetMaterialSprite(_materialThumbnail);
            _materialUI.SetButtonClickListner((materialIndex, materialThumbnail) =>{
                _interactablUI.OnChangeMaterial(materialIndex, materialThumbnail);
            });            
            _materialUIList.Add(_materialUI);
        }
    }    

    private void ClearContent() {
        _materialUIList.ForEach(materialUI => { 
            Destroy(materialUI.gameObject);
        });
        _materialUIList.Clear();
    }

    internal void DeSelectAllMaterialUI() {
        _materialUIList.ForEach(materialUI => {
            materialUI.SetHighlighter(false);
        });
    }
}
