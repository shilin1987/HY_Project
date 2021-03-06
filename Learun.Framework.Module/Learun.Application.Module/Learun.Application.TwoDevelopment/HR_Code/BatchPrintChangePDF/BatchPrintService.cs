using iTextSharp.text;
using iTextSharp.text.pdf;
using Learun.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learun.Application.TwoDevelopment.HR_Code.BatchPrintChangePDF
{
    public class BatchPrintService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bsowpList"></param>
        /// <returns></returns>
        public byte[] getBatchPrintPdfService(List<BothSidesOfWorkPermitDTO> bsowpList)
        {
            try
            {
                MemoryStream pdfStream1 = new MemoryStream();
                int currentColSizeValue = 0,i = 0;
                
                if (bsowpList.Count >0)
                {
                    using (MemoryStream pdfStream = new MemoryStream()) { 
                        iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 30, 25, 0, 0);
                        PdfWriter pdfWriter = PdfWriter.GetInstance(document, pdfStream);
                        document.Open();
                        iTextSharp.text.Image positiveImage;
                        iTextSharp.text.Image reverseImage;
                    
                        foreach (var bsowp in bsowpList)
                        {
                            string [] post = bsowp.positive.Split(',');
                       
                            positiveImage = iTextSharp.text.Image.GetInstance(Base64ToBytes(post[1]));
                            post = bsowp.reverse.Split(',');
                            reverseImage = iTextSharp.text.Image.GetInstance(Base64ToBytes(post[1]));
                            //绘制正面
                            positiveImage.ScaleToFit(264, 160);
                            positiveImage.Alignment = iTextSharp.text.Image.ALIGN_LEFT;
                            Paragraph p = new Paragraph(3f);
                            //Paragraph p = new Paragraph();
                            p.IndentationLeft = 0f;
                            //根据这个判断是否换行
                            currentColSizeValue = currentColSizeValue + 160 + 3;
                            //绘制反面
                            p.Add(new Chunk(reverseImage, 264, 3));
                            document.Add(p);
                            //生成行之间的空隙
                            Paragraph p1 = new Paragraph(3f);
                            document.Add(p1);
                            document.Add(positiveImage);
                            if (currentColSizeValue + 160 > iTextSharp.text.PageSize.A4.Height)
                            {
                                //分页，新的一页重置分页条件
                                currentColSizeValue = 0;
                                document.NewPage();
                            }
                        }
                        document.Close();
                        pdfWriter.Close();
                        pdfStream.Close();
                        pdfStream1 = pdfStream;
                    }
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(new Exception("请选择对应上岗证"));
                }
                return pdfStream1.ToArray();
            }
            catch(Exception ex)
            {
                if (ex is ExceptionEx)
                {
                    throw;
                }
                else
                {
                    throw ExceptionEx.ThrowServiceException(ex);
                }
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="base64Img"></param>
        /// <returns></returns>
        public static byte[] Base64ToBytes(string base64Img)
        {
            if (!string.IsNullOrEmpty(base64Img))
            {
                byte[] bytes = Convert.FromBase64String(base64Img);
                return bytes;
            }
            return null;
        }
    }
}
