using System;
using Android.Content;
using AndroidX.Core.Content;
using ShareContentPoC.Abstractions.Services;

namespace ShareContentPoC.Android.Services
{
    public class ShareService : IShareService
    {
        private readonly Context _context;

        public ShareService(Context context)
		{
            _context = context;
		}

        public void SharePlainText(string plainText)
        {
            var shareIntent = new Intent(Intent.ActionSend);
            shareIntent.SetType("text/plain");
            shareIntent.PutExtra(Intent.ExtraText, plainText);

            var chooserIntent = Intent.CreateChooser(shareIntent, "Share text");
            if (chooserIntent != null)
            {
                chooserIntent.AddFlags(ActivityFlags.NewTask);
                _context.StartActivity(chooserIntent);
            }
        }

        public void SharePdf(string filePath)
        {
            var shareIntent = new Intent(Intent.ActionSend);
            shareIntent.SetType("application/pdf");

            var fileUri = FileProvider.GetUriForFile(_context, "ShareContentPoC.fileprovider", new Java.IO.File(filePath));
            shareIntent.PutExtra(Intent.ExtraStream, fileUri);
            shareIntent.AddFlags(ActivityFlags.GrantReadUriPermission);

            var chooserIntent = Intent.CreateChooser(shareIntent, "Compartir archivo");
            if (chooserIntent != null)
            {
                chooserIntent.AddFlags(ActivityFlags.NewTask);
                _context.StartActivity(chooserIntent);
            }
        }
    }
}

