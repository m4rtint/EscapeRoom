using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace EscapeRoom
{
   public class CombinationBehaviour : MonoBehaviour
   {
      [Title("Components")] [SerializeField] private Button _upperButton = null;
      [SerializeField] private Button _lowerButton = null;
      [SerializeField] private Image _combinationImage = null;

      private CombinationLock _combinationLock = null;
      private int _combinationPosition = 0;
      public int CombinationPosition => _combinationPosition;

      public event Action OnChangedCombination;
      
      public void Initialize(CombinationLock combinationLock)
      {
         _combinationLock = combinationLock;
         UpdateImageSlot();
      }

      private void OnEnable()
      {
         _upperButton.onClick.AddListener(() => { UpdateCombinationPosition(true); });
         _lowerButton.onClick.AddListener(() => { UpdateCombinationPosition(false); });
      }

      private void OnDisable()
      {
         _upperButton.onClick.RemoveAllListeners();
         _lowerButton.onClick.RemoveAllListeners();
      }

      private void UpdateCombinationPosition(bool isUpward)
      {
         _combinationPosition += isUpward ? 1 : -1;
         if (_combinationPosition >= _combinationLock.SpriteCombinations.Length)
         {
            _combinationPosition = 0;
         }

         if (_combinationPosition < 0)
         {
            _combinationPosition = _combinationLock.SpriteCombinations.Length - 1;
         }

         UpdateImageSlot();
         if (OnChangedCombination != null)
         {
            OnChangedCombination();
         }
      }

      private void UpdateImageSlot()
      {
         _combinationImage.sprite = _combinationLock.SpriteCombinations[_combinationPosition];
      }
   }
}