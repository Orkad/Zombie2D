using UnityEngine;
using System.Collections;

namespace Orkad.UI
{
    public interface IShow
    {
        void Show();
        void Hide();
        void InstantShow();
        void InstantHide();
        bool Shown { get; }
        bool Hidden { get; }
    }

    public static class ShowExtension
    {
        public static void Toogle(this IShow thisShow)
        {
            if (thisShow.Shown)
                thisShow.Hide();
            else
                thisShow.Show();
        }
    }

}
