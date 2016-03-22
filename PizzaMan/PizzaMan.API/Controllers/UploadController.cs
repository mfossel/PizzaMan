using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using PizzaMan.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace PizzaMan.API.Controllers
{
    public class BlobStorageMultipartStreamProvider : MultipartStreamProvider
    {
        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            Stream stream = null;
            ContentDispositionHeaderValue contentDisposition = headers.ContentDisposition;
            if (contentDisposition != null)
            {
                if (!String.IsNullOrWhiteSpace(contentDisposition.FileName))
                {
                    string connectionString = ConfigurationManager.AppSettings["DefaultEndpointsProtocol=https;AccountName=pizzamanphoto;AccountKey=PzCVthOr26wxzntaP5ZDROo4kEhCYHvBl6V9fnl/aR00/4IaXcOtQBSNhJU79tCdWvgtJrKUPmb5HJgabSDvJQ==;BlobEndpoint=https://pizzamanphoto.blob.core.windows.net/;TableEndpoint=https://pizzamanphoto.table.core.windows.net/;QueueEndpoint=https://pizzamanphoto.queue.core.windows.net/;FileEndpoint=https://pizzamanphoto.file.core.windows.net/"];
                    string containerName = ConfigurationManager.AppSettings["pizzeriaphotos"];
                    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);

                    CloudBlockBlob blob = blobContainer.GetBlockBlobReference(contentDisposition.FileName);
                    stream = blob.OpenWrite();
                }
            }
            return stream;
        }
    }

    public class ImageUploadController : ApiController
    {
        [Route("api/photo/upload")]
        public async Task<HttpResponseMessage> PostFormData()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            try
            {
                MultipartStreamProvider provider = new BlobStorageMultipartStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}


