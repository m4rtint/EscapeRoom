using System;
using UnityEngine;

namespace EscapeRoom
{
    [CreateAssetMenu(fileName = "Book", menuName = "EscapeRoom/Book", order = 1)]
    public class Book : ScriptableObject
    {
        public string Title = string.Empty;
        public Page[] Pages = null;
    }
    
    [Serializable]
    public struct Page
    {
        public string Title;
        [TextArea]
        public string Paragraph;
        public bool IsBookmarked;
    }
}