using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LaGuineuApi.Util.lib
{
    public class FileUtil
    {
        public static HttpResponseMessage Download(string strFileUrl,string tipo)
        {
            if(tipo == "Imagen")
            {
                strFileUrl = ConstantesUtil.PathImagenes + strFileUrl;
            }
            if (strFileUrl != "")
            {
                try
                {
                    FileInfo file = new FileInfo(strFileUrl);
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    var stream = new FileStream(file.FullName, FileMode.Open);
                    response.Content = new StreamContent(stream);
                    // response.Content = new ByteArrayContent(File.ReadAllBytes(fileName));
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue(MimeMapping.GetMimeMapping(file.Name));
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = file.Name
                    };
                    response.Content.Headers.ContentDisposition.FileName = file.Name;
                    response.Content.Headers.ContentLength = file.Length;
                    response.Headers.Add("fileName", file.Name);
                    return response;
                }
                catch (Exception e)
                {
                    var message = new HttpResponseMessage(HttpStatusCode.NotFound);
                    return message;
                }
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        public static async Task<HttpResponseMessage> Upload(HttpRequestMessage request, HttpContext httpContext, string url)
        {
            var file = "";

            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath(url);
            var provider = new MyStreamProvider(root);
            try
            {
                await request.Content.ReadAsMultipartAsync(provider);
                var json = provider.FormData.GetValues("data")[0];
                var aux = (provider.FileData[0].LocalFileName).Split('\\');
                file = aux[aux.Length - 1];
                JObject jObject = JObject.Parse(json);
                jObject.Add("fileName", file);
                return request.CreateResponse(HttpStatusCode.OK, jObject);
            }
            catch (System.Exception e)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        public class MyStreamProvider : MultipartFormDataStreamProvider
        {
            public MyStreamProvider(string uploadPath) : base(uploadPath)
            {
            }
            public override string GetLocalFileName(HttpContentHeaders headers)
            {
                string fileName = DateTime.Now + Guid.NewGuid().ToString()
                    + Path.GetExtension(headers.ContentDisposition.FileName.Replace("\"", string.Empty));
                return fileName;
            }
        }
    }
}