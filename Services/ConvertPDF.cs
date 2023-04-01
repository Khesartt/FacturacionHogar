﻿using FacturacionHogar.Interfaces;
using FacturacionHogar.models;
using SelectPdf;


namespace FacturacionHogar.Services
{
    public class ConvertPDF : IConvertPdf
    {
        private readonly IWebHostEnvironment env;
        private readonly string ruta;
        private readonly string path;


        private string html;
        public ConvertPDF(IWebHostEnvironment _env)
        {
            env = _env;
            #region htmlPlantilla
            html = @"<!DOCTYPE html> <html lang=""en""><head> <meta charset=""UTF-8""><meta http-equiv=""X-UA-Compatible"" content=""IE=edge""><meta name=""viewport"" content=""width=device-width, initial-scale=1.0""><!-- CSS only --><link href=""@ruta\bootstrap.min.css"" rel=""stylesheet"" type=""text/css""><!-- JavaScript Bundle with Popper --><script type=""text/javascript"" src=""@ruta\bootstrap.bundle.min.js""></script><link href=""@ruta\bootstrap-icons.css"" rel=""stylesheet"" type=""text/css""><title>Formulario</title></head> 
   <style>
        .container {
            margin: 1em;
            padding: 0;
        }
        .recibo {
            width: 850px;
            height: 600px;
        }
        .bodyInfo {
            width: 100%;
            padding: 5px;
        }
        /*contenedor por seccion*/
        .encabezado {
            height: 20%;
            margin-top: 8px;
        }
        .informacion {
            height: 50%;
            margin-top: 8px;
        }
        .fechas {
            height: 10%;
            margin-top: 6px;
        }
        .firmas {
            height: 20%;
            margin-top: 6px;
        }
        /*contenedor por seccion*/

        /*seccion de los titulos*/
        .colTitle,
        .titleInfo {
            margin: 0;
            padding: 0;
            width: 100%;
            height: 100%;
        }
        .titleText {
            margin-right: 4px;
            border: 1px solid rgb(18, 128, 253);
            background-color: rgba(218, 234, 255, 0.466);
            border-radius: 0.5rem;
        height: 105%;
        }
        .tag,
        .tagClient,
        .tagDates {
            font-family: 'Times New Roman', Times, serif;
            color: rgba(26, 124, 236, 0.651);
            font-weight: bolder;
            font-size: 30px;
            text-align: center;
            line-height: 1.5em;
        }
        .tagClient {
            font-size: 24px;
            margin-top: 10px;
        }
        .tagDates {
            display: inline;
            position: absolute;
            font-size: 20px;
            margin-top: 2px;
            margin-left:4px;
        }
        .rowInfo {
            margin: 0;
            padding: 0;
            height: 50%;
            width: 100%;
        }
        .anotherTitleInfo {
            margin-left: 4px;
        }
        .valueType{
          margin-bottom: 4px; 
        }
        .dateType{
          margin-top: 4px; 

        }
        .value,
        .number {
            margin-bottom: 4px;
        }
        .dateInfo {
            margin-top: 2px;
        }
        .value {
            margin-right: 4px;
            border: 1px solid rgb(18, 128, 253);
            background-color: rgba(218, 234, 255, 0.466);
            border-radius: 0.5rem;

        }
        .number {
            margin-left: 4px;
            border: 1px solid rgb(18, 128, 253);
            background-color: rgba(218, 234, 255, 0.466);
            border-radius: 0.5rem;

        }
        .dateInfo {
            border: 1px solid rgb(18, 128, 253);
            background-color: rgba(218, 234, 255, 0.466);
            border-radius: 0.5rem;
        }
        /*seccion de los titulos*/
        /*seccion de la informacion*/
        .dataClient {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
            border: 1px solid rgb(18, 128, 253);
            border-radius: 1em;
        }
        .dataClientCol {
            border-top: 1px solid rgb(18, 128, 253);
            border-bottom: 1px solid rgb(18, 128, 253);
            background-color: rgba(218, 234, 255, 0.466);
            margin-bottom: 2px;
            margin-top: 6px;
        }
        .nameClient {
            margin-top: 12px;

        }
        .addressClient {
            margin-bottom: 12px;
        }
        /*seccion de la informacion*/
        /*seccion de rango de fechas*/
        .dataRangeInfo {
            height: 100%;
            width: 100%;
            margin: 0;
            padding: 0;
            border: 1px solid rgb(18, 128, 253);
            background-color: rgba(218, 234, 255, 0.466);
            border-radius: 0.5rem;
        }
        .dateRange {
            border-right: 1px solid rgb(18, 128, 253);
        }
        .fromDate {
            margin: 0;
            width: 6%;
        }
        .special {
            font-size: 12px;
        }
        /*seccion de rango de fechas*/
        /*seccion de firmas*/
        .firmaArrendador {
            height: 100%;
            width: 100%;
            margin: 0;
            padding: 0;
        }
        .canvaLineSing {
            height: 100%;
            width: 100%;
            margin: 0;
            padding: 0;
            border: 1px solid rgb(18, 128, 253);
            border-radius: 0.5rem;
        }
        .singText {
            font-family: 'Times New Roman', Times, serif;
            color: rgba(18, 128, 253, 0.747);
            font-weight: lighter;
            font-size: 20px;
            text-align: center;
            line-height: 1em;
            margin: 5px;
        }
        /*seccion de firmas*/
        /*los inputs a diseñar*/
        .spanTags {
            position: relative;
            margin-right: 5px;
            font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;
            font-size: x-large;
            text-align: center;
        }
    </style>
   <body>

    <div class=""container recibo"">
        <div class=""bodyInfo encabezado"">
            <div class=""row titleInfo"">
                <div class=""col colTitle titleText"">
                    <label for=""titleText"" class=""tag titleTextLabel"">RECIBO DE ARRENDAMIENTO</label>
                </div>
                <div class=""col colTitle anotherTitleInfo"">
                    <div class=""row rowInfo valueType"">
                        <div class=""col value"">
                            <label for=""titleText"" class=""tag"">$</label>
                            <span id=""ValorRecibo"" class=""spanTags""></span>
                        </div>
                        <div class=""col number"">
                            <label for=""titleText"" class=""tag"">No.</label>
                            <span id=""NumeroRecibo"" class=""spanTags""></span>
                        </div>
                    </div>
                    <div class=""row rowInfo dateType"">
                        <div class=""col dateInfo"">
                            <label for=""titleText"" class=""tag"">Fecha:</label>
                            <span id=""FechaRecibo"" class=""spanTags""></span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""bodyInfo informacion"">
            <div class=""row dataClient"">
                <div class=""col-12 dataClientCol nameClient"">
                    <label for=""nameClient"" class=""tagClient"">Recibí de:</label>
                    <span id=""arrendatario"" class=""spanTags""></span>
                </div>
                <div class=""col-12 dataClientCol valueClient"">
                    <label for=""valueClient"" class=""tagClient"">La suma de:</label>
                    <span id=""ValorTextoRecibo"" class=""spanTags""></span>
                </div>
                <div class=""col-12 dataClientCol siteClient"">
                    <label for=""siteClient"" class=""tagClient"">Por concepto de arrendamiento de:</label>
                    <span id=""sitioRecibo"" class=""spanTags""></span>
                </div>
                <div class=""col-12 dataClientCol addressClient"">
                    <label for=""addressClient"" class=""tagClient"">Situado en:</label>
                    <span id=""DireccionRecibo"" class=""spanTags""></span>
                </div>
            </div>
        </div>
        <div class=""bodyInfo fechas"">
            <div class=""row dataRangeInfo"">
                <div class=""fromDate dateRange"">
                    <label for=""fromDate"" class=""tagDates"">Del</label>
                </div>
                <div class=""col dateRange"">
                    <label for=""fromDate"" class=""tagDates special"">Día</label>
                    <span id=""diaDRecibo"" class=""spanTags""></span>
                </div>
                <div class=""col dateRange"">
                    <label for=""fromDate"" class=""tagDates special"">Mes</label>
                    <span id=""mesDRecibo"" class=""spanTags""></span>

                </div>
                <div class=""col dateRange"">
                    <label for=""fromDate"" class=""tagDates special"">Año</label>
                    <span id=""anioDRecibo"" class=""spanTags""></span>
                </div>
                <div class=""fromDate dateRange"">
                    <label for=""fromDate"" class=""tagDates"">Al</label>
                </div>
                <div class=""col dateRange"">
                    <label for=""fromDate"" class=""tagDates special"">Día</label>
                    <span id=""diaARecibo"" class=""spanTags""></span>
                </div>
                <div class=""col dateRange"">
                    <label for=""fromDate"" class=""tagDates special"">Mes</label>
                    <span id=""mesARecibo"" class=""spanTags""></span>
                </div>
                <div class=""col"">
                    <label for=""fromDate"" class=""tagDates special"">Año</label>
                    <span id=""anioARecibo"" class=""spanTags""></span>
                </div>
            </div>
        </div>
        <div class=""bodyInfo firmas"">
            <div class=""row firmaArrendador"">
                <div class=""col""></div>
                <div class=""col canvaLineSing"">
                    <label class=""singText"">Firma del Arrendador</label>
                    <br><br>
                    <svg width=""97%"" height=""5%"" class=""singText"">
                        <line x1=""0"" y1=""0"" x2=""450"" y2=""0"" stroke-width=""2"" stroke=""rgb(18, 128, 253)""/>
                    </svg>
                    <label class=""singText"">C.C o NIT.</label>
                </div>
            </div>
        </div>
    </div>
</body>
";
            #endregion
            ruta = env.ContentRootPath + "\\htmlHelper\\";
            html = html.Replace("@ruta", ruta);
            path = @"C:\Recibos\reciboArrendamientoEnBlanco.pdf";
        }


        public async Task<Response<string>> GetHtmlExample()
        {
            Response<string> response = new();
            try
            {
                response.result = html;
            }
            catch (Exception ex)
            {
                response = new Response<string>(ex);
                response.message = "fallo en el metodo GetHtmlExample servicio ConvertPDF";

            }
            return await Task.FromResult(response);
        }

        private bool generatePdf()
        {
            try
            {
                HtmlToPdf convert = new HtmlToPdf();
                convert.Options.PdfPageSize = PdfPageSize.Note;
                convert.Options.PdfPageOrientation = PdfPageOrientation.Landscape;
                convert.Options.MarginTop = 0;
                convert.Options.MarginLeft = 0;
                convert.Options.MarginRight = -300;
                convert.Options.MarginBottom = -300;
                convert.Options.MinPageLoadTime = 3;
                PdfDocument doc = convert.ConvertHtmlString(html);
                doc.Save(path);
                doc.Close();
            }
            catch (Exception)
            {
                return false;

            }
            return true;
        }
    }
}
/*
cosas que pueden ser utiles para el documento
 
convert.Options.CssMediaType = SelectPdf.HtmlToPdfCssMediaType.Print;
 
convert.Options.EmbedFonts = true;
 
convert.Options.ExternalLinksEnabled = true;
 
convert.Options.InternalLinksEnabled = true;
 
convert.Options.JavaScriptEnabled = true;
 */