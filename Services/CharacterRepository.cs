using StarWars.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace StarWars.Services
{
    public class CharacterRepository : ICharacterRepository
    {
        public async Task<List<Character>> GetCharacters()
        {
            //load local json file
            Uri uri = new Uri("ms-appx:///assets/Data.json");

            var storageFile = await StorageFile.GetFileFromApplicationUriAsync(uri);

            using (var storageStream = await storageFile.OpenReadAsync())
            {
                using (Stream stream = storageStream.AsStreamForRead())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        var jsonText = reader.ReadToEnd();
                        List<Character> myList = JsonHelpers.Deserialize<List<Character>>(jsonText);

                        //Configure portrait. Ussually this wouldn't be done here
                        foreach (var character in myList)
                        {
                            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(String.Format("ms-appx:///Assets/Portraits/{0}.jpg", character.portraitID)));
                            using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                            {
                                character.portrait = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                                character.portrait.SetSource(fileStream);
                            }
                        }

                        return myList;
                    }
                }
            }
        }
    }
}
