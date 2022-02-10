using CadierBiblioteca.Enums;
using CadierBiblioteca.ModelosAtuais;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace CadierDesktop.Utilitarios
{
    public class WordUtil
    {
        public void GerarPVC(List<PFisica> pfisicas, TipoPVCEnum tipoPVC, Image imagem = null)
        {
            string document = "";
            string nomeArquivo = "";
            List<string> campos = new List<string>();

            for (var i = 0; i < pfisicas.Count(); i++)
            {
                campos.Add("IdPFisica" + (i + 1));
                campos.Add("cidade" + (i + 1));
                campos.Add("estado" + (i + 1));
                campos.Add("nome" + (i + 1));
                campos.Add("cargo" + (i + 1));
                campos.Add("rg" + (i + 1));
                campos.Add("telefone" + (i + 1));
                campos.Add("Igreja" + (i + 1));
                campos.Add("Val" + (i + 1));
            }
            if (pfisicas.Count == 1)
            {
                document = tipoPVC.Equals(TipoPVCEnum.Verde) ? @"Resources\PVC_Verde.docx" : @"Resources\PVC_Cinza.docx";
            }
            else if (pfisicas.Count == 2)
            {
                document = tipoPVC.Equals(TipoPVCEnum.Verde) ? @"Resources\PVC_Verde_Dupla.docx" : @"Resources\PVC_Cinza_Dupla.docx";
            }
            else if (pfisicas.Count == 4)
            {
                document = tipoPVC.Equals(TipoPVCEnum.Verde) ? @"Resources\PVC_Verde_Quarteto.docx" : @"Resources\PVC_Cinza_Quarteto.docx";
            }

            byte[] byteArray = File.ReadAllBytes(document);

            using (var stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, true))
                {
                    MainDocumentPart mainDocumentPart1 = wordDoc.MainDocumentPart;
                    Document document1 = mainDocumentPart1.Document;

                    Body body1 = document1.GetFirstChild<Body>();
                    var paras = body1.Elements<Paragraph>();

                    for (var i = 0; i < pfisicas.Count; i++)
                    {
                        var index = i + 1;
                        string cargo = (pfisicas[i].Cargo != CargosEnum.Diacono) ?
                            (pfisicas[i].Cargo.ToString()[pfisicas[i].Cargo.ToString().Length - 1] == 'o' ? pfisicas[i].Cargo.ToString().Remove(pfisicas[i].Cargo.ToString().Length - 1) : pfisicas[i].Cargo + (!pfisicas[i].Sexo ? "a" : ""))
                            : pfisicas[i].Sexo ? pfisicas[i].Cargo.ToString() : "Diaconisa";

                        foreach (Paragraph para in paras)
                        {
                            foreach (TextBoxContent txtContent in para.Descendants<TextBoxContent>())
                            {
                                var teste = txtContent.Descendants<Text>();
                                for (var j = 0; j < txtContent.Descendants<Text>().Count(); j++)
                                {
                                    var txt = txtContent.Descendants<Text>().ElementAt(j);
                                    Text txtProximo = null;
                                    if (j < txtContent.Descendants<Text>().Count() - 1)
                                    {
                                        txtProximo = txtContent.Descendants<Text>().ElementAt(j + 1);
                                    }

                                    if (campos.Any(x => x.Equals(txt.Text + (txtProximo != null ? txtProximo.Text : ""))) && txtProximo.Text.Equals(index.ToString()))
                                    {
                                        txt.Text = txt.Text.Replace("IdPFisica", pfisicas[i].IdPFisica.ToString());
                                        if (pfisicas[i].Endereco != null)
                                        {
                                            txt.Text = txt.Text.Replace("cidade", pfisicas[i].Endereco.Cidade);
                                            txt.Text = txt.Text.Replace("estado", pfisicas[i].Endereco.Estado);
                                        }
                                        txt.Text = txt.Text.Replace("nome", pfisicas[i].Nome.ToUpper());
                                        txt.Text = txt.Text.Replace("cargo", cargo.ToUpper());//pfisicas[i].Cargo.ToString());
                                        txt.Text = txt.Text.Replace("rg", pfisicas[i].Info != null ? pfisicas[i].Info.Rg : null);
                                        txt.Text = txt.Text.Replace("telefone", pfisicas[i].Telefone1);
                                        txt.Text = txt.Text.Replace("Igreja", pfisicas[i].IdPJuridica != null ? pfisicas[i].IdPJuridica.Nome : null);
                                        txt.Text = txt.Text.Replace("Val", DateTime.Now.AddYears(1).ToString("dd/MM/yyyy"));

                                        txtProximo.Text = txtProximo != null ? txtProximo.Text.Replace(index.ToString(), "") : "";
                                    }

                                    txt.Text = txt.Text.Replace("cnpj", "14.744.907/0001-70");
                                }
                            }
                        }

                        if (imagem != null || pfisicas[i].Foto != null)
                        {
                            if (imagem == null)
                            {
                                imagem = ImagemPorURL(pfisicas[i].Foto);
                            }

                            var tempArquivo = Path.GetTempPath() + "temp.jpg";

                            SalvarArquivo(tempArquivo, imagem);

                            var table = mainDocumentPart1.Document.Body.Descendants<Table>().First(x => x.InnerText == "foto" + index);

                            var pictureCell = table.Descendants<TableCell>().First(c => c.InnerText == "foto" + index);

                            ImagePart imagePart = mainDocumentPart1.AddImagePart(ImagePartType.Jpeg);

                            using (FileStream streamImagem = new FileStream(tempArquivo, FileMode.Open))
                            {
                                imagePart.FeedData(streamImagem);
                            }

                            pictureCell.RemoveAllChildren();
                            AddImageToCell(pictureCell, mainDocumentPart1.GetIdOfPart(imagePart));

                            File.Delete(tempArquivo);
                        }
                        imagem = null;
                        nomeArquivo += "_" + pfisicas[i].IdPFisica;
                    }
                    mainDocumentPart1.Document.Save();
                }
                stream.Position = 0;
                File.WriteAllBytes(@"Gerados\PVC" + nomeArquivo + ".docx", stream.ToArray());
            }
        }

        Image ImagemPorURL(string url)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(url);
            MemoryStream ms = new MemoryStream(bytes);
            return System.Drawing.Image.FromStream(ms);
        }

        void SalvarArquivo(string caminho, Image imagem)
        {
            imagem.Save(caminho, ImageFormat.Jpeg);
        }

        private static void AddImageToCell(TableCell cell, string relationshipId)
        {
            var cx = Math.Round(1.29 * 360000);
            var cy = Math.Round(1.99 * 360000);
            var element =
              new Drawing(
                new DW.Inline(
                  new DW.Extent() { Cx = (long)(cx), Cy = (long)cy }, //{ Cx = 990000L, Cy = 792000L },
                  new DW.EffectExtent()
                  {
                      LeftEdge = 0L,
                      TopEdge = 0L,
                      RightEdge = 0L,
                      BottomEdge = 0L
                  },
                  new DW.DocProperties()
                  {
                      Id = (UInt32Value)1U,
                      Name = "Picture 1"
                  },
                  new DW.NonVisualGraphicFrameDrawingProperties(
                      new A.GraphicFrameLocks() { NoChangeAspect = true }),
                  new A.Graphic(
                    new A.GraphicData(
                      new PIC.Picture(
                        new PIC.NonVisualPictureProperties(
                          new PIC.NonVisualDrawingProperties()
                          {
                              Id = (UInt32Value)0U,
                              Name = "New Bitmap Image.jpg"
                          },
                          new PIC.NonVisualPictureDrawingProperties()),
                        new PIC.BlipFill(
                          new A.Blip(
                            new A.BlipExtensionList(
                              new A.BlipExtension()
                              {
                                  Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}"
                              })
                           )
                          {
                              Embed = relationshipId,
                              CompressionState =
                              A.BlipCompressionValues.Print
                          },
                          new A.Stretch(
                            new A.FillRectangle())),
                          new PIC.ShapeProperties(
                            new A.Transform2D(
                              new A.Offset() { X = 0L, Y = 0L },
                              new A.Extents() { Cx = (long)cx, Cy = (long)cy }),//990000L, Cy = 792000L }),
                            new A.PresetGeometry(
                              new A.AdjustValueList()
                            )
                            { Preset = A.ShapeTypeValues.Rectangle }))
                    )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                )
                {
                    DistanceFromTop = (UInt32Value)0U,
                    DistanceFromBottom = (UInt32Value)0U,
                    DistanceFromLeft = (UInt32Value)0U,
                    DistanceFromRight = (UInt32Value)0U
                });

            cell.Append(new Paragraph(new Run(element)));
        }

        public void GerarCertificado(List<PFisica> pfisicas, DateTime data)
        {
            var siglas = new Dictionary<CargosEnum, string>()
            { { CargosEnum.Obreiro, "Ob"}, { CargosEnum.Diacono, "Dc"}, { CargosEnum.Presbitero, "Pb" }, { CargosEnum.Missionario, "Ms" }, { CargosEnum.Evangelista, "Ev" }, { CargosEnum.Pastor, "Pr" } };

            string document = "";
            string nomeArquivo = "";
            List<string> campos = new List<string>();

            if (pfisicas.Count == 1)
            {
                document = @"Resources\Certificado_Consagracao.docx";
            }

            byte[] byteArray = File.ReadAllBytes(document);

            using (var stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, true))
                {
                    MainDocumentPart mainDocumentPart1 = wordDoc.MainDocumentPart;
                    Document document1 = mainDocumentPart1.Document;

                    Body body1 = document1.GetFirstChild<Body>();
                    var paras = body1.Elements<Paragraph>();

                    for (var i = 0; i < pfisicas.Count; i++)
                    {
                        var index = i + 1;
                        CultureInfo culture = new CultureInfo("pt-BR");
                        DateTimeFormatInfo dtfi = culture.DateTimeFormat;

                        int dia = data.Day;
                        int ano = data.Year;
                        string mes = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(data.Month));
                        string sigla = siglas.Where(x => x.Key.Equals(pfisicas[i].Cargo)).Select(c => c.Value).First();
                        string cargo = (pfisicas[i].Cargo != CargosEnum.Diacono) ? 
                            (pfisicas[i].Cargo.ToString()[pfisicas[i].Cargo.ToString().Length - 1] == 'o' ? pfisicas[i].Cargo.ToString().Remove(pfisicas[i].Cargo.ToString().Length - 1) : pfisicas[i].Cargo + (!pfisicas[i].Sexo ? "a" : "")) 
                            : pfisicas[i].Sexo ? pfisicas[i].Cargo.ToString() : "Diaconisa";

                        foreach (Paragraph para in paras)
                        {
                            foreach (TextBoxContent txtContent in para.Descendants<TextBoxContent>())
                            {
                                var teste = txtContent.Descendants<Text>();
                                for (var j = 0; j < txtContent.Descendants<Text>().Count(); j++)
                                {
                                    var txt = txtContent.Descendants<Text>().ElementAt(j);
                                    txt.Text = txt.Text.Replace("IdPFisica"+index, pfisicas[i].IdPFisica.ToString());
                                    txt.Text = txt.Text.Replace("Nome"+index, pfisicas[i].Nome.ToUpper());
                                    txt.Text = txt.Text.Replace("Cargo"+index, cargo);                                                                                
                                    txt.Text = txt.Text.Replace("Data"+index, dia + " de " + mes + " de " + ano);                                    
                                }
                            }

                            foreach(Text txt in para.Descendants<Text>())
                            {
                                txt.Text = txt.Text.Replace("IdPFisica" + index, pfisicas[i].IdPFisica.ToString());
                                txt.Text = txt.Text.Replace("Nome" + index, pfisicas[i].Nome);
                                txt.Text = txt.Text.Replace("RG" + index, pfisicas[i].Info != null ? pfisicas[i].Info.Rg : null);
                                txt.Text = txt.Text.Replace("Sigla" + index, sigla + (!pfisicas[i].Sexo ? "a" : ""));
                            }
                        }
                        nomeArquivo += "_" + pfisicas[i].IdPFisica;
                    }
                    mainDocumentPart1.Document.Save();
                }
                stream.Position = 0;
                File.WriteAllBytes(@"Gerados\Certificado" + nomeArquivo + ".docx", stream.ToArray());
            }
        }

        public void GerarCredencial(List<PJuridica> pjuridicas)
        {
            string document = "";
            string nomeArquivo = "";

            if (pjuridicas.Count == 1)
            {
                document = @"Resources\Credencial_Juridica.docx";
            }
            
            byte[] byteArray = File.ReadAllBytes(document);

            using (var stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, byteArray.Length);
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(stream, true))
                {
                    MainDocumentPart mainDocumentPart1 = wordDoc.MainDocumentPart;
                    Document document1 = mainDocumentPart1.Document;

                    Body body1 = document1.GetFirstChild<Body>();
                    var paras = body1.Elements<Paragraph>();

                    for (var i = 0; i < pjuridicas.Count; i++)
                    {
                        var index = i + 1;

                        foreach (Paragraph para in paras)
                        {
                            foreach (Text txt in para.Descendants<Text>())
                            {
                                txt.Text = txt.Text.Replace("Data" + index, DateTime.Now.AddYears(1).ToString("dd/MM/yyyy"));
                                txt.Text = txt.Text.Replace("IdPJuridica" + index, pjuridicas[i].IdPJuridica.ToString());
                                txt.Text = txt.Text.Replace("Nome" + index, pjuridicas[i].Nome.ToUpper());
                                if (pjuridicas[i].Endereco != null) {
                                    txt.Text = txt.Text.Replace("Rua" + index, pjuridicas[i].Endereco.Rua);
                                    txt.Text = txt.Text.Replace("Bairro" + index, pjuridicas[i].Endereco.Bairro);
                                    txt.Text = txt.Text.Replace("Cidade" + index, pjuridicas[i].Endereco.Cidade);
                                    txt.Text = txt.Text.Replace("Estado" + index, pjuridicas[i].Endereco.Estado);
                                    txt.Text = txt.Text.Replace("Cep" + index, pjuridicas[i].Endereco.Cep);
                                }
                                txt.Text = txt.Text.Replace("DataFundacao" + index, pjuridicas[i].DataFundacao != null ? pjuridicas[i].DataFundacao.Value.ToString("dd/MM/yyyy") : "");
                                txt.Text = txt.Text.Replace("DataFiliacao" + index, pjuridicas[i].SituacaoCadastral.DataEntrou.Value.ToString("dd/MM/yyyy"));
                                txt.Text = txt.Text.Replace("NomePresidente" + index, pjuridicas[i].PFisicaPresidente.Nome);
                                txt.Text = txt.Text.Replace("RGPresidente" + index, pjuridicas[i].PFisicaPresidente.Info.Rg);
                                txt.Text = txt.Text.Replace("TelefonePresidente" + index, pjuridicas[i].PFisicaPresidente.Telefone1);
                            }
                        }
                        nomeArquivo += "_" + pjuridicas[i].IdPJuridica;
                    }
                    mainDocumentPart1.Document.Save();
                }
                stream.Position = 0;
                File.WriteAllBytes(@"Gerados\Credencial" + nomeArquivo + ".docx", stream.ToArray());
            }
        }
    }
}