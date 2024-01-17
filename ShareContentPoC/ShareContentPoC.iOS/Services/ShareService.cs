using CoreGraphics;
using Foundation;
using ShareContentPoC.Abstractions.Services;
using UIKit;

namespace ShareContentPoC.iOS.Services
{
    public class ShareService : IShareService
    {
		public ShareService()
		{
        }

        public void SharePlainText(string plainText)
        {
            var items = new NSObject[] { new NSString(plainText) };
            var activityController = new UIActivityViewController(items, null);            
            PresentViewController(activityController);
        }

        public void SharePdf(string filePath)
        {
            var url = NSUrl.FromFilename(filePath);
            var items = new NSObject[] { url };
            var activityController = new UIActivityViewController(items, null);            
            PresentViewController(activityController);
        }

        private void PresentViewController(UIActivityViewController controller)
        {
            var rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            if (controller.PopoverPresentationController != null)
            {
                controller.PopoverPresentationController.SourceView = rootController.View;

                var rect = new CGRect(rootController.View.Bounds.GetMidX(), rootController.View.Bounds.GetMidY(), 0, 0);
                controller.PopoverPresentationController.SourceRect = rect;
                controller.PopoverPresentationController.PermittedArrowDirections = 0;
            }

            rootController.PresentViewController(controller, true, null);
        }

    }
}

