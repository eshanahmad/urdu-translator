
# Urdu Translator

Program that utilizes the Google Cloud Translation API v2 to translate an English input to Urdu. 


## Features

- Translation.
- Transliteration to Roman Urdu for help with pronounciation.
- Random quote generator to use for translations.


## Requirements

- Google.Cloud.Translation.V2 package to access the translation API. Also requires authentication through Google's cloud Application Default Credentials (ADC) system through gcloud CLI.

- RestSharp package for quote HTTP requests.
 
- An Urdu Nastaliq font for accurate display of translated text.