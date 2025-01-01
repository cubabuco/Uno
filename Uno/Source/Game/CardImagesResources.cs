using System;
using System.Collections.Generic;
using System.Drawing;

namespace Uno
{
    public static class CardImagesResources
    {
        public static Dictionary<CardImages, Image> CardImageList = new Dictionary<CardImages, Image>(55);

        static CardImagesResources()
        {
            using (var imageHelper = new ImageHelpers())
            {
                var i = 0;
                foreach (int y in Enum.GetValues(typeof(CardImages)))
                {
                    CardImageList.Add((CardImages)y, imageHelper.LoadEmbededImage($"Uno.Images.{Enum.GetName(typeof(CardImages), y)}.png")); //0
                }
            }
        }
    }
}
