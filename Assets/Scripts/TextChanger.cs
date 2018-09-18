using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField]
    private Text _text = null;

    private void Start()
    {
#if DEBUG
        _text.text = "Debug";
#else
        _text.text = "Release";
#endif
    }

}
