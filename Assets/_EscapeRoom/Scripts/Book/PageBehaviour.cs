using System;
using TMPro;
using UnityEngine;

namespace EscapeRoom
{
    public class PageBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title = null;
        [SerializeField] private TMP_Text _paragraph = null;
        [SerializeField] private TMP_Text _pageNumber = null;

        public void SetPage(Page page, int pageNumber = -1)
        {
            _title.text = page.Title;
            _paragraph.text = page.Paragraph;
            _pageNumber.text = pageNumber != -1 ? pageNumber.ToString() : string.Empty;
        }
    }
}