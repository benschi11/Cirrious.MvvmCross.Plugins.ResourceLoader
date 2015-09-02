using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace Cirrious.MvvmCross.Plugins.ResourceLoader.WindowsUWP
{
    public class MvxStoreResourceLoader : MvxResourceLoader
    {
        public override async void GetResourceStream(string resourcePath, Action<Stream> streamAction)
        {
            // we needed to replace the "/" with "\\" - see https://github.com/slodge/MvvmCross/issues/332
            resourcePath = resourcePath.Replace("/", "\\");
            var file = await Package.Current.InstalledLocation.GetFileAsync(resourcePath);
            var streamWithContent = await file.OpenReadAsync();
            var stream = streamWithContent.AsStreamForRead();
            streamAction(stream);
        }
    }
}
