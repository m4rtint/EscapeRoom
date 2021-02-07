using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace EscapeRoom
{
    public class CombinationLockBehaviour : MonoBehaviour
    {
        [SerializeField] private CombinationLock _combinationLock = null;

        [Title("Component")] 
        [SerializeField] private CombinationBehaviour[] _combination = null;
        
        public event Action OnSolvedCombination;

        private void OnEnable()
        {
            foreach (var combo in _combination)
            {
                combo.Initialize(_combinationLock);
                combo.OnChangedCombination += HandleOnChangedCombination;
            }   
        }

        private void OnDisable()
        {
            foreach (var combo in _combination)
            {
                combo.OnChangedCombination -= HandleOnChangedCombination;
            }   
        }

        private void HandleOnChangedCombination()
        {
            if (IsCorrectAnswer())
            {
                if (OnSolvedCombination != null)
                {
                    OnSolvedCombination();
                }
            }
        }

        private bool IsCorrectAnswer()
        {
            var answer = _combinationLock.Answer;
            var result = 0f;
            var numberOfCombinations = _combination.Length;
            for (var i = 0; i < numberOfCombinations; i++)
            {
                var placement = _combination[i].CombinationPosition * Mathf.Pow(10, numberOfCombinations - i - 1);
                result += placement;
            }

            return (int)result == answer;
        }
    }
}