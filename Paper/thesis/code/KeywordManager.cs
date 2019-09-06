/* The KeywordManager class allows us to specify keywords and their methods to in the Unity editor.
  * This prevents us from hardcoding the keywords and their methods to invoke in the code itself.
  * For the recognizer to work on the HoloLens, one must allow the application to use its microphone.
  * 
  * Websites referenced:
  * -https://github.com/kaorun55/HoloLens-Samples/blob/master/Unity/AirTapDemo/Assets/HoloToolkit/Input/Scripts/KeywordManager.cs
  */
using System.Linq;
using UnityEngine.Events;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using UnityEngine;

    public partial class KeywordManager : MonoBehaviour
    {
        [System.Serializable]
        /* This structure has two fields for every element in it: 
         * a keyword string and a UnityEvent method to bind it with. */
        public struct KeywordsBinding
        {
            public string Keyword;
            public UnityEvent Method;
        }

        public KeywordsBinding[] KeywordMethods;
        private KeywordRecognizer keywordRecognizer;
        private Dictionary<string, UnityEvent> invokeMethods;

        void Start()
        {
            if (KeywordMethods.Length > 0)
            {
               /* Add the keywords and their associated responses to a dictionary with as key the keywords 
                * and as value the response events. */
                invokeMethods = KeywordMethods.ToDictionary(
                           keywordAndResponse =>  keywordAndResponse.Keyword,
                           keywordAndResponse => keywordAndResponse.Method);
     
                /* Instantiate Unity's keyword recognizer, bind a function 
                 * for when a keyword is recognized and start it.*/
                keywordRecognizer = new KeywordRecognizer(invokeMethods.Keys.ToArray());
                keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
                keywordRecognizer.Start();
            }
        }

        private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
        {
            UnityEvent keywordMethod;
            /* Bind the variable keywordMethod with the method associated with the spoken word. */
            if (invokeMethods.TryGetValue(args.text, out keywordMethod))
            {
                /* If something got found, invoke it. */
                keywordMethod.Invoke();
            }}}