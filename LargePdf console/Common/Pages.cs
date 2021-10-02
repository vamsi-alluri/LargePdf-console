using Aspose.Pdf;

namespace LargePdf_console
{
    public class Pages
    {
        private static readonly MarginInfo Margin_50_AllSides = new MarginInfo(50, 50, 50, 50);


        #region A4

        public static PageInfo A4
        {
            get 
            {  return new PageInfo
                        {
                            Height = 7016,
                            Width = 4960,
                            Margin = Margin_50_AllSides
                        };

            }
        
        }
        #endregion


    }
}
